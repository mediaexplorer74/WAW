namespace it.auties.whatsapp4j.media
{
	using NonNull = lombok.NonNull;

	/// <summary>
	/// An immutable model class that represents the connection between WhatsappWeb4j and WhatsappWeb's server used to decrypt media message.
	/// </summary>
	/// <param name="auth"> the non auth token </param>
	/// <param name="ttl">  the time to live for the auth token in seconds </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public record MediaConnection(@NonNull String auth, int ttl)
	public virtual record MediaConnection(string auth, int ttl)
	{
	}
}