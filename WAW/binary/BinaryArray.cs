using System;
using System.Linq;

using Pair = it.auties.whatsapp4j.utils.internal.Pair;
using NonNull = lombok.NonNull;
using Hex = org.bouncycastle.util.encoders.Hex;

namespace it.auties.whatsapp4j.binary
{

	/// <summary>
	/// A utility class that wraps an array of bytes
	/// It provides an easy interface to modify said data, convert it or generate it
	/// This is intended to only be used for WhatsappWeb's WebSocket binary operations
	/// </summary>
	public virtual record BinaryArray(sbyte[] data)
	{
		/// <summary>
		/// Constructs a new empty {@code BinaryArray}
		/// </summary>
		/// <returns> a new {@code BinaryArray} wrapping an empty bytes array </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public static @NonNull BinaryArray empty()
		public static BinaryArray empty()
		{
			return forArray(new sbyte[0]);
		}

		/// Constructs a new {@code BinaryArray} wrapping {<param name="in">}
		/// </param>
		/// <param name="in"> the array of bytes to wrap </param>
		/// <returns> a new {@code BinaryArray} wrapping {@code in} </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public static @NonNull BinaryArray forArray(byte[] in)
		public static BinaryArray forArray(sbyte[] @in)
		{
			return new BinaryArray(@in);
		}

		/// <summary>
		/// Constructs a new non empty {@code BinaryArray}
		/// </summary>
		/// <param name="in"> the byte to wrap </param> </returns>
		/// <returns> a new non empty {@code BinaryArray} wrapping a bytes array that only contains {<param name="in">} </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public static @NonNull BinaryArray singleton(byte in)
		public static BinaryArray singleton(sbyte @in)
		{
			return new BinaryArray(new sbyte[]{@in});
		}

		/// <summary>
		/// Constructs a new {@code BinaryArray} wrapping the array of bytes representing a UTF-8 string
		/// </summary>
		/// <param name="in"> the String to wrap </param> </returns>
		/// <returns> a new {@code BinaryArray} wrapping {<param name="in">} </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public static @NonNull BinaryArray forString(@NonNull String in)
		public static BinaryArray forString(string @in)
		{
			return forArray(@in.Bytes);
		}

		/// <summary>
		/// Constructs a {@code BinaryArray} wrapping the array of bytes representing a Base64 encoded String in UTF-8 format
		/// </summary>
		/// <param name="input"> the Base64 encoded String to wrap </param> </returns>
		/// <returns> a new {@code BinaryArray} wrapping {<param name="input">} </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public static @NonNull BinaryArray forBase64(@NonNull String input)
		public static BinaryArray forBase64(string input)
		{
			return forArray(Base64.Decoder.decode(input));
		}

		/// Constructs a {@code BinaryArray} wrapping a generated array of {<param name="length"> }pseudo random bytes
		/// </param>
		/// <param name="length"> the length of the array to generate and wrap </param> </returns>
		/// <returns> a new {@code BinaryArray} of length {<param name="length">} </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public static @NonNull BinaryArray random(int length)
		public static BinaryArray random(int length)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final var result = new byte[length];
			var result = new sbyte[length];
			(new SecureRandom()).NextBytes(result);
			return forArray(result);
		}

		/// <summary>
		/// Constructs a new {@code BinaryArray} wrapping this object's bytes array sliced from
		/// 0, inclusive </summary>
		/// {<param name="end">}, exclusive
		/// </param>
		/// <param name="end"> the exclusive index used to slice this object's bytes array </param>
		/// <returns> a new {@code BinaryArray} with the above characteristics </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull BinaryArray cut(int end)
		public BinaryArray cut(int end)
		{
			return slice(0, end);
		}

		/// <summary>
		/// Constructs a new {@code BinaryArray} wrapping this object's bytes array sliced from </summary>
		/// {<param name="start">}, inclusive
		/// this object's bytes array size, exclusive
		/// </param>
		/// <param name="start"> the inclusive index used to slice this object's bytes array </param>
		/// <returns> a new {@code BinaryArray} with the above characteristics </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull BinaryArray slice(int start)
		public BinaryArray slice(int start)
		{
			return slice(start, data.Length);
		}

