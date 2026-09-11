# Task 1 -> Value and Reference Types

- Data is stored into two types, Value type and reference type, where in value type memory location of the variable stored directly on the stack. In reference type, the value is stored in the managed heap, and the pointer to that heap is stored in the stack. 

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

# Task 2 -> Stack vs. Heap Allocation Profiling

- It is the extended version of the task 1, where two methods were created one that creates a large array of integers (a reference type), and
another that performs a calculation with a large number of local variables (value types).
- Used a profiling tool, such as Visual Studio's Diagnostic Tools, to observe how memory is used when these methods are called.

## Features

### 1. Heap Memory Allocation (`CreateLargeArray`)
This method demonstrates how reference types and large objects are allocated on the **Managed Heap**.
* **What it does:** Instantiates an integer array (`int[]`) with **1,000,000 elements**.
* **Memory impact:** In .NET, arrays are reference types. Creating an array of this size allocates approximately **4 Megabytes (MB)** of contiguous memory on the heap (specifically the Large Object Heap if it exceeds the threshold).
* **Observation:** The application pauses using `Console.ReadLine()`, allowing you to inspect the increased heap allocation using tools like Visual Studio Diagnostic Tools, dotnet-dump, or Task Manager.

### 2. Stack Memory Usage (`CalculatingManyVariables`)
This method demonstrates how value types and local execution data are managed on the **Thread Stack**.
* **What it does:** Declares multiple local variables of primitive value types (`int`, `long`, `double`) and performs an arithmetic calculation on them.
* **Memory impact:** Local variables of value types are stored directly on the stack frame of the executing thread. This memory is extremely fast to allocate and is automatically destroyed as soon as the method finishes execution and the stack frame is popped.

## How to Run and Observe

1. Call either `CreateLargeArray()` or `CalculatingManyVariables()` from your `Program.cs` entry point.
2. Run the application in **Debug** or **Release** mode with diagnostic tools enabled.
3. Use a memory profiler to observe:
   * The spike in **Heap Memory** when running `CreateLargeArray()`.

# Task 3 -> Garbage Collection and Performance Impact

- Create a method that creates and destroys a large number of objects in a for loop with large count.
- Observe the memory usage of the application using the diagnostic tool.
- Use GC.Collect to manually trigger garbage collection and observe the impact on memory usage. 

# Task 4 -> Understanding the IDisposable Interface and the 'using' Statement

- Create a new C# Console Application named "IDisposableDemo".

### 1. Resource Management (`using` statement)
The application uses `using` blocks to ensure that unmanaged file resources are safely released.
* **Automatic Disposal:** Both the `FileWriter` and `FileReader` instances are automatically closed and disposed of as soon as execution leaves their respective blocks, preventing file locking issues and memory leaks.

### 2. File Writing (`FileWriter`)
* **What it does:** Opens or creates a file named `SampleFile.txt`.
* **Action:** Writes a test string (`"Hi, this is for testing purpose."`) directly into the file.

### 3. File Reading (`FileReader`)
* **What it does:** Reopens the newly created `SampleFile.txt`.
* **Action:** Reads the raw text data back into memory as a string (`fileData`) and outputs the contents directly to the console.
