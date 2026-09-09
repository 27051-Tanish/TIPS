# Understanding the .NET platform

* Created a separate class called `MathUtils` inside Utils folder which has different methods for performing mathematical operations.
* Each method take integer parameters and return the calculated value.
* Created a static class that handles input and displays messages.
* Prompt the user to enter the two numbers and call all the methods for displaying the results.

## Answers to the exploration topics

### 1. Explain what the .NET platform is and its primary purpose. 

- .NET is a free, open-source, cross-platform developer platform created by Microsoft for building many different types of applications.
- The main purpose of the modern .NET is to provide universally single environment to develop applications
where developers can write code in different languages such as C# and F#, etc. 
- It is used to build specific application types using dedicated frameworks:
  - Desktop: Use WinForms or Windows Presentation Foundation (WPF) to build Windows desktop applications.
  - Web: Use ASP.NET Core to build web applications, HTTP APIs, and microservices.
  - Mobile: Use .NET MAUI (or Xamarin) to build cross-platform mobile apps for iOS and Android.

- (Note: Avoid confusing this with the legacy .NET Framework, which was a closed-source, Windows-only platform discontinued after version 4.8).
---

### 2. What are the key components of the .NET platform? 

-  The .NET platform has various key components available, such as CLR, CIL, CTS, Class library, Just-In-Time Compiler.

     - **CLR** -> CLR stands for Common Language Runtime, it is the execution environment for .NET applications. 
     It is not exclusive for C# it manages all the programs that runs under .NET.

     - **CIL** -> CIL stands for Common Intermediate Language. Source code written in languages like C# or F# is compiled ahead of time by the language compiler (such as Roslyn) 
     into this intermediate binary format, which is packaged inside the assembly (.dll or .exe).

     - **CTS** -> CTS stands for Common Type System; it defines how data types are declared, represented and used in .NET. 
     It classifies how data is stored into two types of Value type and reference type,
        * **Value Types**: Contain the actual data. They live on the stack *only* when declared as local variables or method parameters. If they are declared as fields inside a class (a reference type),
          they live on the managed heap alongside the parent object.
        * **Reference Types**: Store a reference (pointer) to the actual data. The object data itself is always allocated on the managed heap, while the variable containing the pointer typically lives on the stack.

     - **Class Library** -> .NET provides a large collection of reusable classes, methods, interfaces, namespaces etc.

     - **JIT** -> JIT stands for Just-In-Time compiler; It takes the pre-compiled CIL binary from the assembly at runtime and translates it into native machine-readable code tailored specifically for the host processor architecture right as the application executes.

---

### 3. Differentiate between the Common Language Runtime (CLR) and the Common Type System (CTS) in .NET. 

The primary differences between these components are,

| Component |  Primary Role |
| :--- | :--- | :--- | :--- |
| **CLR** *(Common Language Runtime)* | Physically runs and manages code execution, memory allocation, threads, and garbage collection at runtime. |
| **CTS** *(Common Type System)* |  Defines the structural blueprints, data categories (value vs. reference), and behaviors for it defines how data types are declared, represented and used in .NET. |
| **CLS** *(Common Language Specification)* |   **Subset of the CTS Specification** (Interop Rules), Defines a baseline agreement of features that all .NET languages must support to guarantee seamless cross-language communication. A feature available in C# might not exist in F#. The CLS acts as a "common denominator" ruleset. If your code sticks strictly to CLS rules, it guarantees that any other .NET language can use your code without errors.|

---

### 4. What is the role of the Global Assembly Cache (GAC) in .NET? 

- The global assembly cache in .NET is a machine-wide central repository in the legacy .NET Framework used to store and share different .NET assemblies that is compiled unit of .NET code commonly .dll and .exe across multiple application in the computer.
Incase several applications use same shared library, instead each application having individual copy an assembly can be installed in the GAC and shared among the applications. 
- If twenty different applications installed on a server all require a specific corporate logging or database library, putting that library into the GAC means it only needs to be stored on the hard drive once.
- (Note: Modern .NET Core, .NET 5, 6, 7, 8, and 9 have completely abandoned the GAC).

---

### 5. Explain the difference between value types and reference types in C#. 

