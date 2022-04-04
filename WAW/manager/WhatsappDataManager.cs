//====================================================================================================
//The Free Edition of Java to C# Converter limits conversion output to 100 lines per file.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================

using System.Collections.Generic;
using System.Threading;

namespace it.auties.whatsapp4j.manager
{
	using WhatsappListener = it.auties.whatsapp4j.listener.WhatsappListener;
	using MediaConnection = it.auties.whatsapp4j.media.MediaConnection;
	using Chat = it.auties.whatsapp4j.protobuf.chat.Chat;
	using ChatMute = it.auties.whatsapp4j.protobuf.chat.ChatMute;
	using Contact = it.auties.whatsapp4j.protobuf.contact.Contact;
	using MessageInfo = it.auties.whatsapp4j.protobuf.info.MessageInfo;
	using ProtocolMessage = it.auties.whatsapp4j.protobuf.message.server.ProtocolMessage;
	using Node = it.auties.whatsapp4j.protobuf.model.Node;
	using Request = it.auties.whatsapp4j.request.model.Request;
	using PhoneBatteryResponse = it.auties.whatsapp4j.response.impl.json.PhoneBatteryResponse;
	using BinaryResponseModel = it.auties.whatsapp4j.response.model.binary.BinaryResponseModel;
	using Response = it.auties.whatsapp4j.response.model.common.Response;
	using JsonResponse = it.auties.whatsapp4j.response.model.json.JsonResponse;
	using WhatsappUtils = it.auties.whatsapp4j.utils.WhatsappUtils;
	using WhatsappWebSocket = it.auties.whatsapp4j.whatsapp.@internal.WhatsappWebSocket;
	using lombok;
	using Accessors = lombok.experimental.Accessors;


	/// <summary>
	/// This class is a singleton and holds all the data regarding a session with WhatsappWeb's WebSocket.
	/// It also provides various methods to query this data.
	/// It should not be used by multiple sessions as, being a singleton, it cannot determine and divide data coming from different sessions.
	/// It should not be initialized manually.
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @RequiredArgsConstructor(access = AccessLevel.PRIVATE) @Data @Accessors(fluent = true) public class WhatsappDataManager
	public class WhatsappDataManager
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private static final @Getter WhatsappDataManager singletonInstance = new WhatsappDataManager(java.util.concurrent.Executors.newSingleThreadExecutor(), new ArrayList<>(), new ArrayList<>(), new ArrayList<>(), new ArrayList<>(), java.time.Instant.now().getEpochSecond());
		private static readonly WhatsappDataManager singletonInstance = new WhatsappDataManager(Executors.newSingleThreadExecutor(), new List<>(), new List<>(), new List<>(), new List<>(), Instant.now().EpochSecond);
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private final @NonNull ExecutorService requestsService;
		private readonly ExecutorService requestsService;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private final @NonNull List<it.auties.whatsapp4j.protobuf.chat.Chat> chats;
		private readonly IList<Chat> chats;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private final @NonNull List<it.auties.whatsapp4j.protobuf.contact.Contact> contacts;
		private readonly IList<Contact> contacts;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private final @NonNull List<it.auties.whatsapp4j.request.model.Request<?, ?>> pendingRequests;
//JAVA TO C# CONVERTER WARNING: Java wildcard generics have no direct equivalent in C#:
		private readonly IList<Request<object, object>> pendingRequests;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private final @NonNull List<it.auties.whatsapp4j.listener.WhatsappListener> listeners;
		private readonly IList<WhatsappListener> listeners;
		private readonly long initializationTimeStamp;
//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods of the current type:
		private string phoneNumberJid_Conflict;
//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods of the current type:
		private MediaConnection mediaConnection_Conflict;
		private long tag;

		/// <summary>
		/// Queries the first contact whose jid is equal to {@code jid}
		/// </summary>
		/// <param name="jid"> the jid to search </param>
		/// <returns> a non empty Optional containing the first result if any is found otherwise an empty Optional empty </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull Optional<it.auties.whatsapp4j.protobuf.contact.Contact> findContactByJid(@NonNull String jid)
		public virtual Optional<Contact> findContactByJid(string jid)
		{
			return Collections.synchronizedList(contacts).Where(e => Objects.equals(e.jid(), WhatsappUtils.parseJid(jid))).First();
		}

		/// <summary>
		/// Queries the first contact whose name is equal to {@code name}
		/// </summary>
		/// <param name="name"> the name to search </param>
		/// <returns> a non empty Optional containing the first result if any is found otherwise an empty Optional empty </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull Optional<it.auties.whatsapp4j.protobuf.contact.Contact> findContactByName(@NonNull String name)
		public virtual Optional<Contact> findContactByName(string name)
		{
			return Collections.synchronizedList(contacts).Where(e => Objects.equals(e.bestName().orElse(null), name)).First();
		}

