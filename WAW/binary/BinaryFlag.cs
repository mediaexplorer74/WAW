using System.Collections.Generic;

namespace it.auties.whatsapp4j.binary
{
	using ContactStatus = it.auties.whatsapp4j.protobuf.contact.ContactStatus;
	using AllArgsConstructor = lombok.AllArgsConstructor;
	using Getter = lombok.Getter;
	using Accessors = lombok.experimental.Accessors;

	/// <summary>
	/// The constants of this enumerated type describe the various flags that can be used when sending a WhatsappNode, encrypted using <seealso cref="BinaryEncoder"/>, to WhatsappWeb's WebSocket.
	/// Some of these constants are also used to describe a <seealso cref="it.auties.whatsapp4j.protobuf.contact.Contact"/>'s status in the <seealso cref="ContactStatus"/> class.
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @AllArgsConstructor @Accessors(fluent = true) public enum BinaryFlag
	public sealed class BinaryFlag
	{
		public static readonly BinaryFlag AVAILABLE = new BinaryFlag("AVAILABLE", InnerEnum.AVAILABLE, unchecked((sbyte) 160));
		public static readonly BinaryFlag IGNORE = new BinaryFlag("IGNORE", InnerEnum.IGNORE, (sbyte)(1 << 7));
		public static readonly BinaryFlag ACKNOWLEDGE = new BinaryFlag("ACKNOWLEDGE", InnerEnum.ACKNOWLEDGE, (sbyte)(1 << 6));
		public static readonly BinaryFlag UNAVAILABLE = new BinaryFlag("UNAVAILABLE", InnerEnum.UNAVAILABLE, (sbyte)(1 << 4));
		public static readonly BinaryFlag EXPIRES = new BinaryFlag("EXPIRES", InnerEnum.EXPIRES, (sbyte)(1 << 3));
		public static readonly BinaryFlag COMPOSING = new BinaryFlag("COMPOSING", InnerEnum.COMPOSING, (sbyte)(1 << 2));
		public static readonly BinaryFlag RECORDING = new BinaryFlag("RECORDING", InnerEnum.RECORDING, (sbyte)(1 << 2));
		public static readonly BinaryFlag PAUSED = new BinaryFlag("PAUSED", InnerEnum.PAUSED, (sbyte)(1 << 2));

		private static readonly List<BinaryFlag> valueList = new List<BinaryFlag>();

		static BinaryFlag()
		{
			valueList.Add(AVAILABLE);
			valueList.Add(IGNORE);
			valueList.Add(ACKNOWLEDGE);
			valueList.Add(UNAVAILABLE);
			valueList.Add(EXPIRES);
			valueList.Add(COMPOSING);
			valueList.Add(RECORDING);
			valueList.Add(PAUSED);
		}

		public enum InnerEnum
		{
			AVAILABLE,
			IGNORE,
			ACKNOWLEDGE,
			UNAVAILABLE,
			EXPIRES,
			COMPOSING,
			RECORDING,
			PAUSED
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Getter private final byte data;
		private readonly sbyte data;

		public static BinaryFlag[] values()
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

		public static BinaryFlag valueOf(string name)
		{
			foreach (BinaryFlag enumInstance in BinaryFlag.valueList)
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