- Data is stored into two types, Value type and reference type, where in value type memory location of the variable stored directly on the stack. In reference type, the value is stored in the managed heap, and the pointer to that heap is stored in the stack. 

   - **Value type**: contains a value, and the variable contains the value stored directly on the stack. Different data types such as int, double, decimal, float, bool, and char are examples of value type.
   - If they are declared as fields inside a class (a reference type),
   they live on the managed heap alongside the parent object.
   - When you assign one value type to another, C# duplicates the actual data. Modifying the new copy has zero effect on the original variable.
        
        ```csharp
        int a = 10;
        int b = a; // Copying the actual value '10'
        b = 20;    // Changing 'b' does NOT change 'a'
        ```

   - **Reference type**: Contains a reference (pointer) to the actual data. The data itself is allocated directly on the managed heap, while the variable containing the pointer typically lives on the stack. Examples include classes, strings, arrays, interfaces, and delegates. 
   - (*Note:* Boxing only occurs when a value type is cast or converted into a reference type, such as storing an `int` inside an `object`).
       ```csharp
       public class Player { public int Score; }
       Player player1 = new Player { Score = 10 };
       Player player2 = player1; // Copying the reference/pointer
       player2.Score = 20;       // Changing 'player2' directly alters 'player1'
       ```
---

### 6. Describe the concept of garbage collection on .NET and its advantages.

- Garbage collection in .NET is an automatic memory manager that handles the allocation and release of memory for your application’s managed heap. It inspects the heap in the background and when it finds the object that the application no longer uses, it detects and deletes them to free up space.
Developers don't need to clean space manually by writing code. It also performs optimized memory allocation for better performance; also unused objects are removed.
- Optimized Execution: Modern .NET garbage collectors run concurrently on background threads. This means memory cleanup happens silently without freezing your application's user interface.

#### 1. The Three Generations (Ephemeral & Long-Lived Heap)
The managed heap is split into three generations to leverage the statistical fact that newer objects tend to have very short lifespans:
* **Generation 0 (Gen 0)**: The youngest generation. It contains short-lived objects like local variables created inside a method. Gen 0 collections are extremely frequent and cheap because they only inspect a small, highly volatile area of memory.
* **Generation 1 (Gen 1)**: Acts as a buffer zone. Objects that survive a Gen 0 collection are promoted to Gen 1. 
* **Generation 2 (Gen 2)**: Contains long-lived objects, such as static data or singleton services. Collections here are expensive because the GC must scan a significantly larger pool of memory.

#### 2. The Large Object Heap (LOH)
* Objects that are **85,000 bytes or larger** (typically large arrays or massive strings) bypass Gen 0 entirely and are allocated directly on a separate area called the **Large Object Heap (LOH)**. 
* The LOH is treated as part of Generation 2 because copying massive blocks of data around memory is incredibly expensive to the CPU.

#### 3. Compaction vs. Sweep
* **Compaction**: During a collection of small objects (Gen 0/1), surviving items are shifted closer together in memory. This eliminates fragmentation and ensures that future allocations can happen almost instantaneously at the top of the heap.
* **LOH Behavior**: Because moving huge objects wastes CPU cycles, the LOH is historically *swept* (marked as free space) rather than compacted, though modern .NET allows configuration to compact it if fragmentation gets severe.

---

### 7. What is the purpose of the Globalization and Localization features in .NET?

- Developing world ready application, including an application that can be localized into one or more languages. **Globalization** involves designing and coding an application that is culture-neutral, 
supports multiple culture and regions, handling differences in date, time, number, and currency formatting and that supports localized user interface and regional data for all users. 
- **Localization** involves customizing an application for specific cultures and regions that is adapting a globalized app for a specific locale by changing UI text into target language.

![Snapshot 1](Screenshots/Screenshot%202026-09-02%20125746.png)

---

### 8. Explain the role of the Common Intermediate Language (CIL) and Just-In-Time (JIT) compilation in the .NET framework. 

- Common Intermediate Language, each program written in a different programming language in the .NET framework is compiled into this intermediate language before translating into binary in the runtime by JIT compiler. 
Just-In-Time compiler; it is used to translate the intermediate language into the machine-readable binary code that is used by the processor to execute the program.

- The computer does not directly execute the C# program. It undergoes some process the C# compiler compiles the source code into intermediate language (CIL). 
After that when the application runs, the JIT compiler converts the required CIL into native machine code suitable for the current platform.

---

