using System.Collections.Generic;

namespace it.auties.whatsapp4j.listener
{
	using BitMatrix = com.google.zxing.common.BitMatrix;
	using WhatsappDataManager = it.auties.whatsapp4j.manager.WhatsappDataManager;
	using Chat = it.auties.whatsapp4j.protobuf.chat.Chat;
	using GroupAction = it.auties.whatsapp4j.protobuf.chat.GroupAction;
	using GroupPolicy = it.auties.whatsapp4j.protobuf.chat.GroupPolicy;
	using GroupSetting = it.auties.whatsapp4j.protobuf.chat.GroupSetting;
	using Contact = it.auties.whatsapp4j.protobuf.contact.Contact;
	using MessageInfo = it.auties.whatsapp4j.protobuf.info.MessageInfo;
	using BlocklistResponse = it.auties.whatsapp4j.response.impl.json.BlocklistResponse;
	using PhoneBatteryResponse = it.auties.whatsapp4j.response.impl.json.PhoneBatteryResponse;
	using PropsResponse = it.auties.whatsapp4j.response.impl.json.PropsResponse;
	using UserInformationResponse = it.auties.whatsapp4j.response.impl.json.UserInformationResponse;
	using WhatsappAPI = it.auties.whatsapp4j.whatsapp.WhatsappAPI;
	using WhatsappWebSocket = it.auties.whatsapp4j.whatsapp.@internal.WhatsappWebSocket;
	using Builder = lombok.Builder;
	using NonNull = lombok.NonNull;


	/// <summary>
	/// This interface can be used to listen for events fired when new information is sent by WhatsappWeb's socket.
	/// A WhatsappListener can be registered manually using <seealso cref="WhatsappAPI.registerListener(WhatsappListener)"/>.
	/// Otherwise, it can be registered by annotating it with the <seealso cref="RegisterListener"/> annotation.
	/// If the latter option is used, auto detection of listeners by calling <seealso cref="WhatsappAPI.autodetectListeners()"/>.
	/// </summary>
	public interface WhatsappListener
	{
		/// <summary>
		/// Called when <seealso cref="WhatsappWebSocket"/> successfully establishes a connection with new secrets.
		/// By default, the QR code is printed to the console.
		/// </summary>
		/// <param name="qr"> the qr code to consume </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onQRCode(@NonNull BitMatrix qr)
		void onQRCode(BitMatrix qr)
		{
			System.out.println(qr.toString("\x001B[40m  \x001B[0m", "\x001B[47m  \x001B[0m"));
		}

		/// <summary>
		/// Called when <seealso cref="WhatsappWebSocket"/> successfully establishes a connection and logs in into an account.
		/// When this event is called, any data, including chats and contact, is not guaranteed to be already in memory.
		/// Instead, <seealso cref="WhatsappListener.onChats()"/> and <seealso cref="WhatsappListener.onContacts()"/> should be used.
		/// </summary>
		/// <param name="info"> the information sent by WhatsappWeb's WebSocket about this session </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onLoggedIn(@NonNull UserInformationResponse info)
		void onLoggedIn(UserInformationResponse info)
		{
		}

		/// <summary>
		/// Called when <seealso cref="WhatsappWebSocket"/> successfully disconnects from WhatsappWeb's WebSocket.
		/// When this event is called, any data, including chats and contact, is guaranteed to not be available anymore.
		/// </summary>
		void onDisconnected()
		{
		}

		/// <summary>
		/// Called when new information regarding this session is available.
		/// Only the new data will be available in {@code info} as it's a partial object.
		/// </summary>
		/// <param name="info"> the partial object used to represent the new data available for this session </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onInformationUpdate(@NonNull UserInformationResponse info)
		void onInformationUpdate(UserInformationResponse info)
		{
		}

		/// <summary>
		/// Called when <seealso cref="WhatsappWebSocket"/> receives a plain text list.
		/// This data is usually not very useful, but it may be necessary for particular use cases.
		/// </summary>
		/// <param name="response"> the list received as plain text by <seealso cref="WhatsappWebSocket"/> </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onListResponse(@NonNull List<Object> response)
		void onListResponse(IList<object> response)
		{
		}

		/// <summary>
		/// Called when <seealso cref="WhatsappWebSocket"/> receives all the contacts from WhatsappWeb's WebSocket.
		/// To access this data use <seealso cref="WhatsappDataManager.contacts()"/>.
		/// </summary>
		void onContacts()
		{
		}

		/// <summary>
		/// Called when <seealso cref="WhatsappWebSocket"/> receives an update regarding a contact
		/// </summary>
		/// <param name="contact"> the updated contact </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onContactUpdate(@NonNull Contact contact)
		void onContactUpdate(Contact contact)
		{
		}

