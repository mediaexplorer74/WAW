namespace it.auties.whatsapp4j.media
{
	using BinaryArray = it.auties.whatsapp4j.binary.BinaryArray;
	using MediaMessageType = it.auties.whatsapp4j.protobuf.message.model.MediaMessageType;
	using NonNull = lombok.NonNull;

	/// <summary>
	/// An immutable model class that represents an upload request
	/// </summary>
	/// <param name="url"> the non null upload url </param>
	/// <param name="directPath"> the non null direct upload path </param>
	/// <param name="mediaKey"> the non null media key </param>
	/// <param name="file"> the uploaded file </param>
	/// <param name="fileSha256"> the sha256 of the uploaded file </param>
	/// <param name="fileEncSha256"> the sha256 of the encoded file </param>
	/// <param name="sidecar"> the sidecar of the uploaded file </param>
	/// <param name="mediaType"> the type of media </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public record MediaUpload(@NonNull String url, @NonNull String directPath, @NonNull BinaryArray mediaKey, byte[] file, byte[] fileSha256, byte[] fileEncSha256, byte[] sidecar, @NonNull MediaMessageType mediaType)
	public virtual record MediaUpload(string url, string directPath, BinaryArray mediaKey, sbyte[] file, sbyte[] fileSha256, sbyte[] fileEncSha256, sbyte[] sidecar, MediaMessageType mediaType)
	{
	}

}