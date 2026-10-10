using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using ReflectionsProject.SampleClasses;

namespace ReflectionsProject.ReflectionTask
{
    /// <summary>
    /// Implements a simple serialization API using Reflection and then identify its limitations and rewrite it using Reflection.Emit.
    /// </summary>
    public class SerializationApi
    {
        /// <summary>
        /// Returns the value of the properties of the type.
        /// </summary>
        /// <param name="student">The instance of the class which needs to be serialized.</param>
        /// <returns>The value of the properties.</returns>
        public string Serialize(Student student)
        {
            Type type = student.GetType();
            PropertyInfo[] properties = type.GetProperties();

            string? result = " ";

            foreach (PropertyInfo property in properties)
            {
                object? value = property.GetValue(student, null);
                if (value != null)
                {
                    result += $"{property.Name}: {value}\n";
                }
            }

            return result;
        }

        /// <summary>
        /// Dynamically generates and compiles a native serialization delegate 
        /// that bypasses runtime reflection by unrolling properties directly into IL.
        /// </summary>
        /// <returns>
        /// A delegate that accepts an object and returns its serialized string representation.
        /// </returns>
        public Func<object, string> CreateSerializer()
        {
            Type targetType = typeof(Student);

            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("DynamicAssembly"), AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("DynamicSerializer_" + targetType.Name);

            MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                "CreateSerialize",
                MethodAttributes.Public | MethodAttributes.Static,
                typeof(string),
                new Type[] { typeof(object) });

            ILGenerator il = methodBuilder.GetILGenerator();

            // Declare local variable 0: StringBuilder sb
            il.DeclareLocal(typeof(StringBuilder));

            // sb = new StringBuilder(" ");
            il.Emit(OpCodes.Ldstr, " ");
            il.Emit(OpCodes.Newobj, typeof(StringBuilder).GetConstructor(new[] { typeof(string) })!);
            il.Emit(OpCodes.Stloc_0);

            PropertyInfo[] properties = targetType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {
                if (!property.CanRead)
                {
                    continue;
                }

                // 1. Load StringBuilder onto stack
                il.Emit(OpCodes.Ldloc_0);

                // 2. Load "PropertyName: " onto stack
                il.Emit(OpCodes.Ldstr, $"{property.Name}: ");
                il.Emit(OpCodes.Callvirt, typeof(StringBuilder).GetMethod("Append", new[] { typeof(string) })!);
                il.Emit(OpCodes.Pop); // Clear return value of intermediate Append

                // 3. Load StringBuilder for the property value append
                il.Emit(OpCodes.Ldloc_0);

                // 4. Load incoming object argument, cast to Student type, and get property value
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Castclass, targetType);
                il.Emit(OpCodes.Callvirt, property.GetGetMethod()!);

                // 5. Append matching value type natively to prevent boxing penalties
                MethodInfo appendMethod = typeof(StringBuilder).GetMethod("Append", new[] { property.PropertyType })
                                          ?? typeof(StringBuilder).GetMethod("Append", new[] { typeof(object) })!;

                if (appendMethod.GetParameters()[0].ParameterType == typeof(object) && property.PropertyType.IsValueType)
                {
                    il.Emit(OpCodes.Box, property.PropertyType); // Box fallback for missing native overloads
                }

                il.Emit(OpCodes.Callvirt, appendMethod);
                il.Emit(OpCodes.Pop);
                il.Emit(OpCodes.Ldloc_0);
                il.Emit(OpCodes.Ldstr, "\n");
                il.Emit(OpCodes.Callvirt, typeof(StringBuilder).GetMethod("Append", new[] { typeof(string) })!);
                il.Emit(OpCodes.Pop);
            }

            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Callvirt, typeof(object).GetMethod("ToString")!);
            il.Emit(OpCodes.Ret);

            Type? dynamicType = typeBuilder.CreateType();
            MethodInfo? methodInfo = dynamicType!.GetMethod("CreateSerialize");

            return (Func<object, string>)methodInfo!.CreateDelegate(typeof(Func<object, string>));
        }
    }
}
