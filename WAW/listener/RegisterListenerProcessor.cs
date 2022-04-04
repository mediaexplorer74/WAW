using System;
using System.Collections.Generic;

namespace it.auties.whatsapp4j.listener
{
	using NonNull = lombok.NonNull;
	using SneakyThrows = lombok.SneakyThrows;
	using UtilityClass = lombok.experimental.UtilityClass;


	/// <summary>
	/// A utility class to find all classes annotated with <seealso cref="RegisterListener"/>.
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @UtilityClass public class RegisterListenerProcessor
	public class RegisterListenerProcessor
	{
		/// <summary>
		/// An instance of the class loader, used to query all candidate classes
		/// </summary>
		private readonly ClassLoader CLASS_LOADER = ClassLoader.SystemClassLoader;

		/// <summary>
		/// An instance of Java's File Manager, used to load all the candidate classes and validate them
		/// </summary>
		private readonly StandardJavaFileManager FILE_MANAGER = ToolProvider.SystemJavaCompiler.getStandardFileManager(null, Locale.Default, StandardCharsets.UTF_8);

		/// <summary>
		/// The target location for Java's File Manager
		/// </summary>
		private readonly StandardLocation CLASS_LOCATION = StandardLocation.CLASS_PATH;

		/// <summary>
		/// Queries all classes annotated with <seealso cref="RegisterListener"/> and initializes them using a no args constructor
		/// </summary>
		/// <returns> a list of <seealso cref="WhatsappListener"/> </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull List<WhatsappListener> queryAllListeners()
		public virtual IList<WhatsappListener> queryAllListeners()
		{
//JAVA TO C# CONVERTER TODO TASK: Method reference arbitrary object instance method syntax is not converted by Java to C# Converter:
			return Arrays.stream(CLASS_LOADER.DefinedPackages).flatMap(RegisterListenerProcessor::findClassesInPackage).filter(RegisterListenerProcessor::isListener).map(RegisterListenerProcessor::cast).map(RegisterListenerProcessor::newInstance).toList();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SneakyThrows private @NonNull Stream<Class> findClassesInPackage(@NonNull Package pack)
		internal virtual Stream<Type> findClassesInPackage(Package pack)
		{
//JAVA TO C# CONVERTER TODO TASK: Method reference arbitrary object instance method syntax is not converted by Java to C# Converter:
			return StreamSupport.stream(FILE_MANAGER.list(CLASS_LOCATION, pack.Name, ISet<object>.of(JavaFileObject.Kind.CLASS), true).spliterator(), true).map(RegisterListenerProcessor::loadClassFromFile).filter(Optional.isPresent).map(Optional.get);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private @NonNull Optional<Class> loadClassFromFile(@NonNull JavaFileObject file)
		private Optional<Type> loadClassFromFile(JavaFileObject file)
		{
			try
			{
				return Type.GetType(FILE_MANAGER.inferBinaryName(CLASS_LOCATION, file), false, CLASS_LOADER);
			}
			catch (Exception error) when (error is ClassNotFoundException || error is NoClassDefFoundError)
			{
				return null;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private boolean isListener(@NonNull Class clazz)
		private bool isListener(Type clazz)
		{
			return clazz.isAnnotationPresent(typeof(RegisterListener));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private @NonNull Class cast(@NonNull Class clazz)
		private Type cast(Type clazz)
		{
			try
			{
				return clazz.asSubclass(typeof(WhatsappListener));
			}
			catch (System.InvalidCastException)
			{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
				throw new Exception("WhatsappAPI: Cannot initialize class %s, classes annotated with @RegisterListener should implement WhatsappListener".formatted(clazz.FullName));
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private @NonNull WhatsappListener newInstance(@NonNull Class clazz)
		private WhatsappListener newInstance(Type clazz)
		{
			try
			{
				return clazz.DeclaredConstructor.newInstance();
			}
			catch (Exception operationException) when (operationException is IllegalAccessException || operationException is InstantiationException || operationException is InvocationTargetException || operationException is NoSuchMethodException)
			{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
				throw new Exception("WhatsappAPI: Cannot initialize class %s".formatted(clazz.FullName), operationException);
			}
		}
	}

}