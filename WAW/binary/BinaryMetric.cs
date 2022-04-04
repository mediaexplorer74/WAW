//====================================================================================================
//The Free Edition of Java to C# Converter limits conversion output to 100 lines per file.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================

using System.Collections.Generic;
using System.Linq;

namespace it.auties.whatsapp4j.binary
{
	using AllArgsConstructor = lombok.AllArgsConstructor;
	using Getter = lombok.Getter;
	using NonNull = lombok.NonNull;
	using Accessors = lombok.experimental.Accessors;

	/// <summary>
	/// The constants of this enumerated type describe the various metrics that can be used when sending a WhatsappNode, encrypted using <seealso cref="BinaryEncoder"/>, to WhatsappWeb's WebSocket
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @AllArgsConstructor @Accessors(fluent = true) public enum BinaryMetric
	public sealed class BinaryMetric
	{
		public static readonly BinaryMetric DEBUG_LOG = new BinaryMetric("DEBUG_LOG", InnerEnum.DEBUG_LOG, 1);
		public static readonly BinaryMetric QUERY_RESUME = new BinaryMetric("QUERY_RESUME", InnerEnum.QUERY_RESUME, 2);
		public static readonly BinaryMetric LIVE_LOCATION = new BinaryMetric("LIVE_LOCATION", InnerEnum.LIVE_LOCATION, 3);
		public static readonly BinaryMetric QUERY_MEDIA = new BinaryMetric("QUERY_MEDIA", InnerEnum.QUERY_MEDIA, 4);
		public static readonly BinaryMetric QUERY_CHAT = new BinaryMetric("QUERY_CHAT", InnerEnum.QUERY_CHAT, 5);
		public static readonly BinaryMetric QUERY_CONTACT = new BinaryMetric("QUERY_CONTACT", InnerEnum.QUERY_CONTACT, 6);
		public static readonly BinaryMetric QUERY_MESSAGES = new BinaryMetric("QUERY_MESSAGES", InnerEnum.QUERY_MESSAGES, 7);
		public static readonly BinaryMetric PRESENCE = new BinaryMetric("PRESENCE", InnerEnum.PRESENCE, 8);
		public static readonly BinaryMetric PRESENCE_SUBSCRIBE = new BinaryMetric("PRESENCE_SUBSCRIBE", InnerEnum.PRESENCE_SUBSCRIBE, 9);
		public static readonly BinaryMetric GROUP = new BinaryMetric("GROUP", InnerEnum.GROUP, 10);
		public static readonly BinaryMetric READ = new BinaryMetric("READ", InnerEnum.READ, 11);
		public static readonly BinaryMetric CHAT = new BinaryMetric("CHAT", InnerEnum.CHAT, 12);
		public static readonly BinaryMetric RECEIVED = new BinaryMetric("RECEIVED", InnerEnum.RECEIVED, 13);
		public static readonly BinaryMetric PICTURE = new BinaryMetric("PICTURE", InnerEnum.PICTURE, 14);
		public static readonly BinaryMetric STATUS = new BinaryMetric("STATUS", InnerEnum.STATUS, 15);
		public static readonly BinaryMetric MESSAGE = new BinaryMetric("MESSAGE", InnerEnum.MESSAGE, 16);
		public static readonly BinaryMetric QUERY_ACTIONS = new BinaryMetric("QUERY_ACTIONS", InnerEnum.QUERY_ACTIONS, 17);
		public static readonly BinaryMetric BLOCK = new BinaryMetric("BLOCK", InnerEnum.BLOCK, 18);
		public static readonly BinaryMetric QUERY_GROUP = new BinaryMetric("QUERY_GROUP", InnerEnum.QUERY_GROUP, 19);
		public static readonly BinaryMetric QUERY_PREVIEW = new BinaryMetric("QUERY_PREVIEW", InnerEnum.QUERY_PREVIEW, 20);
		public static readonly BinaryMetric QUERY_EMOJI = new BinaryMetric("QUERY_EMOJI", InnerEnum.QUERY_EMOJI, 21);
		public static readonly BinaryMetric QUERY_VCARD = new BinaryMetric("QUERY_VCARD", InnerEnum.QUERY_VCARD, 29);
		public static readonly BinaryMetric QUERY_STATUS = new BinaryMetric("QUERY_STATUS", InnerEnum.QUERY_STATUS, 30);
		public static readonly BinaryMetric QUERY_STATUS_UPDATE = new BinaryMetric("QUERY_STATUS_UPDATE", InnerEnum.QUERY_STATUS_UPDATE, 31);
		public static readonly BinaryMetric QUERY_LIVE_LOCATION = new BinaryMetric("QUERY_LIVE_LOCATION", InnerEnum.QUERY_LIVE_LOCATION, 33);
		public static readonly BinaryMetric QUERY_LABEL = new BinaryMetric("QUERY_LABEL", InnerEnum.QUERY_LABEL, 36);
		public static readonly BinaryMetric QUERY_QUICK_REPLY = new BinaryMetric("QUERY_QUICK_REPLY", InnerEnum.QUERY_QUICK_REPLY, 39);

