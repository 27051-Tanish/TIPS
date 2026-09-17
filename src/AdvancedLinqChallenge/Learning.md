# Advanced LINQ Challenges in C#

- LINQ (Language Integrated Query) is a powerful feature in Microsoft .NET languages (like C#, VB.NET, and F#) that embeds data querying capabilities directly into the programming language syntax.
- Developers lean heavily on LINQ because it transforms data manipulation from a series of manual steps into clean declarations.

## Key Execution Concept: 

Deferred vs. Immediate ExecutionOne of LINQ’s design mechanics is Deferred Execution. Creating a query variable (var budgetItems = ...) does not filter the collection right away. It only saves the logic template. The actual data extraction runs only when you iterate over it (e.g., in a foreach loop).

### Task 1: Basic LINQ queries

- Filter products under the category "Electronics" with a price greater than $500 and select only ProductName and Price. 
- Using the result of the previous query, sort these filtered products in descending order of price. 
- Calculate the average price of these filtered products. 

### Task 2: Complex LINQ Queries

- Grouped products by category and count the products in each category, where each group has the most expensive product in that category.
- Implemented an inner join with a List<Supplier>, where Supplier is a class with properties SupplierId, SupplierName, and ProductId, to match products with their suppliers.

### Task 3: LINQ to Objects

- Created a static array with assigned values, which is used to find the second largest element in the array using LINQ query.
- Also implemented the LINQ query to find all the unique pairs of numbers in the array that add up to a specified target.

### Task 4: Performance Considerations with LINQ

- From the List<Product>, wrote two LINQ queries:
  - One that selects all products under the category "Books" and sorts them by price. 
  - Here, it is not an optimized approach because, Instead of sorting the entire list and then filtering the required products, here we can first filter the products and then we can sort only the filtered products rather than iterating through the list for two times here we only do that one single time.


### Task 5: Query Builder

- Created a query builder that implements two tightly interwoven design patterns: the Query Builder Pattern and a Fluent API.

   #### The Query Builder Pattern

	- The Builder pattern is a software design pattern meant to construct a complex object step-by-step.A Query Builder specifically isolates the messy logic of generating database queries or complex collection filters away from the core business logic.

   #### What makes it a "Fluent API"?

    - A Fluent API is a design style aimed at maximizing code readability. It relies heavily on Method Chaining—where every method returns the state object (usually this), allowing you to string operations together sequentially like a natural sentence.
	- Because the method ends with return this;, we can call this class cleanly without resetting variables.
- Used Expression Trees to build dynamic data filters at runtime. It forms the backbone of custom search features, dynamic data tables.
- We use Expression Trees when C# code needs to be executed by something outside of C#.The most famous example is Entity Framework (EF Core). When you write this LINQ query to get data from a database:
- `var users = context.Users.Where(u => u.Age > 18);`
- C# does not download your entire database and filter it. Instead:C# converts u => u.Age > 18 into an Expression Tree.
- Entity Framework reads that tree structure (recognizing the property Age, the operator >, and the number 18).
- EF translates that tree into a raw SQL string: SELECT * FROM Users WHERE Age > 18;The SQL string is sent to your database server.

- On the downside if you are planning to use this code against a database (SQL Server/PostgreSQL) using Entity Framework, beware of lambda.Compile().
- Calling .Compile() forces LINQ to pull all records out of the database into the web server's memory (In-Memory Evaluation) before filtering. If your database table has millions of rows, your application will slow down or crash.
- *Fix for Databases*: Remove .Compile() and change `this._list` from an IEnumerable<T> to an IQueryable<T>. This allows the raw Expression Tree to be passed straight to Entity Framework, which translates it into clean, native SQL directly executed on the database server.