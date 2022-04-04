using System;
using System.Text;

namespace it.auties.whatsapp4j.manager
{
	using JsonProperty = com.fasterxml.jackson.annotation.JsonProperty;
	using JsonProcessingException = com.fasterxml.jackson.core.JsonProcessingException;
	using ObjectMapper = com.fasterxml.jackson.databind.ObjectMapper;
	using ObjectReader = com.fasterxml.jackson.databind.ObjectReader;
	using ObjectWriter = com.fasterxml.jackson.databind.ObjectWriter;
	using JsonDeserialize = com.fasterxml.jackson.databind.annotation.JsonDeserialize;
	using JsonSerialize = com.fasterxml.jackson.databind.annotation.JsonSerialize;
	using BinaryArray = it.auties.whatsapp4j.binary.BinaryArray;
	using KeyPairDeserializer = it.auties.whatsapp4j.serialization.KeyPairDeserializer;
	using KeyPairSerializer = it.auties.whatsapp4j.serialization.KeyPairSerializer;
	using CypherUtils = it.auties.whatsapp4j.utils.@internal.CypherUtils;
	using lombok;
	using Accessors = lombok.experimental.Accessors;


	/// <summary>
	/// This class is a data class used to hold the clientId, serverToken, clientToken, publicKey, privateKey, encryptionKey and macKey.
	/// It can be serialized using Jackson and deserialized using the fromPreferences named constructor.
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @AllArgsConstructor(access = AccessLevel.PRIVATE) @NoArgsConstructor(access = AccessLevel.PRIVATE) @Data @Accessors(fluent = true, chain = true) public class WhatsappKeysManager
	public class WhatsappKeysManager
	{
		/// <summary>
		/// The path used to serialize and deserialize this object
		/// </summary>
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		public static readonly string PREFERENCES_PATH = typeof(WhatsappKeysManager).FullName;

		/// <summary>
		/// An instance of Jackson's writer to serialize this object
		/// </summary>
		private static readonly ObjectWriter JACKSON_WRITER = new ObjectMapper().writer();

		/// <summary>
		/// An instance of Jackson's reader to serialize this object
		/// </summary>
		private static readonly ObjectReader JACKSON_READER = new ObjectMapper().reader();

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @JsonProperty private @NonNull String clientId;
		internal string clientId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @JsonProperty @JsonSerialize(using = it.auties.whatsapp4j.serialization.KeyPairSerializer.class) @JsonDeserialize(using = it.auties.whatsapp4j.serialization.KeyPairDeserializer.class) private @NonNull KeyPair keyPair;
		internal KeyPair keyPair;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @JsonProperty private String serverToken, clientToken;
		private string serverToken, clientToken;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @JsonProperty private it.auties.whatsapp4j.binary.BinaryArray encKey, macKey;
		private BinaryArray encKey, macKey;

		/// <summary>
		/// Constructs an instance of <seealso cref="WhatsappKeysManager"/> using a json value
		/// </summary>
		/// <param name="json"> the encoded json </param>
		/// <returns> a non null <seealso cref="WhatsappKeysManager"/> </returns>
		public static WhatsappKeysManager fromJson(sbyte[] json)
		{
			try
			{
				return JACKSON_READER.readValue(json, typeof(WhatsappKeysManager));
			}
			catch (IOException exception)
			{
				throw new Exception("WhatsappAPI: Cannot deserialize WhatsappKeysManager from %s".formatted(StringHelper.NewString(json)), exception);
			}
		}

		/// <summary>
		/// Constructs an instance of <seealso cref="WhatsappKeysManager"/> using a json value
		/// </summary>
		/// <param name="json"> the encoded json </param>
		/// <returns> a non null <seealso cref="WhatsappKeysManager"/> </returns>
		public static WhatsappKeysManager fromJson(string json)
		{
			return fromJson(json.GetBytes(Encoding.UTF8));
		}

		/// <summary>
		/// Constructs an instance of <seealso cref="WhatsappKeysManager"/> using:
		/// <ul>
		///     <li>The serialized object, saved in the Preferences linked to this machine at <seealso cref="WhatsappKeysManager.PREFERENCES_PATH"/></li>
		///     <li>A new instance constructed using random keys if the previous could not be deserialized</li>
		/// </ul>
		/// </summary>
		/// <returns> a non null <seealso cref="WhatsappKeysManager"/> </returns>
		public static WhatsappKeysManager fromPreferences()
		{
			var preferences = Preferences.userRoot().get(PREFERENCES_PATH, null);
			if (preferences != null)
			{
				return fromJson(preferences);
			}

			return new WhatsappKeysManager(Base64.Encoder.encodeToString(BinaryArray.random(16).data()), CypherUtils.calculateRandomKeyPair(), null, null, null, null);
		}

		/// <summary>
		/// Checks if the serverToken and clientToken are not null
		/// </summary>
		/// <returns> true if both the serverToken and clientToken are not null </returns>
		public virtual bool mayRestore()
		{
			return Objects.nonNull(serverToken) && Objects.nonNull(clientToken);
		}

		/// <summary>
		/// Initializes the serverToken, clientToken, encryptionKey and macKey with non null values
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public void initializeKeys(@NonNull String serverToken, @NonNull String clientToken, @NonNull BinaryArray encKey, @NonNull BinaryArray macKey)
		public virtual void initializeKeys(string serverToken, string clientToken, BinaryArray encKey, BinaryArray macKey)
		{
			this.encKey(encKey).macKey(macKey).serverToken(serverToken).clientToken(clientToken);
			serialize();
		}

		public virtual void serialize()
		{
			try
			{
				Preferences.userRoot().put(PREFERENCES_PATH, JACKSON_WRITER.writeValueAsString(this));
			}
			catch (JsonProcessingException exception)
			{
				throw new Exception("WhatsappAPI: Cannot serialize WhatsappKeysManager to JSON", exception);
			}
		}

		/// <summary>
		/// Clears all the keys from this machine's memory.
		/// This method doesn't clear this object's values.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SneakyThrows public void deleteKeysFromMemory()
		public virtual void deleteKeysFromMemory()
		{
			Preferences.userRoot().clear();
		}
	}
}