#### **Assignment 5 - Error Handling**



* **Task 1** -> Learnt the simple use case of exception handling that how does the "DivideByZeroException" works,
basically when a number which is divided a number that is zero it throws an exception that cause the interruption in the program.
* Such exceptions were caught and handled in the view folder using single try-catch block.
* **Task 2** -> Learnt how does the "IndexOutOfRangeException" works, this exception occurs when the user tries to access the position
of a data/value that is not present in the array.
* **Task 3** -> Learnt how to implement the Exception class and write a custom exception and pass the custom message to override the
base class exception message.



#### **Task 4 - AppDomain's UnhandledException Event**



* Learnt about AppDomain, basically it is a class and .NET use AppDomain as isolated execution environment inside a process.
* I got to know that in modern .NET applications user don't normally create or manage the AppDomain ourselves.
* The CurrentDomain finds the AppDomain that is the isolated environment in which the current code is running.
* Then the UnHandledException is the event associated with the current AppDomain, It is raised when an exception has escaped all the try-catch
block, then it is considered as unhandled exception.
* When an unhandled exception occurs then the event calls the GlobalEventHandler method.
* The GlobalEventHandler method has a sender and exception objects as parameter and if the UnhandledExceptionEventArgs object is a
type of exception object then it displays the error message.



#### **Task 5 - Stack Trace**


![Alt text]("C:\Users\Tanish.raffi\Pictures\Screenshots\Screenshot 2026-08-18 174608.png")


- The stack trace is the list of method calls that tracks the actual execution path of the program.
- It shows which methods were called and in what order they were called that leading up to specific part of the code or a runtime error.
- From the above image the error occurred in the method called Task5() line 180, which is present in the ConsoleView class inside the View folder
and the path goes till the origin of the directory.
- From there this method calls another method named GetNumber() where error caused at line 47.
- It holds the trace of the information which caused the error in a stack manner.



