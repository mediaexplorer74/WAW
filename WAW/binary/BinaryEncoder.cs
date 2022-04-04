//====================================================================================================
//The Free Edition of Java to C# Converter limits conversion output to 100 lines per file.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================

using System.Collections.Generic;
using System.Linq;

namespace it.auties.whatsapp4j.binary
{
	using ProtobufEncoder = it.auties.protobuf.encoder.ProtobufEncoder;
	using MessageInfo = it.auties.whatsapp4j.protobuf.info.MessageInfo;
	using Node = it.auties.whatsapp4j.protobuf.model.Node;
	using Validate = it.auties.whatsapp4j.utils.@internal.Validate;
	using NonNull = lombok.NonNull;
	using SneakyThrows = lombok.SneakyThrows;


	/// <summary>
	/// A class used to encode a WhatsappNode and then send it to WhatsappWeb's WebSocket.
	/// To decode a message use instead <seealso cref="BinaryDecoder"/>.
	/// </summary>
	/// <param name="cache"> the message to encode </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public record BinaryEncoder(@NonNull List<sbyte> cache)
	public virtual record BinaryEncoder(IList<sbyte> cache)
	{
		/// <summary>
		/// Constructs a new empty <seealso cref="BinaryEncoder"/>
		/// </summary>
		public BinaryEncoder()
		{
			this(new List<>());
		}

		/// <summary>
		/// Encodes {@code node} as an array of bytes
		/// </summary>
		/// <returns> a new array of bytes </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public byte @NonNull [] encodeMessage(@NonNull Node node)
		public sbyte [] encodeMessage(Node node)
		{
			cache.clear();
			return writeNode(node);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private byte @NonNull [] writeNode(@NonNull Node node)
		private sbyte [] writeNode(Node node)
		{
			writeListStart(2 * node.attrs().size() + 1 + (node.content() != null ? 1 : 0));
			writeString(node.description(), false);
			writeAttributes(node.attrs());
			writeContent(node.content());
			return toByteArray();
		}

		private void pushUnsignedInt(int value)
		{
			cache.add(unchecked((sbyte)(value & 0xff)));
		}

		private void pushInt4(int value)
		{
			Enumerable.Range(0, 4).Select(i => 3 - i).mapToObj(curShift => unchecked((sbyte)((value >> (curShift * 8)) & 0xff))).ForEach(cache.add);
		}

		private void pushInt20(int value)
		{
			pushUnsignedInts(((value >> 16) & 0x0f), ((value >> 8) & 0xff), (value & 0xff));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private void pushUnsignedInts(int @NonNull... ints)
		private void pushUnsignedInts(int ints)
		{
			Arrays.stream(ints).mapToObj(entry => (sbyte) entry).forEachOrdered(cache.add);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private void pushString(@NonNull String str)
		private void pushString(string str)
		{
			pushUnsignedInts(toUnsignedIntArray(str.Bytes));
		}

		private void writeByteLength(int length)
		{
			var tag = length >= 1 << 20 ? BinaryTag.BINARY_32 : length >= 256 ? BinaryTag.BINARY_20 : BinaryTag.BINARY_8;
			pushUnsignedInt(tag.data());
			switch (tag.innerEnumValue)
			{
				case it.auties.whatsapp4j.binary.BinaryTag.InnerEnum.BINARY_32:
					pushInt4(length);
					break;
				case it.auties.whatsapp4j.binary.BinaryTag.InnerEnum.BINARY_20:
					pushInt20(length);
					break;
				case it.auties.whatsapp4j.binary.BinaryTag.InnerEnum.BINARY_8:
					pushUnsignedInt(length);
					break;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private void writeStringRaw(@NonNull String string)
		private void writeStringRaw(string @string)
		{
			writeByteLength(@string.length());
			pushString(@string);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private void writeJid(String left, @NonNull String right)
		private void writeJid(string left, string right)
		{
			pushUnsignedInt(BinaryTag.JID_PAIR.data());
			if (left != null && left.length() > 0)
			{
				writeStrings(left, right);
				return;
			}

			writeToken(BinaryTag.LIST_EMPTY.data());
			writeString(right, false);
		}

		private void writeToken(int token)
		{
			Validate.isTrue(token <= 500, "Invalid token");
			pushUnsignedInt(token);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private void writeString(@NonNull String token, boolean i)
		private void writeString(string token, bool i)
		{
			var tokenIndex = BinaryTokens.SINGLE_BYTE.IndexOf(token);
			if (!i && token.Equals("s.whatsapp.net"))
			{
				writeToken(tokenIndex);
				return;
			}

			if (tokenIndex >= 0)
			{
				if (tokenIndex < BinaryTag.SINGLE_BYTE_MAX.data())
				{
					writeToken(tokenIndex);
					return;
				}

				var overflow = tokenIndex - BinaryTag.SINGLE_BYTE_MAX.data();
				var dictionaryIndex = overflow >> 8;
				Validate.isTrue(dictionaryIndex >= 0 && dictionaryIndex <= 3, "Token out of range!");
				writeToken(BinaryTag.DICTIONARY_0.data() + dictionaryIndex);
				writeToken(overflow % 256);
				return;
			}

			var jidSepIndex = token.IndexOf('@');
			if (jidSepIndex <= 0)
			{
				writeStringRaw(token);
				return;
			}

			writeJid(token.substring(0, jidSepIndex), token.substring(jidSepIndex + 1));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private void writeStrings(@NonNull String... tokens)
		private void writeStrings(string... tokens)
		{
			tokens.ForEach(token => writeString(token, false));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private void writeAttributes(@NonNull Map<String, String> attrs)
		private void writeAttributes(IDictionary<string, string> attrs)
		{
			attrs.forEach(this.writeStrings);
		}

		private void writeListStart(int listSize)
		{
			var tag = listSize == 0 ? BinaryTag.LIST_EMPTY : listSize < 256 ? BinaryTag.LIST_8 : BinaryTag.LIST_16;
			pushUnsignedInts(tag.data(), listSize);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SneakyThrows private void writeContent(Object content)
		private void writeContent(object content)
		{
			if (content == null)
			{
				return;
			}

			if (content is string contentAsString)
			{
				writeString(contentAsString, true);
				return;
			}

//JAVA TO C# CONVERTER WARNING: Java wildcard generics have no direct equivalent in C#:
//ORIGINAL LINE: if (content instanceof java.util.List<?> contentAsList)
			if (content is IList<object> contentAsList)
			{
				Validate.isTrue(validateList(contentAsList), "Cannot encode content(%s): expected List<WhatsappNode>, got %s<?>", content, contentAsList.GetType().TypeName);
				writeListStart(contentAsList.size());
				Node.fromGenericList(contentAsList).forEach(this.writeNode);
				return;
			}

			if (content is MessageInfo contentAsMessage)
			{
				var data = ProtobufEncoder.encode(contentAsMessage);
				writeByteLength(data.length);
				pushUnsignedInts(toUnsignedIntArray(data));
				return;
			}


//====================================================================================================
//End of the allowed output for the Free Edition of Java to C# Converter.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================
