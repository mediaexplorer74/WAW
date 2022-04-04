//====================================================================================================
//The Free Edition of Java to C# Converter limits conversion output to 100 lines per file.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace it.auties.whatsapp4j.binary
{
	using ProtobufDecoder = it.auties.protobuf.decoder.ProtobufDecoder;
	using MessageInfo = it.auties.whatsapp4j.protobuf.info.MessageInfo;
	using Node = it.auties.whatsapp4j.protobuf.model.Node;
	using Validate = it.auties.whatsapp4j.utils.@internal.Validate;
	using NonNull = lombok.NonNull;
	using SneakyThrows = lombok.SneakyThrows;


	/// <summary>
	/// A class used to decode an encrypted BinaryArray received from WhatsappWeb's WebSocket.
	/// To encode a message use <seealso cref="BinaryDecoder"/> instead.
	/// Getting this class to work was not very easy, but I surely couldn't have done it without the help of:
	/// 
	/// <ul>
	/// <li>https://github.com/JicuNull/WhatsJava/blob/master/src/main/java/icu/jnet/whatsjava/encryption/BinaryDecoder.java - Java implementation, helped me to correctly cast a byte to an unsigned int, before I was using a method that just didn't work</li>
	/// <li>https://github.com/adiwajshing/Baileys/blob/master/src/Binary/Decoder.ts - Typescript implementation, the logic was far less error prone than the one used by the python implementation on https://github.com/sigalor/whatsapp-web-reveng and the one I came up with</li>
	/// </ul>
	/// </summary>
	public class BinaryDecoder
	{
		/// <summary>
		/// The <seealso cref="BinaryArray"/> to decode
		/// </summary>
		private BinaryArray buffer;

		/// <summary>
		/// The current index
		/// </summary>
		private int index;

		/// <summary>
		/// Decodes {@code buffer} as a new <seealso cref="Node"/>
		/// This method should not be used by multiple concurrent threads on the same instance
		/// </summary>
		/// <param name="buffer"> the BinaryArray to decrypt </param>
		/// <returns> a new <seealso cref="Node"/> containing all the information that was decrypted </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull Node decodeDecryptedMessage(@NonNull BinaryArray buffer)
		public virtual Node decodeDecryptedMessage(BinaryArray buffer)
		{
			this.buffer = buffer;
			this.index = 0;
			return readNode();
		}

		private int unpackNibble(int value)
		{
			return value >= 0 && value <= 9 ? '0' + value : value switch
			{
				int. 10 => (int) '-',
				int. 11 => (int) '.',
				int. 15 => (int) '\0',
				_ => 0
			};
		}

		private int unpackHex(int value)
		{
			return value >= 0 && value <= 15 ? value < 10 ? '0' + value : 'A' + value - 10 : 0;
		}

		private int unpackByte(int data, int value)
		{
			return BinaryTag.forData(data) switch
			{
				NIBBLE_8 => unpackNibble(value),
				HEX_8 => unpackHex(value),
				_ => throw new System.InvalidOperationException("BinaryReader#unpackByte: unexpected tag: " + data)
			};
		}

		private int readInt(int n)
		{
			checkEOS(n);
			var val = 0;
			for (var i = 0; i < n; i++)
			{
				var shift = n - 1 - i;
				val |= readUnsignedInt() << (shift * 8);
			}

			return val;
		}

		private int readInt20()
		{
			checkEOS(3);
			var a = readUnsignedInt();
			var b = readUnsignedInt();
			var c = readUnsignedInt();
			return ((a & 15) << 16) + (b << 8) + c;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private @NonNull String readPacked8(int tag)
		private string readPacked8(int tag)
		{
			var startByte = readByte();

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final var value = new StringBuilder();
			var value = new StringBuilder();
			for (var i = 0; i < (startByte & 127); i++)
			{
				var curByte = readByte();
				value.Append(Character.toChars(unpackByte(tag, ((curByte & 0xf0)) >> 4)).ToString());
				value.Append(Character.toChars(unpackByte(tag, (curByte & 0x0f))).ToString());
			}

			return startByte >> 7 != 0 ? value.substring(0, value.Length - 1) : value.ToString();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private @NonNull BinaryArray readBytes(int n)
		private BinaryArray readBytes(int n)
		{
			checkEOS(n);
			var byteArray = buffer.slice(index, index + n);
			index += n;
			return byteArray;
		}

		private sbyte readByte()
		{
			checkEOS(1);
			return buffer.at(index++);
		}

		private int readUnsignedInt()
		{
			return Byte.toUnsignedInt(readByte());
		}

		private bool isListTag(int tag)
		{
			return tag == BinaryTag.LIST_EMPTY.data() || tag == BinaryTag.LIST_8.data() || tag == BinaryTag.LIST_16.data();
		}

		private bool isBinaryTag(int tag)
		{
			return tag == BinaryTag.BINARY_8.data() || tag == BinaryTag.BINARY_20.data() || tag == BinaryTag.BINARY_32.data();
		}

		private int readListSize(int data)
		{
			return BinaryTag.forData(data) switch
			{
				LIST_EMPTY => 0,
				LIST_8 => readUnsignedInt(),
				LIST_16 => readInt(2),
				_ => throw new System.InvalidOperationException("BinaryReader#readListSize: unexpected tag: " + data)
			};
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private @NonNull String readStringFromCharacters(int length)
		private string readStringFromCharacters(int length)
		{
			checkEOS(length);
			var value = buffer.slice(index, index + length);
			index += length;
			return value.ToString();
		}

		private string getToken(int index)
		{
			Validate.isTrue(index >= 3 && index < BinaryTokens.SINGLE_BYTE.size(), "Unexpected value: %s", index);
			return BinaryTokens.SINGLE_BYTE.get(index);
		}

		private string getDoubleToken(int index1, int index2)
		{
			var n = 256 * index1 + index2;
			Validate.isTrue(n >= 0 && n <= BinaryTokens.DOUBLE_BYTE.size(), "Unexpected value: " + n);
			return BinaryTokens.DOUBLE_BYTE.get(n);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private @NonNull String readString(int data)
		private string readString(int data)
		{
			return data >= 3 && data <= 235 ? getToken(data) : BinaryTag.forData(data) switch
			{
				DICTIONARY_0, DICTIONARY_1, DICTIONARY_2, DICTIONARY_3 => getDoubleToken(data - BinaryTag.DICTIONARY_0.data(), readByte()),
				BINARY_8 => readStringFromCharacters(readByte()),
				BINARY_20 => readStringFromCharacters(readInt20()),
				BINARY_32 => readStringFromCharacters(readInt(4)),
				JID_PAIR => "%s@%s".formatted(readString(readUnsignedInt()), readString(readUnsignedInt())),
				NIBBLE_8, HEX_8 => readPacked8(data),
				_ => throw new System.InvalidOperationException("BinaryReader#readString: unexpected tag: " + data)
			};
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SneakyThrows private java.util.Map<String, String> readAttributes(int n)
		private IDictionary<string, string> readAttributes(int n)
		{
//JAVA TO C# CONVERTER TODO TASK: Method reference constructor syntax is not converted by Java to C# Converter:
			return IntStream.range(0, n).boxed().collect(Collectors.toMap(x => readString(readUnsignedInt()), x => readString(readUnsignedInt()), (a, b) => b, Hashtable::new));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SneakyThrows private @NonNull Node readNode()
		internal virtual Node readNode()
		{

//====================================================================================================
//End of the allowed output for the Free Edition of Java to C# Converter.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================