		/// <summary>
		/// Queries every contact whose name is equal to {@code name}
		/// </summary>
		/// <param name="name"> the name to search </param>
		/// <returns> a Set containing every result </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull Set<it.auties.whatsapp4j.protobuf.contact.Contact> findContactsByName(@NonNull String name)
		public virtual ISet<Contact> findContactsByName(string name)
		{
//JAVA TO C# CONVERTER TODO TASK: Most Java stream collectors are not converted by Java to C# Converter:
			return Collections.synchronizedList(contacts).Where(e => Objects.equals(e.bestName().orElse(null), name)).collect(Collectors.toUnmodifiableSet());
		}

		/// <summary>
		/// Queries the first chat whose jid is equal to {@code jid}
		/// </summary>
		/// <param name="jid"> the jid to search </param>
		/// <returns> a non empty Optional containing the first result if any is found otherwise an empty Optional empty </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull Optional<it.auties.whatsapp4j.protobuf.chat.Chat> findChatByJid(@NonNull String jid)
		public virtual Optional<Chat> findChatByJid(string jid)
		{
			return Collections.synchronizedList(chats).Where(e => Objects.equals(e.jid(), WhatsappUtils.parseJid(jid))).First();
		}

		/// <summary>
		/// Queries the message in {@code chat} whose jid is equal to {@code jid}
		/// </summary>
		/// <param name="chat"> the chat to search in </param>
		/// <param name="id">   the jid to search </param>
		/// <returns> a non empty Optional containing the result if it is found otherwise an empty Optional empty </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull Optional<it.auties.whatsapp4j.protobuf.info.MessageInfo> findMessageById(@NonNull Chat chat, @NonNull String id)
		public virtual Optional<MessageInfo> findMessageById(Chat chat, string id)
		{
			return chat.messages().Where(e => Objects.equals(e.key().id(), id)).First();
		}

		/// <summary>
		/// Queries the chat associated with {@code message}
		/// </summary>
		/// <param name="message"> the message to use as context </param>
		/// <returns> a non empty Optional containing the result if it is found otherwise an empty Optional empty </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull Optional<it.auties.whatsapp4j.protobuf.chat.Chat> findChatByMessage(@NonNull MessageInfo message)
		public virtual Optional<Chat> findChatByMessage(MessageInfo message)
		{
			return findChatByJid(message.key().chatJid());
		}

		/// <summary>
		/// Queries the first chat whose name is equal to {@code name}
		/// </summary>
		/// <param name="name"> the name to search </param>
		/// <returns> a non empty Optional containing the first result if any is found otherwise an empty Optional empty </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull Optional<it.auties.whatsapp4j.protobuf.chat.Chat> findChatByName(@NonNull String name)
		public virtual Optional<Chat> findChatByName(string name)
		{
			return Collections.synchronizedList(chats).Where(e => Objects.equals(e.displayName(), name)).First();
		}

		/// <summary>
		/// Queries every chat whose name is equal to {@code name}
		/// </summary>
		/// <param name="name"> the name to search </param>
		/// <returns> a Set containing every result </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull Set<it.auties.whatsapp4j.protobuf.chat.Chat> findChatsByName(@NonNull String name)
		public virtual ISet<Chat> findChatsByName(string name)
		{
//JAVA TO C# CONVERTER TODO TASK: Most Java stream collectors are not converted by Java to C# Converter:
			return Collections.synchronizedList(chats).Where(e => Objects.equals(e.displayName(), name)).collect(Collectors.toUnmodifiableSet());
		}

		/// <summary>
		/// Queries the first Request whose tag is equal to {@code tag}
		/// </summary>
		/// <param name="tag"> the tag to search </param>
		/// <returns> a non empty Optional containing the first result if any is found otherwise an empty Optional empty </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull Optional<it.auties.whatsapp4j.request.model.Request<?, ?>> findPendingRequest(@NonNull String tag)
//JAVA TO C# CONVERTER WARNING: Java wildcard generics have no direct equivalent in C#:
		public virtual Optional<Request<object, object>> findPendingRequest(string tag)
		{
			return Collections.synchronizedList(pendingRequests).Where(req => req.tag().Equals(tag)).First();
		}

