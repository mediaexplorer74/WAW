


// Case 1

//package it.auties.whatsapp4j.manager;
using it.auties.whatsapp4j.listener.WhatsappListener;
using it.auties.whatsapp4j.media.MediaConnection;
using it.auties.whatsapp4j.protobuf.chat.Chat;
using it.auties.whatsapp4j.protobuf.chat.ChatMute;
using it.auties.whatsapp4j.protobuf.contact.Contact;
using it.auties.whatsapp4j.protobuf.info.MessageInfo;
using it.auties.whatsapp4j.protobuf.message.server.ProtocolMessage;
using it.auties.whatsapp4j.protobuf.model.Node;
using it.auties.whatsapp4j.request.model.Request;
using it.auties.whatsapp4j.response.impl.json.PhoneBatteryResponse;
using it.auties.whatsapp4j.response.model.binary.BinaryResponseModel;
using it.auties.whatsapp4j.response.model.common.Response;
using it.auties.whatsapp4j.response.model.json.JsonResponse;
using it.auties.whatsapp4j.utils.WhatsappUtils;
using it.auties.whatsapp4j.whatsapp.internal.WhatsappWebSocket;
using lombok.Star;
using lombok.experimental.Accessors;
using java.time.Instant;
using java.util.Star;
using java.util.concurrent.CompletableFuture;
using java.util.concurrent.ExecutorService;
using java.util.concurrent.Executors;
using java.util.function.Consumer;
using java.util.stream.Collectors;
using java.util.stream.Stream;
[RequiredArgsConstructor(access = AccessLevel.PRIVATE)]
[Data()]
[Accessors(fluent = true)]

namespace it.auties.whatsapp4j.manager
{ 
    public class WhatsappDataManager
    {

        [Getter()]
        WhatsappDataManager singletonInstance = new WhatsappDataManager(Executors.newSingleThreadExecutor(), new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList(), Instant.now().getEpochSecond());

        [NonNull()]
        ExecutorService requestsService;

        [NonNull()]
        List<Chat> chats;

        [NonNull()]
        List<Contact> contacts;

        [NonNull()]
        List<Request> pendingRequests;

        [NonNull()]
        List<WhatsappListener> listeners;

        private long initializationTimeStamp;

        private String phoneNumberJid;

        private MediaConnection mediaConnection;

        private long tag;

