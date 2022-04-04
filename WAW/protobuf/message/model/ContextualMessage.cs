package it.auties.whatsapp4j.protobuf.message.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import it.auties.whatsapp4j.protobuf.info.ContextInfo;
import it.auties.whatsapp4j.protobuf.message.business.ProductMessage;
import it.auties.whatsapp4j.protobuf.message.business.TemplateButtonReplyMessage;
import it.auties.whatsapp4j.protobuf.message.business.TemplateMessage;
import it.auties.whatsapp4j.protobuf.message.standard.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.Accessors;
import lombok.experimental.SuperBuilder;

/**
 * A model interface that represents a WhatsappMessage sent by a contact that provides a context.
 * Classes that implement this interface provide an accessor named contextInfo to access said property.
 *
 * This interface is sealed to prepare for <a href="https://openjdk.java.net/jeps/406">pattern matching for instanceof in switch statements</a>, set to be released in Java 17.
 */
@AllArgsConstructor
@NoArgsConstructor
@SuperBuilder(buildMethodName = "create")
@Data
@Accessors(fluent = true)
public sealed abstract class ContextualMessage implements Message permits ContactMessage, ProductMessage,
        TemplateButtonReplyMessage, ContactsArrayMessage, TextMessage, GroupInviteMessage,
        LiveLocationMessage, LocationMessage, MediaMessage, TemplateMessage {
    /**
     * The context info of this message
     */
    @JsonProperty(value = "17")
    private ContextInfo contextInfo;
}
