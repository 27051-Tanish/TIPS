# Understanding the .NET platform

* Created a separate class called `MathUtils` inside Utils folder which has different methods for performing mathematical operations.
* Each methods take integer parameters and return the calculated value.
* Created a static class for getting input and displaying message.
* Prompt the user to enter the two numbers and call all the methods for displaying the results.

## Exploration topic's answers

1. Explain what the .NET platform is and its primary purpose. 

- Ans: .NET is a free open-source, cross-platform created by Microsoft for different types of applications.
- The main purpose of the .NET framework is to provide universally single environment to develop applications
where developers can write code in different languages such as C# and F#, etc. 
- It is used to build various types of applications such as WinForms, Windows Presentation Foundations (WPF) for developing web applications, mobile, desktop applications, and cloud and gaming applications.

---

2. What are the key components of the .NET platform? 

- Ans: The .NET platform has various key components available, such as CLR, CIL, CTS, Class library, Just-In-Time Compiler.

     - **CLR** -> CLR stands for Common Language Runtime, it is the execution environment for .NET applications. 
     It is not exclusive for C# it manages all the programs that runs under .NET.

     - **CIL** -> CIL stands for Common Intermediate Language, each program written in different programming language is compiled into this intermediate language 
     before translating into binary in the runtime by JIT compiler.

     - **CTS** -> CTS stands for Common Type System; it defines how data types are declared, represented and used in .NET. 
     It classifies how data is stored into two types of Value type and reference type, where in value type memory location of the variable stored directly on the stack. 
     In reference type, the value is stored in the managed heap, and the pointer to that heap is stored in the stack.

     - **Class Library** -> .NET provides a large collection of reusable classes, methods, interfaces, namespaces etc.

     - **JIT** -> JIT stands for Just-In-Time compiler; it is used to translate the intermediate language into the machine-readable binary code that is used by the processor to execute the program. 

---

3. Differentiate between the Common Language Runtime (CLR) and the Common Type System (CTS) in .NET. 

- Ans: CLR -> Common Language Runtime is the execution environment for .NET applications. It is not exclusive for C# it manages all the programs that runs under .NET. 
It is responsible for managing memory, exception handling, dealing with threads, garbage collection, and executing code. 

- CTS -> CTS stands for Common Type System; it defines how data types are declared, represented and used in .NET. 
It classifies how data is stored into two types of Value type and reference type, where in value type memory location of the variable stored directly on the stack. 
In reference type, the value is stored in the managed heap, and the pointer to that heap is stored in the stack.

---

4. What is the role of the Global Assembly Cache (GAC) in .NET? 

- Ans: The global assembly cache in .NET is a machine-wide central repository in the .NET platform used to store and share different .NET assemblies that is compiled unit of .NET code commonly .dll and .exe across multiple application in the computer.
Incase several applications use same shared library, instead each application having individual copy an assembly can be installed in the GAC and shared among the applications. 
- If twenty different applications installed on a server all require a specific corporate logging or database library, putting that library into the GAC means it only needs to be stored on the hard drive once.
- (Note: Modern .NET Core, .NET 5, 6, 7, 8, and 9 have completely abandoned the GAC).

---

5. Explain the difference between value types and reference types in C#. 

- Ans: Data is stored into two types, Value type and reference type, where in value type memory location of the variable stored directly on the stack. In reference type, the value is stored in the managed heap, and the pointer to that heap is stored in the stack. 

   - **Value type**: contains a value, and the variable contains the value stored directly on the stack. Different data types such as int, double, decimal, float, bool, and char are examples of value type. 
   - When you assign one value type to another, C# duplicates the actual data. Modifying the new copy has zero effect on the original variable.
        ```csharp
        int a = 10;
        int b = a; // Copying the actual value '10'
        b = 20;    // Changing 'b' does NOT change 'a'
        ```

   - **Reference type**: contains a reference to an object. Reference types are stored in the heap; A pointer to that heap is stored in the stack.
   Example: class, string, array, interface, and delegate. When storing reference type object, it basically undergoes boxing which means the value type is converted into reference type and when we want to retrieve it performs an explicit process of converting that reference type into a value type by unboxing. 
       ```csharp
       public class Player { public int Score; }
       Player player1 = new Player { Score = 10 };
       Player player2 = player1; // Copying the reference/pointer
       player2.Score = 20;       // Changing 'player2' directly alters 'player1'
       ```
---

6. Describe the concept of garbage collection on .NET and its advantages.

- Ans: Garbage collection in .NET is an automatic memory manager that handles the allocation and release of memory for your application’s managed heap. It inspects the heap in the background and when it finds the object that the application no longer uses, it detects and deletes them to free up space.
Developers don't need to clean space manually by writing code. It also performs optimized memory allocation for better performance; also unused objects are removed.
- Optimized Execution: Modern .NET garbage collectors run concurrently on background threads. This means memory cleanup happens silently without freezing your application's user interface.

---

7. What is the purpose of the Globalization and Localization features in .NET?

- Ans: Developing world ready application, including an application that can be localized into one or more languages. **Globalization** involves designing and coding an application that is culture-neutral, 
supports multiple culture and regions, handling differences in date, time, number, and currency formatting and that supports localized user interface and regional data for all users. 
- **Localization** involves customizing an application for specific cultures and regions that is adapting a globalized app for a specific locale by changing UI text into target language.

![Alt text](C:\Users\Tanish.raffi\source\repos\TIPS\src\Understanding.NET\Screenshots\Screenshot 2026-09-02 125746.png)

---

8. Explain the role of the Common Intermediate Language (CIL) and Just-In-Time (JIT) compilation in the .NET framework. 

- Ans: Common Intermediate Language, each program written in a different programming language in the .NET framework is compiled into this intermediate language before translating into binary in the runtime by JIT compiler. 
Just-In-Time compiler; it is used to translate the intermediate language into the machine-readable binary code that is used by the processor to execute the program.

- The computer does not directly execute the C# program. It undergoes some process the C# compiler compiles the source code into intermediate language (CIL). 
After that when the application runs, the JIT compiler converts the required CIL into native machine code suitable for the current platform.

---

