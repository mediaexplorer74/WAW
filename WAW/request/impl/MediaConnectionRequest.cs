package it.auties.whatsapp4j.request.impl;

import it.auties.whatsapp4j.listener.WhatsappListener;
import it.auties.whatsapp4j.request.model.JsonRequest;
import it.auties.whatsapp4j.response.model.json.JsonResponseModel;
import it.auties.whatsapp4j.whatsapp.WhatsappConfiguration;
import lombok.NonNull;

import java.util.List;

/**
 * A JSON request used to force WhatsappWeb's WebSocket to send updates regarding a contact's status.
 * After this message, the status can be fetched by listening to {@link WhatsappListener#onContactPresenceUpdate(it.auties.whatsapp4j.protobuf.chat.Chat, it.auties.whatsapp4j.protobuf.contact.Contact)} or {@link it.auties.whatsapp4j.protobuf.contact.Contact#lastKnownPresence()}.
 */
public abstract class MediaConnectionRequest<M extends JsonResponseModel> extends JsonRequest<M> {
    public MediaConnectionRequest(@NonNull WhatsappConfiguration configuration) {
        super(configuration);
    }

    @Override
    public @NonNull List<Object> buildBody() {
        return List.of("query", "mediaConn");
    }
}