# C# Advanced Concepts

### 1. Delegates
* **Definition:** A **type-safe function pointer**. It holds a reference to a method with a specific signature (return type and parameters) so you can pass methods around like variables.
* **Purpose:** It makes your architecture highly dynamic by allowing methods to accept other methods as arguments. You will often use them via C#'s built-in types like `Action`, `Func`, or `Predicate`.

### 2. Events
* **Definition:** A encapsulation layer built on top of delegates that follows the **publisher-subscriber pattern**. It allows an object to notify other objects when a specific action happens.
* **Purpose:** It keeps your code loosely coupled. For example, a button class can fire an `OnClick` event, and other parts of your app can listen and respond without the button needing to know who or what they are.

### 3. Anonymous Functions
* **Definition:** An inline method that **doesn't have a name**. 
* **Purpose:** Introduced early in C#, it allowed you to write a block of code directly inline where a delegate reference was required (using the old `delegate` keyword), saving you from writing an entire standalone method.

### 4. Lambda Expressions
* **Definition:** The modern, clean, and highly readable evolution of anonymous functions using the **`=>` (goes to)** operator.
* **Purpose:** It completely replaced the clunky old anonymous function syntax. It allows you to write incredibly compact inline logic, which is heavily used when querying data with LINQ (e.g., `books.Where(b => b.Price > 10)`).

### 5. Pattern Matching
* **Definition:** A conditional testing feature (introduced in C# 7.0 and upgraded heavily since) that lets you **test a variable's type, shape, or values** and extract data instantly.
* **Purpose:** It eliminates the need for old, messy nested `if/else` checks combined with manual object casting. It makes complex logic (like switching on different shape subclasses) safe, readable, and concise.

### 6. Records
* **Definition:** A specialized class or struct (introduced in C# 9.0) explicitly optimized to **hold data rather than behavior**.
* **Purpose:** They provide built-in **value-based equality** (two separate records with identical data are considered equal) and beautiful auto-generated string printouts out of the box, typically promoting safe, immutable data structures.

---

#### 1. Events and Delegate
* **What it does:** Sends a test message through a notification system. 
* It will print *"This event is triggered..."* on your screen to show that the system successfully sent and received the message.

#### 2. Dynamic and Var
* **What it does:** Shows how C# handles different types of data variables.
* It proves that a `var` variable cannot change its data type once created, while a `dynamic` variable can change from text to a number instantly.

#### 3. Anonymous Methods
* **What it does:** Sorts a random list of scrambled numbers.
* It displays the original messy list of numbers, organizes them from smallest to largest using an inline function, and prints the sorted list.

#### 4. Lambda Expression
* **What it does:** Filters a list of numbers from 1 to 10.
* It takes the list and uses a short shortcut formula (`=>`) to quickly pull out and display only the numbers you need.

#### 5. Advance Delegate
* **What it does:** Sorts a list of store products (like Watch, Phone, Bike).
* It chains multiple sorting rules together. It will automatically show you the products sorted first by their **Name**, then by their **Category**, and finally by their **Price**.

#### 6. Record Task
* **What it does:** Manages a collection of books.
* It checks if two different books with the same text are identical. It also creates a copy of a book with a new author name without changing the original book data.

#### 7. Pattern Matching
* **What it does:** Calculates the area of different geometric shapes (Circles, Rectangles, Triangles).
* It safely figures out which shape is which automatically. If a triangle is way too big to calculate, it catches the error safely so the program does not crash.

#### 8. Exit
* **What it does:** Closes the application.
* The program will stop running and close down safely.

---
