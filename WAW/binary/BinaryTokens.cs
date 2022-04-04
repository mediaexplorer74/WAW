using System.Collections.Generic;

namespace it.auties.whatsapp4j.binary
{
	using NonNull = lombok.NonNull;
	using UtilityClass = lombok.experimental.UtilityClass;

	/// <summary>
	/// The constants of this utility class describe the various tokens used by WhatsappWeb's WebSocket.
	/// These tags were extracted from JS code found at https://web.whatsapp.com/.
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @UtilityClass public class BinaryTokens
	public class BinaryTokens
	{
		/// <summary>
		/// Double byte tokens
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public final @NonNull List<String> DOUBLE_BYTE = java.util.List.of();
		public readonly IList<string> DOUBLE_BYTE = System.Collections.IList.of();


		/// <summary>
		/// Single byte tokens
		/// </summary>
		public readonly IList<string> SINGLE_BYTE = new List<string> {null, null, null, "200", "400", "404", "500", "501", "502", "action", "add", "after", "archive", "author", "available", "battery", "before", "body", "broadcast", "chat", "clear", "code", "composing", "contacts", "count", "create", "debug", "delete", "demote", "duplicate", "encoding", "error", "false", "filehash", "from", "g.us", "group", "groups_v2", "height", "id", "image", "in", "index", "invis", "item", "jid", "kind", "last", "leave", "live", "log", "media", "message", "mimetype", "missing", "modify", "name", "notification", "notify", "out", "owner", "participant", "paused", "picture", "played", "presence", "preview", "promote", "query", "raw", "read", "receipt", "received", "recipient", "recording", "relay", "remove", "response", "resume", "retry", "s.whatsapp.net", "seconds", "set", "size", "status", "subject", "subscribe", "t", "text", "to", "true", "type", "unarchive", "unavailable", "url", "user", "value", "web", "width", "mute", "read_only", "admin", "creator", "short", "update", "powersave", "checksum", "epoch", "block", "previous", "409", "replaced", "reason", "spam", "modify_tag", "message_info", "delivery", "emoji", "title", "description", "canonical-url", "matched-text", "star", "unstar", "media_key", "filename", "identity", "unread", "page", "page_count", "search", "media_message", "security", "call_log", "profile", "ciphertext", "invite", "gif", "vcard", "frequent", "privacy", "blacklist", "whitelist", "verify", "location", "document", "elapsed", "revoke_invite", "expiration", "unsubscribe", "disable", "vname", "old_jid", "new_jid", "announcement", "locked", "prop", "label", "color", "call", "offer", "call-jid", "quick_reply", "sticker", "pay_t", "accept", "reject", "sticker_pack", "invalid", "canceled", "missed", "connected", "result", "audio", "video", "recent"};
	}

}