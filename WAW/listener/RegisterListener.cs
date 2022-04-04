namespace it.auties.whatsapp4j.listener
{
	using WhatsappAPI = it.auties.whatsapp4j.whatsapp.WhatsappAPI;


	/// <summary>
	/// An annotation used to specify that a <seealso cref="WhatsappListener"/> should be dected automatically by <seealso cref="WhatsappAPI"/>.
	/// For this annotation to be recognized, the target class should implement <seealso cref="WhatsappListener"/> and provide a no argument constructor.
	/// If any of those conditions aren't met, a <seealso cref="System.Exception"/> will be thrown.
	/// In order for <seealso cref="WhatsappAPI"/> to autodetect listeners remeber to call <seealso cref="WhatsappAPI.autodetectListeners()"/>.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class RegisterListener : System.Attribute
	{
	}

}