		/// Constructs a {@code Pair} of two {@code BinaryArray} obtained by splitting this object's bytes array at {<param name="split">}
		/// </param>
		/// <param name="split"> the index to split this object's array </param>
		/// <returns> a Pair with the above characteristics </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull Pair<BinaryArray, BinaryArray> split(int split)
		public Pair<BinaryArray, BinaryArray> split(int split)
		{
			return new Pair<>(cut(split), slice(split + 1));
		}

		/// <summary>
		/// Returns a new {@code BinaryArray} wrapping this object's bytes array sliced from </summary>
		/// {<param name="start">}, inclusive </param>
		/// {<param name="end">}, exclusive
		/// </param>
		/// <param name="start"> the inclusive starting index used to slice this object's bytes array </param>
		/// <param name="end">   the exclusive ending index used to slice this object's bytes array </param>
		/// <returns> a new {@code BinaryArray} with the above characteristics </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull BinaryArray slice(int start, int end)
		public BinaryArray slice(int start, int end)
		{
			return forArray(Arrays.CopyOfRange(data, start >= 0 ? start : size() + start, end >= 0 ? end : size() + end));
		}

		/// Constructs a new {@code BinaryArray} by concatenating this object and {<param name="array">}
		/// </param>
		/// <param name="array"> the {@code BinaryArray} to concatenate </param> </returns>
		/// <returns> a new {@code BinaryArray} wrapping a bytes array obtained by concatenating this object's bytes array and {<param name="array">}'s bytes array </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull BinaryArray merged(@NonNull BinaryArray array)
		public BinaryArray merged(BinaryArray array)
		{
			var result = Arrays.CopyOf(data, size() + array.size());
			Array.Copy(array.data, 0, result, size(), array.size());
			return forArray(result);
		}

		/// Returns the index within this object's bytes array of the first occurrence of a byte that matches {<param name="character">}
		/// If this condition is met, a non empty Optional wrapping said index is returned
		/// Otherwise, an empty Optional is returned
		/// </param>
		/// <param name="character"> the character to search </param>
		/// <returns> an Optional wrapping an int with the above characteristics </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull Optional<int> indexOf(char character)
		public int? indexOf(char character)
		{
			return Enumerable.Range(0, size()).Where(index => data[index] == character).boxed().First();
		}

		/// <summary>
		/// Returns the byte value at the specified index for this object's bytes array
		/// </summary>
		/// <param name="index"> the index, ranges from 0 to size() - 1 </param> </returns>
		/// <returns> the byte at {<param name="index">} </param>
		public sbyte at(int index)
		{
			return data[index];
		}

		/// <summary>
		/// Returns the size of the array of bytes that this object wraps
		/// </summary>
		/// <returns> an unsigned int representing the size of the array of bytes that this object wraps </returns>
		public int size()
		{
			return data.Length;
		}

		/// <summary>
		/// Constructs a new ByteBuffer from this object's array of bytes
		/// </summary>
		/// <returns> an ByteBuffer with the above characteristics </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull ByteBuffer toBuffer()
		public ByteBuffer toBuffer()
		{
			return ByteBuffer.wrap(data);
		}

		/// <summary>
		/// Constructs a new hex from this object's array of bytes
		/// </summary>
		/// <returns> a String with the above characteristics </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull String toHex()
		public string toHex()
		{
			return Hex.toHexString(data);
		}

		/// Checks if this object and {<param name="o">} are equal
		/// </param> </returns>
		/// <returns> true if {<param name="o">} is an instance of {@code BinaryArray} and if they wrap two arrays considered equal </param>
		public bool Equals(object o)
		{
			return o is BinaryArray that && data.SequenceEqual(that.data);
		}

		/// <summary>
		/// Constructs a UTF-8 encoded String using this object's array of bytes
		/// </summary>
		/// <returns> a String with the above characteristics </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override public @NonNull String toString()
		string ToString()
		{
			return new string(data(), StandardCharsets.UTF_8);
		}
	}
}