        [NonNull()]
        Optional<Contact> findContactByJid()
        {
        }
    }
    publicNonNull String;
    name;
    Unknown
    {
        return Collections.synchronizedList(contacts).stream().filter(e, -, Greater, Objects.equals(e.bestName().orElse(null), name)).findAny();
        UnknownpublicNonNull String;
        name;
        Unknown{
            return Collections.synchronizedList(contacts).stream().filter(e, -, Greater, Objects.equals(e.bestName().orElse(null), name)).collect(Collectors.toUnmodifiableSet());
            UnknownpublicNonNull String;
            jid;
            Unknown{
                return Collections.synchronizedList(chats).stream().filter(e, -, Greater, Objects.equals(e.jid(), WhatsappUtils.parseJid(jid))).findAny();
                UnknownpublicNonNull Chat;
                chat;
    ,atNonNull String;
                id;
                Unknown{
                    return chat.messages().stream().filter(e, -, Greater, Objects.equals(e.key().id(), id)).findAny();
                    UnknownpublicNonNull MessageInfo;
                    message;
                    Unknown{
                        return findChatByJid(message.key().chatJid());
                        UnknownpublicNonNull String;
                        name;
                        Unknown{
                            return Collections.synchronizedList(chats).stream().filter(e, -, Greater, Objects.equals(e.displayName(), name)).findAny();
                            UnknownpublicNonNull String;
                            name;
                            Unknown{
                                return Collections.synchronizedList(chats).stream().filter(e, -, Greater, Objects.equals(e.displayName(), name)).collect(Collectors.toUnmodifiableSet());
                                UnknownpublicNonNull String;
                                tag;
                                Unknown{
                                    return Collections.synchronizedList(pendingRequests).stream().filter(req, -, Greater, req.tag().equals(tag)).findAny();
                                    UnknownNonNull String;
                                    messageTag;
    ,atNonNull Response;
    < QuestionGreaterresponse;
                                    Unknown{
                                        if (req.isEmpty())
                                        {
                                            return false;
                                        }

                                        request.complete(response);
                                        pendingRequests.remove(request);
                                        return true;
                                        UnknownpublicNonNull Chat;
                                        chat;
                                        Unknown{
                                            chats.add(chat);
                                            return chat;
                                            UnknownpublicpublicNonNull Consumer;
    < (WhatsappListener > consumer);
                                            Unknown{
                                                listeners.forEach(listener, -, Greater, callOnListenerThread((Unknown, -, Greater, consumer.accept(listener)));
                                                UnknownNonNull WhatsappWebSocket;
                                                socket;
    ,atNonNull Node;
                                                node;
                                                Unknown{
                                                    if (duplicate)
                                                    {
                                                        return;
                                                    }

                                                    switch (description)
                                                    {
                                                    }
                                                    -parseResponse(socket, node, content);
                                                    caseactionGreaterparseAction(socket, node, content);
                                                    UnknownUnknownNonNull WhatsappWebSocket;
                                                    socket;
    ,,Object content;
                                                    Unknown{
                                                        ifList listContent;
                                                        UnknownUnknown{
                                                            return;
                                                            Unknownif(nodes.isEmpty()) {
                                                                return;
                                                            }

                                                            switch (firstChildNode.description())
                                                            {
                                                            }
                                                            -parseChatAction(firstChildNode);
                                                            caseuserGreaterparseContact(node);
                                                            casebatteryGreaterparseBattery(node);
                                                            casereadGreaterparseReadStatus(firstChildNode);
                                                            casereceivedGreaterparseReceivedStatus(firstChildNode);
    case"contacts";
    ,broadcastGreater{
                                                                Unknown//  Recent contacts and broadcast lists
    casemessageGreaterprocessMessages(socket, node, nodes);
                                                                UnknownUnknownNonNull Node;
                                                                node;
                                                                Unknown{
                                                                    if ((jid == null))
                                                                    {
                                                                        return;
                                                                    }

                                                                    if ((chat == null))
                                                                    {
                                                                        return;
                                                                    }

                                                                    if ((type == null))
                                                                    {
                                                                        return;
                                                                    }

                                                                    switch (type)
                                                                    {
                                                                    }
                                                                    -archiveChat(chat, true);
                                                                    caseunarchiveGreaterarchiveChat(chat, false);
                                                                    casemuteGreatermuteChat(node, chat);
                                                                    casestarGreaterstarMessage(node, chat);
                                                                    caseunstarGreaterunstarMessage(node, chat);
                                                                    caseclearGreaterdeleteMessage(node, chat);
                                                                    casedeleteGreaterchats.remove(chat);
                                                                    UnknownUnknownNonNull Node;
                                                                    node;
                                                                    Unknown{
                                                                        ifList content;
                                                                        UnknownUnknown{
                                                                            return;
                                                                            UnknownNode.fromGenericList(content).forEach(childNode, -, Greater, addOrReplaceContact(Contact.fromAttributes(childNode.attrs())));
                                                                            UnknownNonNull Contact;
                                                                            contact;
                                                                            Unknown{
                                                                                if (findContactByJid(contact.jid()).isPresent())
                                                                                {
                                                                                    contacts.remove(contact);
                                                                                    contacts.add(contact);
                                                                                    callListeners(listener, -, Greater, listener.onContactUpdate(contact));
                                                                                    return;
                                                                                }

                                                                                contacts.add(contact);
                                                                                callListeners(listener, -, Greater, listener.onNewContact(contact));
                                                                                UnknownNonNull Node;
                                                                                node;
                                                                                Unknown{
                                                                                    ifList content;
                                                                                    UnknownUnknown{
                                                                                        return;
                                                                                        Unknownnodes.forEach(childNode, -, Greater, callListeners(listener, -, Greater, parseBattery(childNode, listener)));
                                                                                        UnknownNonNull Node;
                                                                                        childNode;
    ,atNonNull WhatsappListener;
                                                                                        listener;
                                                                                        Unknown{
                                                                                            listener.onPhoneBatteryStatusUpdate(battery);
                                                                                            UnknownNonNull Node;
                                                                                            node;
    ,atNonNull Chat;
                                                                                            chat;
                                                                                            Unknown{
                                                                                                chat.mute(new ChatMute(Long.parseLong(node.attrs().get("mute"))));
                                                                                                callListeners(listener, -, Greater, listener.onChatMuteChange(chat));
                                                                                                UnknownNonNull Chat;
                                                                                                chat;
    ,bool archive;
                                                                                                Unknown{
                                                                                                    chat.isArchived(archive);
                                                                                                    callListeners(listener, -, Greater, archiveChat(chat, listener, archive));
                                                                                                    UnknownNonNull Chat;
                                                                                                    chat;
    ,,bool archive;
                                                                                                    Unknown{
                                                                                                        if (archive)
                                                                                                        {
                                                                                                            listener.onChatArchived(chat);
                                                                                                            return;
                                                                                                        }

                                                                                                        listener.onChatUnarchived(chat);
                                                                                                        UnknownNonNull Node;
                                                                                                        node;
    ,atNonNull Chat;
                                                                                                        chat;
                                                                                                        Unknown{
                                                                                                            if ((node.content() == null))
                                                                                                            {
                                                                                                                chat.messages().clear();
                                                                                                                return;
                                                                                                            }

                                                                                                            ifList content;
                                                                                                            UnknownUnknown{
                                                                                                                return;
                                                                                                                Unknownif(childNodes.isEmpty()) {
                                                                                                                    return;
                                                                                                                }

                                                                                                                findMessagesFromNode(chat, childNodes).forEach(message, -, Greater, {, chat.messages().remove(message));
                                                                                                                    callListeners(listener, -, Greater, listener.onMessageDeleted(chat, message, false));
                                                                                                                    UnknownUnknownUnknownNonNull Node;
                                                                                                                    node;
    ,atNonNull Chat;
                                                                                                                    chat;
                                                                                                                    Unknown{
                                                                                                                        ifList content;
                                                                                                                        UnknownUnknown{
                                                                                                                            return;
                                                                                                                            Unknownif(childNodes.isEmpty()) {
                                                                                                                                return;
                                                                                                                            }

                                                                                                                            findMessagesFromNode(chat, childNodes).forEach(message, -, Greater, unstarMessage(chat, message));
                                                                                                                            UnknownprivateNonNull Chat;
                                                                                                                            chat;
    ,atNonNull List;
    < (Node > childNodes);
                                                                                                                            Unknown{
                                                                                                                                return childNodes.stream().map(Node: Node:, :, attrs).map(entry, -, Greater, entry.get("index")).filter(Objects: Objects:, :, nonNull).map(id, -, Greater, findMessageById(chat, id)).map(Optional: Optional:, :, orElseThrow);
                                                                                                                                UnknownNonNull Chat;
                                                                                                                                chat;
    ,atNonNull MessageInfo;
                                                                                                                                message;
                                                                                                                                Unknown{
                                                                                                                                    message.starred(false);
                                                                                                                                    callListeners(listener, -, Greater, listener.onMessageUnstarred(chat, message));
                                                                                                                                    UnknownNonNull Node;
                                                                                                                                    node;
    ,atNonNull Chat;
                                                                                                                                    chat;
                                                                                                                                    Unknown{
                                                                                                                                        ifList content;
                                                                                                                                        UnknownUnknown{
                                                                                                                                            return;
                                                                                                                                            Unknownif(childNodes.isEmpty()) {
                                                                                                                                                return;
                                                                                                                                            }

                                                                                                                                            findMessagesFromNodes(childNodes).forEach(message, -, Greater, starMessage(chat, message));
                                                                                                                                            UnknownprivateNonNull List;
    < (Node > childNodes);
                                                                                                                                            Unknown{
                                                                                                                                                return childNodes.stream().map(Node: Node:, :, content).filter(entry, -, Greater, (entry is MessageInfo)).map(entry, -, Greater, ((MessageInfo)(entry)));
                                                                                                                                                UnknownNonNull WhatsappWebSocket;
                                                                                                                                                socket;
    ,,Object content;
                                                                                                                                                Unknown{
                                                                                                                                                    if ((type == null))
                                                                                                                                                    {
                                                                                                                                                        return;
                                                                                                                                                    }

                                                                                                                                                    ifList listContent;
                                                                                                                                                    UnknownUnknown{
                                                                                                                                                        return;
                                                                                                                                                        Unknownif(nodes.isEmpty()) {
                                                                                                                                                            return;
                                                                                                                                                        }

                                                                                                                                                        switch (type)
                                                                                                                                                        {
                                                                                                                                                        }
                                                                                                                                                        -parseContacts(nodes);
                                                                                                                                                        casechatGreaterparseChats(nodes);
                                                                                                                                                        casemessageGreaterprocessMessages(socket, node, nodes);
                                                                                                                                                        //  TODO: is this right????
                                                                                                                                                        UnknownUnknownNonNull WhatsappWebSocket;
                                                                                                                                                        socket;
    ,,List<Node> nodes;
                                                                                                                                                        Unknown{
                                                                                                                                                            if ((action == null))
                                                                                                                                                            {
                                                                                                                                                                return;
                                                                                                                                                            }

                                                                                                                                                            if ((!action.equals("last")
                                                                                                                                                                        && !last))
                                                                                                                                                            {
                                                                                                                                                                return;
                                                                                                                                                            }

                                                                                                                                                            chats.forEach(this, :, :, processMessages);
                                                                                                                                                            UnknownNonNull CompletableFuture;
    < (Chat > future);
                                                                                                                                                            Unknown{
                                                                                                                                                                callListeners(listener, -, Greater, processMessages(future, listener));
                                                                                                                                                                UnknownNonNull CompletableFuture;
    < (Chat > future);
    ,atNonNull WhatsappListener;
                                                                                                                                                                listener;
                                                                                                                                                                Unknown{
                                                                                                                                                                    future.thenAcceptAsync(listener: listener:, :, onChatRecentMessages);
                                                                                                                                                                    UnknownNonNull Node;
                                                                                                                                                                    firstChildNode;
                                                                                                                                                                    Unknown{
                                                                                                                                                                        if (chatOpt.isEmpty())
                                                                                                                                                                        {
                                                                                                                                                                            return;
                                                                                                                                                                        }

                                                                                                                                                                        if (messageOpt.isEmpty())
                                                                                                                                                                        {
                                                                                                                                                                            return;
                                                                                                                                                                        }

                                                                                                                                                                        if ((status == null))
                                                                                                                                                                        {
                                                                                                                                                                            return;
                                                                                                                                                                        }

                                                                                                                                                                        if (((status.index() <= message.globalStatus().index())
                                                                                                                                                                                    && (status != MessageInfo.MessageInfoStatus.ERROR)))
                                                                                                                                                                        {
                                                                                                                                                                            return;
                                                                                                                                                                        }

                                                                                                                                                                        message.globalStatus(status);
                                                                                                                                                                        callListeners(listener, -, Greater, listener.onMessageGlobalReadStatusUpdate(chat, message));
                                                                                                                                                                        UnknownNonNull Node;
                                                                                                                                                                        firstChildNode;
                                                                                                                                                                        Unknown{
                                                                                                                                                                            if ((jid == null))
                                                                                                                                                                            {
                                                                                                                                                                                return;
                                                                                                                                                                            }

                                                                                                                                                                            if (chatOpt.isEmpty())
                                                                                                                                                                            {
                                                                                                                                                                                return;
                                                                                                                                                                            }

                                                                                                                                                                            chat.unreadMessages(type);
                                                                                                                                                                            callListeners(listener, -, Greater, listener.onChatReadStatusChange(chat));
                                                                                                                                                                            UnknownNonNull List;
    < (Node > nodes);
                                                                                                                                                                            Unknown{
                                                                                                                                                                                nodes.stream().map(Node: Node:, :, attrs).map(Chat: Chat:, :, fromAttributes).forEach(this, :, :, addChat);
                                                                                                                                                                                callListeners(WhatsappListener: WhatsappListener:, :, onChats);
                                                                                                                                                                                UnknownNonNull List;
    < (Node > nodes);
                                                                                                                                                                                Unknown{
                                                                                                                                                                                    nodes.stream().map(Node: Node:, :, attrs).map(Contact: Contact:, :, fromAttributes).forEach(contacts: contacts:, :, add);
                                                                                                                                                                                    callListeners(WhatsappListener: WhatsappListener:, :, onContacts);
                                                                                                                                                                                    UnknownNonNull WhatsappWebSocket;
                                                                                                                                                                                    socket;
    ,atNonNull List;
    < (Node > nodes);
                                                                                                                                                                                    Unknown{
                                                                                                                                                                                        return nodes.stream().filter(node, -, Greater, (node.content() is MessageInfo)).map(node, -, Greater, ((MessageInfo)(node.content()))).map(messageInfo, -, Greater, processMessageFromNode(socket, messageInfo)).collect(Collectors.toUnmodifiableSet());
                                                                                                                                                                                        UnknownprivateNonNull WhatsappWebSocket;
                                                                                                                                                                                        socket;
    ,atNonNull MessageInfo;
                                                                                                                                                                                        messageInfo;
                                                                                                                                                                                        Unknown{
                                                                                                                                                                                            return findChatByMessage(messageInfo).map(CompletableFuture: CompletableFuture:, :, completedFuture).orElseGet((Unknown, -, Greater, queryMissingChat(socket, messageInfo.key().chatJid())).thenApplyAsync(chat, -, Greater, processMessageFromNode(messageInfo, chat));
                                                                                                                                                                                            UnknownprivateNonNull MessageInfo;
                                                                                                                                                                                            messageInfo;
    ,atNonNull Chat;
                                                                                                                                                                                            chat;
                                                                                                                                                                                            Unknown{
                                                                                                                                                                                                processMessage(chat, messageInfo);
                                                                                                                                                                                                return chat;
                                                                                                                                                                                                UnknownNonNull Chat;
                                                                                                                                                                                                chat;
    ,atNonNull MessageInfo;
                                                                                                                                                                                                message;
                                                                                                                                                                                                Unknown{
                                                                                                                                                                                                    processServerMessage(chat, message);
                                                                                                                                                                                                    commitMessage(chat, message);
                                                                                                                                                                                                    broadcastMessage(chat, message);
                                                                                                                                                                                                    UnknownNonNull Chat;
                                                                                                                                                                                                    chat;
    ,atNonNull MessageInfo;
                                                                                                                                                                                                    message;
                                                                                                                                                                                                    Unknown{
                                                                                                                                                                                                        if ((initializationTimeStamp > message.timestamp()))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            return;
                                                                                                                                                                                                            // TODO: Warning!!!, inline IF is not supported ?
                                                                                                                                                                                                        }

                                                                                                                                                                                                        updateUnreadMessages(message, chat);
                                                                                                                                                                                                        callListeners(listener, -, Greater, listener.onNewMessage(chat, message));
                                                                                                                                                                                                        UnknownNonNull Chat;
                                                                                                                                                                                                        chat;
    ,atNonNull MessageInfo;
                                                                                                                                                                                                        message;
                                                                                                                                                                                                        Unknown{
                                                                                                                                                                                                            if (!chat.messages().addOrReplace(message))
                                                                                                                                                                                                            {
                                                                                                                                                                                                                return;
                                                                                                                                                                                                            }

                                                                                                                                                                                                            callListeners(listener, -, Greater, listener.onMessageUpdate(chat, message));
                                                                                                                                                                                                            UnknownNonNull Chat;
                                                                                                                                                                                                            chat;
    ,atNonNull MessageInfo;
                                                                                                                                                                                                            message;
                                                                                                                                                                                                            Unknown{
                                                                                                                                                                                                                if (!message.container().isServerMessage())
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    return;
                                                                                                                                                                                                                }

                                                                                                                                                                                                                switch (protocolMessage.type())
                                                                                                                                                                                                                {
                                                                                                                                                                                                                }
                                                                                                                                                                                                                -processRevokeMessage(chat, protocolMessage);
                                                                                                                                                                                                                caseEPHEMERAL_SETTING;
    ,EPHEMERAL_SYNC_RESPONSEGreaterprocessEphemeralUpdate(chat, protocolMessage);
                                                                                                                                                                                                                caseHISTORY_SYNC_NOTIFICATIONGreaterthrow new UnsupportedOperationException("WhatsappWeb4j cannot handle history syncs as of now");
                                                                                                                                                                                                                UnknownUnknownNonNull Chat;
                                                                                                                                                                                                                chat;
    ,atNonNull ProtocolMessage;
                                                                                                                                                                                                                protocolMessage;
                                                                                                                                                                                                                Unknown{
                                                                                                                                                                                                                    chat.ephemeralMessagesToggleTime(protocolMessage.ephemeralSettingTimestamp());
                                                                                                                                                                                                                    chat.ephemeralMessageDuration(protocolMessage.ephemeralExpiration());
                                                                                                                                                                                                                    UnknownNonNull Chat;
                                                                                                                                                                                                                    chat;
    ,atNonNull ProtocolMessage;
                                                                                                                                                                                                                    message;
                                                                                                                                                                                                                    Unknown{
                                                                                                                                                                                                                        findMessageById(chat, id).ifPresent(oldMessage, -, Greater, processRevokeMessage(chat, oldMessage));
                                                                                                                                                                                                                        UnknownNonNull Chat;
                                                                                                                                                                                                                        chat;
    ,atNonNull MessageInfo;
                                                                                                                                                                                                                        oldMessage;
                                                                                                                                                                                                                        Unknown{
                                                                                                                                                                                                                            chat.messages().remove(oldMessage);
                                                                                                                                                                                                                            callListeners(listener, -, Greater, listener.onMessageDeleted(chat, oldMessage, true));
                                                                                                                                                                                                                            UnknownNonNull MessageInfo;
                                                                                                                                                                                                                            message;
    ,Chat chat;
                                                                                                                                                                                                                            Unknown{
                                                                                                                                                                                                                                if ((message.key().fromMe()
                                                                                                                                                                                                                                        || ((message.globalStatus() == MessageInfo.MessageInfoStatus.READ)
                                                                                                                                                                                                                                        || message.ignore())))
                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                    return;
                                                                                                                                                                                                                                }

                                                                                                                                                                                                                                chat.unreadMessages((chat.unreadMessages() + 1));
                                                                                                                                                                                                                                UnknownprivateNonNull WhatsappWebSocket;
                                                                                                                                                                                                                                socket;
    ,atNonNull String;
                                                                                                                                                                                                                                jid;
                                                                                                                                                                                                                                Unknown{
                                                                                                                                                                                                                                    return socket.queryChat(jid).thenApplyAsync(BinaryResponseModel: BinaryResponseModel:, :, data).thenApplyAsync(optional, -, Greater, optional.isEmpty());
                                                                                                                                                                                                                                    UnknownNonNull Runnable;
                                                                                                                                                                                                                                    runnable;
                                                                                                                                                                                                                                    Unknown{
                                                                                                                                                                                                                                        requestsService.execute(runnable);
                                                                                                                                                                                                                                        UnknownUnknown

                                                                                                                                                                                                                                            [NonNull()]
                                                                                                                                                                                                                                        Optional<Contact> findContactByName()
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                        [NonNull()]
                                                                                                                                                                                                                                        Set<Contact> findContactsByName()
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                        [NonNull()]
                                                                                                                                                                                                                                        Optional<Chat> findChatByJid()
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                        [NonNull()]
                                                                                                                                                                                                                                        Optional<MessageInfo> findMessageById()
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                        [NonNull()]
                                                                                                                                                                                                                                        Optional<Chat> findChatByMessage()
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                        [NonNull()]
                                                                                                                                                                                                                                        Optional<Chat> findChatByName()
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                        [NonNull()]
                                                                                                                                                                                                                                        Set<Chat> findChatsByName()
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                        [NonNull()]
                                                                                                                                                                                                                                        Optional<Request> findPendingRequest()
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                        public bool resolvePendingRequest()
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                        var req = findPendingRequest(messageTag);

                                                                                                                                                                                                                                        var request = req.get();

                                                                                                                                                                                                                                        [NonNull()]
                                                                                                                                                                                                                                        Chat addChat()
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                        public long pinnedChats()
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                            return chats.stream().filter(Chat: Chat:, :, isPinned).count();
                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                    public void clear()
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        chats.clear();
                                                                                                                                                                                                                                        contacts.clear();
                                                                                                                                                                                                                                        pendingRequests.clear();
                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                    public long tagAndIncrement()
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        return;
                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                    [NonNull()]
                                                                                                                                                                                                                                    String phoneNumberJid()
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        return Objects.requireNonNull(phoneNumberJid, "WhatsappAPI: Phone number is missing");
                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                    [NonNull()]
                                                                                                                                                                                                                                    MediaConnection mediaConnection()
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        return Objects.requireNonNull(mediaConnection, "WhatsappAPI: Media connection is missing");
                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                    public void callListeners()
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                    public void digestWhatsappNode()
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                    var description = node.description();

                                                                                                                                                                                                                                    var attrs = node.attrs();

                                                                                                                                                                                                                                    var content = node.content();

                                                                                                                                                                                                                                    var duplicate = Boolean.parseBoolean(attrs.getOrDefault("duplicate", "false"));

                                                                                                                                                                                                                                    private void parseAction()
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                    [NonNull()]
                                                                                                                                                                                                                                    Node node;

                                                                                                                                                                                                                                    var nodes = Node.fromGenericList(listContent);

                                                                                                                                                                                                                                    var firstChildNode = nodes.get(0);

                                                                                                                                                                                                                                    private void parseChatAction()
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                    var jid = node.attrs().get("jid");

                                                                                                                                                                                                                                    var chat = findChatByJid(jid).orElse(null);

                                                                                                                                                                                                                                    var type = node.attrs().get("type");

                                                                                                                                                                                                                                    private void parseContact()
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                    private void addOrReplaceContact()
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                    private void parseBattery()
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                    var nodes = Node.fromGenericList(content);

                                                                                                                                                                                                                                    private void parseBattery()
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                    var json = JsonResponse.fromMap(childNode.attrs());

                                                                                                                                                                                                                                    var battery = json.toModel(PhoneBatteryResponse.class);

    private void muteChat()
    {
    }

    private void archiveChat()
    {
    }

    private void archiveChat()
    {
    }

    [NonNull()]
    WhatsappListener listener;

    private void deleteMessage()
    {
    }

    var childNodes = Node.fromGenericList(content);

    private void unstarMessage()
    {
    }

    var childNodes = Node.fromGenericList(content);

    [NonNull()]
    Stream<MessageInfo> findMessagesFromNode()
    {
    }

    private void unstarMessage()
    {
    }

    private void starMessage()
    {
    }

    var childNodes = Node.fromGenericList(content);

    private void starMessage(Chat chat, MessageInfo message)
    {
        chat.messages().addOrReplace(message);
        callListeners(listener, -, Greater, listener.onMessageStarred(chat, message));
    }

    [NonNull()]
    Stream<MessageInfo> findMessagesFromNodes()
    {
    }

    private void parseResponse()
    {
    }

    [NonNull()]
    Node node;

    var type = node.attrs().get("type");

    var nodes = Node.fromGenericList(listContent);

    private void processMessages()
    {
    }

    [NonNull()]
    Node node;

    var action = node.attrs().get("add");

    var last = Boolean.parseBoolean(node.attrs().getOrDefault("last", "false"));

    var chats = processMessagesFromNodes(socket, nodes);

    private void processMessages()
    {
    }

    private void processMessages()
    {
    }

    private void parseReceivedStatus()
    {
    }

    var chatOpt = findChatByJid(firstChildNode.attrs().get("jid"));

    var chat = chatOpt.get();

    var messageOpt = findMessageById(chat, firstChildNode.attrs().get("index"));

    var message = messageOpt.get();

    var status = MessageInfo.MessageInfoStatus.forName(firstChildNode.attrs().get("type"));

    private void parseReadStatus()
    {
    }

    var jid = firstChildNode.attrs().get("jid");

    var type = Boolean.parseBoolean(firstChildNode.attrs().getOrDefault("type", "true"));

    var chatOpt = findChatByJid(jid);

    var chat = chatOpt.get();

    private void parseChats()
    {
    }

    private void parseContacts()
    {
    }

    private Set<CompletableFuture<Chat>> processMessagesFromNodes()
    {
    }

    [NonNull()]
    CompletableFuture<Chat> processMessageFromNode()
    {
    }

    [NonNull()]
    Chat processMessageFromNode()
    {
    }

    private void processMessage()
    {
    }

    private void broadcastMessage()
    {
    }

    private void commitMessage()
    {
    }

    private void processServerMessage()
    {
    }

    var protocolMessage = message.container().protocolMessage();

    private void processEphemeralUpdate()
    {
    }

    private void processRevokeMessage()
    {
    }

    var id = message.key().id();

    private void processRevokeMessage()
    {
    }

    private void updateUnreadMessages()
    {
    }

    [NonNull()]
    CompletableFuture<Chat> queryMissingChat()
    {
    }

    private void callOnListenerThread()
    {
    }
}

// Case 2 

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
					break;
					// ...

			}

		}

	}

}//namespace end





