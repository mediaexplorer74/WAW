using System.Collections.Generic;

namespace it.auties.whatsapp4j.binary
{
	using AllArgsConstructor = lombok.AllArgsConstructor;
	using Getter = lombok.Getter;
	using NonNull = lombok.NonNull;
	using Accessors = lombok.experimental.Accessors;


	/// <summary>
	/// The constants of this enumerated type describe the various tags used by an encrypted <seealso cref="BinaryArray"/>.
	/// These tags were extracted from JS code found at https://web.whatsapp.com/.
	/// It is important to remember that these are unsigned ints, not bytes.
	/// For this reason when comparing a byte with one of these tags it is important to convert said byte to an unsigned int using <seealso cref="Byte.toUnsignedInt(sbyte)"/>.
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @AllArgsConstructor @Accessors(fluent = true) public enum BinaryTag
	public sealed class BinaryTag
	{
		public static readonly BinaryTag LIST_EMPTY = new BinaryTag("LIST_EMPTY", InnerEnum.LIST_EMPTY, 0);
		public static readonly BinaryTag STREAM_END = new BinaryTag("STREAM_END", InnerEnum.STREAM_END, 2);
		public static readonly BinaryTag DICTIONARY_0 = new BinaryTag("DICTIONARY_0", InnerEnum.DICTIONARY_0, 236);
		public static readonly BinaryTag DICTIONARY_1 = new BinaryTag("DICTIONARY_1", InnerEnum.DICTIONARY_1, 237);
		public static readonly BinaryTag DICTIONARY_2 = new BinaryTag("DICTIONARY_2", InnerEnum.DICTIONARY_2, 238);
		public static readonly BinaryTag DICTIONARY_3 = new BinaryTag("DICTIONARY_3", InnerEnum.DICTIONARY_3, 239);
		public static readonly BinaryTag LIST_8 = new BinaryTag("LIST_8", InnerEnum.LIST_8, 248);
		public static readonly BinaryTag LIST_16 = new BinaryTag("LIST_16", InnerEnum.LIST_16, 249);
		public static readonly BinaryTag JID_PAIR = new BinaryTag("JID_PAIR", InnerEnum.JID_PAIR, 250);
		public static readonly BinaryTag HEX_8 = new BinaryTag("HEX_8", InnerEnum.HEX_8, 251);
		public static readonly BinaryTag BINARY_8 = new BinaryTag("BINARY_8", InnerEnum.BINARY_8, 252);
		public static readonly BinaryTag BINARY_20 = new BinaryTag("BINARY_20", InnerEnum.BINARY_20, 253);
		public static readonly BinaryTag BINARY_32 = new BinaryTag("BINARY_32", InnerEnum.BINARY_32, 254);
		public static readonly BinaryTag NIBBLE_8 = new BinaryTag("NIBBLE_8", InnerEnum.NIBBLE_8, 255);
		public static readonly BinaryTag SINGLE_BYTE_MAX = new BinaryTag("SINGLE_BYTE_MAX", InnerEnum.SINGLE_BYTE_MAX, 256);
		public static readonly BinaryTag PACKED_MAX = new BinaryTag("PACKED_MAX", InnerEnum.PACKED_MAX, 254);

		private static readonly List<BinaryTag> valueList = new List<BinaryTag>();

		static BinaryTag()
		{
			valueList.Add(LIST_EMPTY);
			valueList.Add(STREAM_END);
			valueList.Add(DICTIONARY_0);
			valueList.Add(DICTIONARY_1);
			valueList.Add(DICTIONARY_2);
			valueList.Add(DICTIONARY_3);
			valueList.Add(LIST_8);
			valueList.Add(LIST_16);
			valueList.Add(JID_PAIR);
			valueList.Add(HEX_8);
			valueList.Add(BINARY_8);
			valueList.Add(BINARY_20);
			valueList.Add(BINARY_32);
			valueList.Add(NIBBLE_8);
			valueList.Add(SINGLE_BYTE_MAX);
			valueList.Add(PACKED_MAX);
		}

		public enum InnerEnum
		{
			LIST_EMPTY,
			STREAM_END,
			DICTIONARY_0,
			DICTIONARY_1,
			DICTIONARY_2,
			DICTIONARY_3,
			LIST_8,
			LIST_16,
			JID_PAIR,
			HEX_8,
			BINARY_8,
			BINARY_20,
			BINARY_32,
			NIBBLE_8,
			SINGLE_BYTE_MAX,
			PACKED_MAX
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Getter private final int data;
		private readonly int data;

		/// <summary>
		/// Returns the <seealso cref="BinaryTag"/> whose content matches {@code data}
		/// </summary>
		/// <param name="data"> the data to search </param>
		/// <exception cref="IllegalArgumentException"> if no <seealso cref="BinaryTag"/> matches {@code data} </exception>
		/// <returns> the matching <seealso cref="BinaryTag"/> </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public static @NonNull BinaryTag forData(int data)
		public static BinaryTag forData(int data)
		{
			return values().Where(entry => entry.data() == data).First().orElseThrow(() => new System.ArgumentException("Tag#forData: cannot convert %s to any tag".formatted(data)));
		}

		public static BinaryTag[] values()
		{
			return valueList.ToArray();
		}

		public int ordinal()
		{
			return ordinalValue;
		}

		public override string ToString()
		{
			return nameValue;
		}

		public static BinaryTag valueOf(string name)
		{
			foreach (BinaryTag enumInstance in BinaryTag.valueList)
			{
				if (enumInstance.nameValue == name)
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}
	}

}