		/// <summary>
		/// Called when <seealso cref="WhatsappWebSocket"/> receives a new contact
		/// </summary>
		/// <param name="contact"> the new contact </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onNewContact(@NonNull Contact contact)
		void onNewContact(Contact contact)
		{
		}

		/// <summary>
		/// Called when <seealso cref="WhatsappWebSocket"/> receives an update regarding the presence of a contact.
		/// If {@code chat} is a conversation with {@code contact}, the new presence is available by calling <seealso cref="Contact.lastKnownPresence()"/>.
		/// Otherwise, it should be queried using <seealso cref="Chat.presences()"/>.
		/// </summary>
		/// <param name="chat">    the chat that this update regards </param>
		/// <param name="contact"> the contact that this update regards </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onContactPresenceUpdate(@NonNull Chat chat, @NonNull Contact contact)
		void onContactPresenceUpdate(Chat chat, Contact contact)
		{
		}

		/// <summary>
		/// Called when <seealso cref="WhatsappWebSocket"/> receives all the chats from WhatsappWeb's WebSocket.
		/// When this event is fired, it is guaranteed that all metadata excluding messages will be present.
		/// To access this data use <seealso cref="WhatsappDataManager.chats()"/>.
		/// If you also need the messages to be loaded, please refer to <seealso cref="WhatsappListener.onChatRecentMessages(Chat)"/>.
		/// </summary>
		void onChats()
		{
		}

		/// <summary>
		/// Called when <seealso cref="WhatsappWebSocket"/> receives the recent message for a chat already in memory.
		/// When this event is fired, it is guaranteed that all metadata excluding messages will be present.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onChatRecentMessages(@NonNull Chat chat)
		void onChatRecentMessages(Chat chat)
		{
		}

		/// <summary>
		/// Called when <seealso cref="WhatsappWebSocket"/> receives a new chat
		/// </summary>
		/// <param name="chat"> the new chat </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onNewChat(@NonNull Chat chat)
		void onNewChat(Chat chat)
		{
		}

		/// <summary>
		/// Called when a chat is archived
		/// </summary>
		/// <param name="chat"> the chat that was archived </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onChatArchived(@NonNull Chat chat)
		void onChatArchived(Chat chat)
		{
		}

		/// <summary>
		/// Called when a chat is unarchived
		/// </summary>
		/// <param name="chat"> the chat that was unarchived </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onChatUnarchived(@NonNull Chat chat)
		void onChatUnarchived(Chat chat)
		{
		}

		/// <summary>
		/// Called when a chat's mute changes
		/// </summary>
		/// <param name="chat"> the chat whose mute changed </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onChatMuteChange(@NonNull Chat chat)
		void onChatMuteChange(Chat chat)
		{
		}

		/// <summary>
		/// Called when a chat's read status changes
		/// </summary>
		/// <param name="chat"> the chat whose read status changed </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onChatReadStatusChange(@NonNull Chat chat)
		void onChatReadStatusChange(Chat chat)
		{
		}

		/// <summary>
		/// Called when a chat's ephemeral status changes
		/// </summary>
		/// <param name="chat"> the chat whose ephemeral status changed </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onChatEphemeralStatusChange(@NonNull Chat chat)
		void onChatEphemeralStatusChange(Chat chat)
		{
		}

		/// <summary>
		/// Called when a group's subject changes
		/// </summary>
		/// <param name="group"> the group whose subject changed </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onGroupSubjectChange(@NonNull Chat group)
		void onGroupSubjectChange(Chat group)
		{
		}

		/// <summary>
		/// Called when a group's description changes
		/// </summary>
		/// <param name="group">         the group whose description changed </param>
		/// <param name="description">   the new description </param>
		/// <param name="descriptionId"> the id of the new description </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onGroupDescriptionChange(@NonNull Chat group, @NonNull String description, @NonNull String descriptionId)
		void onGroupDescriptionChange(Chat group, string description, string descriptionId)
		{
		}

		/// <summary>
		/// Called when a group's settings change
		/// </summary>
		/// <param name="group">   the group whose settings changed </param>
		/// <param name="setting"> the setting that changed </param>
		/// <param name="policy">  the new policy that was set </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onGroupSettingsChange(@NonNull Chat group, @NonNull GroupSetting setting, @NonNull GroupPolicy policy)
		void onGroupSettingsChange(Chat group, GroupSetting setting, GroupPolicy policy)
		{
		}

		/// <summary>
		/// Called when an action is executed on a group's participant
		/// </summary>
		/// <param name="group">       the group where the action was executed </param>
		/// <param name="participant"> the target of the action that was executed </param>
		/// <param name="action">      the type of the action that was executed </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onGroupAction(@NonNull Chat group, @NonNull Contact participant, @NonNull GroupAction action)
		void onGroupAction(Chat group, Contact participant, GroupAction action)
		{
		}