		private static readonly List<BinaryMetric> valueList = new List<BinaryMetric>();

		static BinaryMetric()
		{
			valueList.Add(DEBUG_LOG);
			valueList.Add(QUERY_RESUME);
			valueList.Add(LIVE_LOCATION);
			valueList.Add(QUERY_MEDIA);
			valueList.Add(QUERY_CHAT);
			valueList.Add(QUERY_CONTACT);
			valueList.Add(QUERY_MESSAGES);
			valueList.Add(PRESENCE);
			valueList.Add(PRESENCE_SUBSCRIBE);
			valueList.Add(GROUP);
			valueList.Add(READ);
			valueList.Add(CHAT);
			valueList.Add(RECEIVED);
			valueList.Add(PICTURE);
			valueList.Add(STATUS);
			valueList.Add(MESSAGE);
			valueList.Add(QUERY_ACTIONS);
			valueList.Add(BLOCK);
			valueList.Add(QUERY_GROUP);
			valueList.Add(QUERY_PREVIEW);
			valueList.Add(QUERY_EMOJI);
			valueList.Add(QUERY_VCARD);
			valueList.Add(QUERY_STATUS);
			valueList.Add(QUERY_STATUS_UPDATE);
			valueList.Add(QUERY_LIVE_LOCATION);
			valueList.Add(QUERY_LABEL);
			valueList.Add(QUERY_QUICK_REPLY);
		}

		public enum InnerEnum
		{
			DEBUG_LOG,
			QUERY_RESUME,
			LIVE_LOCATION,
			QUERY_MEDIA,
			QUERY_CHAT,
			QUERY_CONTACT,
			QUERY_MESSAGES,
			PRESENCE,
			PRESENCE_SUBSCRIBE,
			GROUP,
			READ,
			CHAT,
			RECEIVED,
			PICTURE,
			STATUS,
			MESSAGE,
			QUERY_ACTIONS,
			BLOCK,
			QUERY_GROUP,
			QUERY_PREVIEW,
			QUERY_EMOJI,
			QUERY_VCARD,
			QUERY_STATUS,
			QUERY_STATUS_UPDATE,
			QUERY_LIVE_LOCATION,
			QUERY_LABEL,
			QUERY_QUICK_REPLY
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Getter private final int data;
		private readonly int data;

		/// <summary>
		/// Converts {@code tags} to an array of bytes using the data that they wrap
		/// </summary>
		/// <param name="tags"> the tags to convert </param>
		/// <returns> a new array of bytes </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public static @NonNull BinaryArray toArray(@NonNull BinaryMetric... tags)
		public static BinaryArray toArray(params BinaryMetric[] tags)
		{
			var data = new sbyte[tags.Length];
			Enumerable.Range(0, tags.Length).ForEach(index => data[index] = (sbyte) tags[index].data());

//====================================================================================================
//End of the allowed output for the Free Edition of Java to C# Converter.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================
