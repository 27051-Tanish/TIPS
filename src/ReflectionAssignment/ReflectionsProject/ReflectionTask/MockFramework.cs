using System.Reflection;
using System.Reflection.Emit;
using ReflectionsProject.Interfaces;
using ReflectionsProject.View;

namespace ReflectionsProject.ReflectionTask
{
    /// <summary>
    /// Implement reflection to dynamically generate a mock object
    /// </summary>
    public class MockFramework
    {
        /// <summary>
        /// Uses Reflection to create a dynamic type that implements the interface uses TypeBuilder and MethodBuilder to create a new type
        /// and create corresponding method.
        /// </summary>
        public void ExecuteMockFramework()
        {
            AssemblyName assemblyName = new AssemblyName("MockAssembly");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MockModule");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("MockClass", TypeAttributes.Public | TypeAttributes.Class);

            typeBuilder.AddInterfaceImplementation(typeof(ISampleInterface));
            MethodBuilder methodBuilder = typeBuilder.DefineMethod("Add", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig | MethodAttributes.Virtual, typeof(int), new Type[] { typeof(int), typeof(int) });
            ILGenerator sampleMethodIl = methodBuilder.GetILGenerator();
            sampleMethodIl.Emit(OpCodes.Ldc_I4, 100);
            sampleMethodIl.Emit(OpCodes.Ret);

            MethodInfo? interfaceMethod = typeof(ISampleInterface).GetMethod("Add");
            if (interfaceMethod is not null)
            {
                typeBuilder.DefineMethodOverride(methodBuilder, interfaceMethod);
            }

            Type? mockClass = typeBuilder.CreateType();
            if (mockClass is not null)
            {
                ISampleInterface mockObject = (ISampleInterface)Activator.CreateInstance(mockClass) !;
                int result = mockObject.Add(12, 5);
                ConsoleView.ShowMessage($"Mock result of the method: {result}");
            }
            else
            {
                ConsoleView.ShowMessage("Class not found.");
                return;
            }
        }
    }
}
