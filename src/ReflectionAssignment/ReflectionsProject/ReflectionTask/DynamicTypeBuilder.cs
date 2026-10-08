using System.Reflection;
using System.Reflection.Emit;
using ReflectionsProject.View;

namespace ReflectionsProject.ReflectionTask
{
    /// <summary>
    /// Provides method that create a dynamic type builder that can define a new class at runtime, with properties and methods defined by the user.
    /// </summary>
    public class DynamicTypeBuilder
    {
        /// <summary>
        /// Creates an assembly, module, and type dynamically at runtime using System.Reflection.Emit.
        /// </summary>
        public void ExecuteDynamicTypeBuilder()
        {
            AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("DynamicStudent", TypeAttributes.Public);
            FieldBuilder fieldBuilder = typeBuilder.DefineField("_name", typeof(string), FieldAttributes.Private);
            PropertyBuilder propertyBuilder = typeBuilder.DefineProperty("Name", PropertyAttributes.HasDefault, typeof(string), null);

            MethodAttributes getSetAttributes = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;
            MethodBuilder getMethod = typeBuilder.DefineMethod("get_Name", getSetAttributes, typeof(string), Type.EmptyTypes);
            ILGenerator getIl = getMethod.GetILGenerator();
            getIl.Emit(OpCodes.Ldarg_0); // Load 'this' pointer onto evaluation stack.
            getIl.Emit(OpCodes.Ldfld, fieldBuilder); // Load the value of the private backing field.
            getIl.Emit(OpCodes.Ret); // Return the value.

            MethodBuilder setMethod = typeBuilder.DefineMethod("set_Name", getSetAttributes, null, new Type[] { typeof(string) });
            ILGenerator setIl = setMethod.GetILGenerator();
            setIl.Emit(OpCodes.Ldarg_0); // Load 'this' pointer.
            setIl.Emit(OpCodes.Ldarg_1); // Load the incoming string parameter value.
            setIl.Emit(OpCodes.Stfld, fieldBuilder); // Store the incoming value into the private backing field.
            setIl.Emit(OpCodes.Ret); // Return void.
            propertyBuilder.SetGetMethod(getMethod);
            propertyBuilder.SetSetMethod(setMethod);

            ConsoleView.ShowMessage("Successfully added Property: string Description [get; set;]");
            MethodBuilder displayName = typeBuilder.DefineMethod("Display", MethodAttributes.Public, typeof(void), Type.EmptyTypes);
            ILGenerator displayIl = displayName.GetILGenerator();
            MethodInfo showMessageMethod = typeof(ConsoleView).GetMethod("ShowMessage", new Type[] { typeof(string) }) !;
            displayIl.Emit(OpCodes.Ldstr, "Hi this is display method.");
            displayIl.Emit(OpCodes.Call, showMessageMethod);
            displayIl.Emit(OpCodes.Ret);

            Type? dynamicType = typeBuilder.CreateType();
            object? obj = Activator.CreateInstance(dynamicType);
            PropertyInfo? property = dynamicType.GetProperty("Name");
            property.SetValue(obj, "Havana");
            object? value = property.GetValue(obj);
            ConsoleView.ShowMessage($"Name: {value}");

            MethodInfo? callMethod = dynamicType.GetMethod("Display");
            callMethod.Invoke(obj, null);
        }
    }
}