		/// <summary>
		/// Queries the first Request whose tag is equal to {@code messageTag} and, if any is found, resolves the request using {@code response}
		/// </summary>
		/// <param name="messageTag"> the tag to search </param>
		/// <param name="response">   the response to complete the request with </param>
		/// <returns> true if any request matching {@code messageTag} is found </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public boolean resolvePendingRequest(@NonNull String messageTag, @NonNull Response<?> response)
		public virtual bool resolvePendingRequest<T1>(string messageTag, Response<T1> response)
		{
			var req = findPendingRequest(messageTag);
			if (req.Empty)
			{
				return false;
			}

			var request = req.get();
			request.complete(response);
			pendingRequests.remove(request);
			return true;
		}

		/// <summary>
		/// Adds a chat in memory
		/// </summary>
		/// <param name="chat"> the chat to add </param>
		/// <returns> the input chat </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull Chat addChat(@NonNull Chat chat)
		public virtual Chat addChat(Chat chat)
		{
			chats.add(chat);
			return chat;
		}

		/// <summary>
		/// Returns the number of pinned chats
		/// </summary>
		/// <returns> an unsigned int between zero and three(both inclusive) </returns>
		public virtual long pinnedChats()
		{
			return chats.Where(Chat.isPinned).Count();
		}

		/// <summary>
		/// Clears all data associated with the WhatsappWeb's WebSocket session
		/// </summary>
		public virtual void clear()
		{
			chats.clear();
			contacts.clear();
			pendingRequests.clear();
		}

		/// <summary>
		/// Returns the incremental tag and then increments it
		/// </summary>
		/// <returns> the tag </returns>
		public virtual long tagAndIncrement()
		{
			return tag++;
		}

		/// <summary>
		/// Returns the phone number
		/// </summary>
		/// <returns> the phone number </returns>
		/// <exception cref="NullPointerException"> if the phone number is null </exception>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull String phoneNumberJid()
		public virtual string phoneNumberJid()
		{
			return Objects.requireNonNull(phoneNumberJid_Conflict, "WhatsappAPI: Phone number is missing");
		}

		/// <summary>
		/// Returns the media connection
		/// </summary>
		/// <returns> the media connection </returns>
		/// <exception cref="NullPointerException"> if the media connection is null </exception>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull MediaConnection mediaConnection()
		public virtual MediaConnection mediaConnection()
		{
			return Objects.requireNonNull(mediaConnection_Conflict, "WhatsappAPI: Media connection is missing");
		}

		/// <summary>
		/// Executes an operation on every registered listener on the listener thread
		/// This should be used to be sure that when a listener should be called it's called on a thread that is not the WebSocket's.
		/// If this condition isn't met, if the thread is put on hold to wait for a response for a pending request, the WebSocket will freeze.
		/// </summary>
		/// <param name="consumer"> the operation to execute </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public void callListeners(@NonNull Consumer<it.auties.whatsapp4j.listener.WhatsappListener> consumer)
		public virtual void callListeners(Consumer<WhatsappListener> consumer)
		{
			listeners.forEach(listener => callOnListenerThread(() => consumer.accept(listener)));
		}

		/// <summary>
		/// Digests a {@code node} adding the data it contains to the data this singleton holds
		/// </summary>
		/// <param name="socket"> the WebSocket associated with the WhatsappWeb's session </param>
		/// <param name="node">   the WhatsappNode to digest </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public void digestWhatsappNode(@NonNull WhatsappWebSocket socket, @NonNull Node node)
		public virtual void digestWhatsappNode(WhatsappWebSocket socket, Node node)
		{
			var description = node.description();
			var attrs = node.attrs();
			var content = node.content();
			var duplicate = bool.Parse(attrs.getOrDefault("duplicate", "false"));
			if (duplicate)
			{
				return;
			}

			switch (description)
			{
				case "response":
					parseResponse(socket, node, content);
					break;
				case "action":
					parseAction(socket, node, content);
					break;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private void parseAction(@NonNull WhatsappWebSocket socket, @NonNull Node node, Object content)
		private void parseAction(WhatsappWebSocket socket, Node node, object content)
		{
//JAVA TO C# CONVERTER WARNING: Java wildcard generics have no direct equivalent in C#:
//ORIGINAL LINE: if (!(content instanceof List<?> listContent))
			if (!(content is IList<object> listContent))
			{
				return;
			}

			var nodes = Node.fromGenericList(listContent);
			if (nodes.Empty)
			{
				return;
			}

			var firstChildNode = nodes.get(0);
			switch (firstChildNode.description())
			{
				case "chat":
					parseChatAction(firstChildNode);
					break;
				case "user":

//====================================================================================================
//End of the allowed output for the Free Edition of Java to C# Converter.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================
