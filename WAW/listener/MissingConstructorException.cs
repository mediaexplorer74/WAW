using System;

namespace it.auties.whatsapp4j.listener
{
	using NonNull = lombok.NonNull;

	/// <summary>
	/// An exception used to signal that a constructor for a specific class with specific characteristics cannot be found.
	/// This is an unchecked exception as it extends <seealso cref="System.Exception"/>.
	/// Unchecked exceptions do not need to be declared in a throws clause.
	/// </summary>
	public class MissingConstructorException : Exception
	{
		/// <summary>
		/// Constructs a new missing constructor exception with a not null message formatted using the args parameter
		/// </summary>
		/// <param name="message"> the exception's message </param>
		/// <param name="args">    the arguments used to format the message </param>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public MissingConstructorException(@NonNull String message, Object... args)
		public MissingConstructorException(string message, params object[] args) : base(message.formatted(args))
		{
		}
	}

}