		/// <summary>
		/// Called when a new message is received in a chat
		/// </summary>
		/// <param name="chat">    the chat where the message was sent </param>
		/// <param name="message"> the message that was sent </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onNewMessage(@NonNull Chat chat, @NonNull MessageInfo message)
		void onNewMessage(Chat chat, MessageInfo message)
		{
		}

		/// <summary>
		/// Called when the read status of a message changes.
		/// If {@code chat} is a conversation with {@code contact}, the new read status can be considered valid for the message itself.
		/// Otherwise, it should be considered valid only for {@code contact} without making assumptions about the status of the message for other participants of the group.
		/// </summary>
		/// <param name="chat">    the chat where the message is </param>
		/// <param name="contact"> the contact that this update regards </param>
		/// <param name="message"> the message this update regards </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onMessageReadStatusUpdate(@NonNull Chat chat, @NonNull Contact contact, @NonNull MessageInfo message)
		void onMessageReadStatusUpdate(Chat chat, Contact contact, MessageInfo message)
		{
		}

		/// <summary>
		/// Called when the metadata or content of a message is updated
		/// </summary>
		/// <param name="chat">    the chat where the message is </param>
		/// <param name="message"> the message this update regards </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onMessageUpdate(@NonNull Chat chat, @NonNull MessageInfo message)
		void onMessageUpdate(Chat chat, MessageInfo message)
		{
		}

		/// <summary>
		/// Called when a message is deleted
		/// </summary>
		/// <param name="chat">     the chat where the message is </param>
		/// <param name="message">  the message that was deleted </param>
		/// <param name="everyone"> whether this message was deleted by you only for yourself or whether the message was permanently removed </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onMessageDeleted(@NonNull Chat chat, @NonNull MessageInfo message, boolean everyone)
		void onMessageDeleted(Chat chat, MessageInfo message, bool everyone)
		{
		}

		/// <summary>
		/// Called when a message is starred
		/// </summary>
		/// <param name="chat">    the chat where the message is </param>
		/// <param name="message"> the message that was starred </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onMessageStarred(@NonNull Chat chat, @NonNull MessageInfo message)
		void onMessageStarred(Chat chat, MessageInfo message)
		{
		}

		/// <summary>
		/// Called when a message is unstarred
		/// </summary>
		/// <param name="chat">    the chat where the message is </param>
		/// <param name="message"> the message that was unstarred </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onMessageUnstarred(@NonNull Chat chat, @NonNull MessageInfo message)
		void onMessageUnstarred(Chat chat, MessageInfo message)
		{
		}

		/// <summary>
		/// Called when the global read status of a message changes.
		/// This status can be accessed calling <seealso cref="MessageInfo.globalStatus()"/>.
		/// If {@code chat} is a conversation, <seealso cref="MessageInfo.globalStatus()"/> is equal to the one stored in <seealso cref="MessageInfo.individualReadStatus()"/> for the corresponding contact.
		/// Otherwise, it is guaranteed that each value stored in <seealso cref="MessageInfo.individualReadStatus()"/> for each participant of the chat is equal or higher hierarchically then <seealso cref="MessageInfo.globalStatus()"/>.
		/// </summary>
		/// <param name="chat">    the chat where the message is </param>
		/// <param name="message"> the message that was unstarred </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onMessageGlobalReadStatusUpdate(@NonNull Chat chat, @NonNull MessageInfo message)
		void onMessageGlobalReadStatusUpdate(Chat chat, MessageInfo message)
		{
		}

		/// <summary>
		/// Called when an updated blocklist is received.
		/// This method is called both when a connection is established with WhatsappWeb and when a contact is added or removed from the blocklist.
		/// </summary>
		/// <param name="blocklist"> the updated blocklist </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onBlocklistUpdate(@NonNull BlocklistResponse blocklist)
		void onBlocklistUpdate(BlocklistResponse blocklist)
		{
		}

		/// <summary>
		/// Called when an updated list of properties is received.
		/// This method is called both when a connection is established with WhatsappWeb and when new props are available.
		/// In the latter case though, this object should be considered as partial and is guaranteed to contain only updated entries.
		/// </summary>
		/// <param name="props"> the updated list of properties </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onPropsUpdate(@NonNull PropsResponse props)
		void onPropsUpdate(PropsResponse props)
		{
		}

		/// <summary>
		/// Called when an updated object describing the status of the phone's associated with this session battery status changes
		/// </summary>
		/// <param name="battery"> the new battery status </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default void onPhoneBatteryStatusUpdate(@NonNull PhoneBatteryResponse battery)
		void onPhoneBatteryStatusUpdate(PhoneBatteryResponse battery)
		{
		}
	}

}