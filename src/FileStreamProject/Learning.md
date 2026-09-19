# Assignment 15 - Working with files and streams

## Task 1: Implement a File Data Processor

### Dynamic 1 GB File Generation

To perform authentic performance benchmarks, the application automatically constructs a **1 GB test data asset entirely at runtime** if it does not already exist on the local system.

* **Self-Contained Execution:** This approach ensures eliminating the need to manually download or look for heavy external dependencies.
* **Zero Repository Bloat:** Generating the data asset programmatically prevents massive binary or text files from tracking in your Git history, keeping the source control lightweight, fast to clone, and clean.

The file generation pipeline uses a streamlined `FileStream` loop that writes structured data records directly to the hard drive, completing the entire 1 GB allocation.

### 1. FileStream

* **Role in Task 1:** Forms the direct physical bridge to storage files on the local machine. It reads and writes raw byte blocks directly to disk files.

### 2. BufferedStream

* **Role in Task 1:** Acts as a high-speed memory staging cache around a slow or unbuffered stream. Instead of hitting the hard drive repeatedly for tiny array requests, it performs fewer, massive read queries into RAM (configured at **64 KB** blocks), drastically reducing high-overhead kernel disk switches.

### 3. MemoryStream

* **Role in Task 1:** Serves as a localized, high-speed temporary buffer to stage text translations. Bytes are held completely in system memory for instant read/write manipulation before being permanently flushed down to physical storage.

## Task 2: Implement an Asynchronous File Data Processor

### 1. Asynchronous FileStream

* **Role in Task 2:** It opens a direct connection to read a file from the hard drive in the background. It allows the program to stay responsive and keep working without freezing while waiting for the slow hard disk to fetch data.

### 2. Asynchronous BufferedStream

* **Role in Task 2:** It reads large blocks of data (64 KB) into your computer's fast memory (RAM) all at once in the background. This speeds up the program by avoiding thousands of separate, slow trips to the actual hard drive.

### 3. Asynchronous Staging MemoryStream

* **Role in Task 2:** It acts as a fast, temporary workbench inside the computer's memory. It holds the text in RAM while converting it to uppercase, keeping everything fast before saving the final result to a real file.

### 4. Concurrent Processing Engine

* **Role in Task 2:** It acts like hiring multiple workers to process different files at the exact same time. Instead of waiting for one file to finish before starting the next, it processes all files together, saving a massive amount of time.

## Task 3: Code Issues & Optimization Fixes

* **The Issue 1:** The starter code wrote data into an intermediate `MemoryStream` and then invoked `memoryStream.ToArray()`. This allocated a brand-new byte array (`writeBuffer`) on the managed heap just to pass it directly down to a `FileStream`. For large blocks, this creates severe memory duplication.
* **The Fix:** Completely removed the intermediate `MemoryStream` staging layer. The refactored solution streams string data directly to the disk by binding a `StreamWriter` directly to the physical `FileStream`, cutting memory overhead to zero.

* **The Issue 2:** The starter code nested inner file streams deep inside memory streams but left out explicit file handling configurations. Lacking explicit `FileAccess` and `FileShare` permissions leaves streams open to unmanaged OS handle locking crashes if multiple threads attempt to reference the asset concurrently.
* **The Fix:** Implemented standard stacked `using` block structures with explicit `FileAccess.Write` settings. This guarantees that unmanaged file handles are safely closed and released immediately upon block termination, avoiding file lock contentions.

* **The Issue 3:** During the reading phase, the starter code looped through raw byte buffers character-by-character to write them to the console layout via `Console.Write((char)buffer[i])`. Executing thousands of tiny, separate console rendering tasks blocks the execution thread.
* **The Fix:** Replaced per-character stream writing with a high-performance memory accumulation pattern using a **`StringBuilder`**.

* **The Issue 4:** The starter code blindly converted file streams using raw 1024-byte array limits. In UTF-8 encoding, characters can span anywhere from 1 to 4 bytes.
If a multi-byte symbol sits exactly on the 1024-byte block boundary, its byte sequence is split across loop cycles, creating permanent text data corruption like this(`?`).
* **The Fix:** Incorporated explicit `Encoding.UTF8` decoding boundaries across text extraction blocks to maintain strict character alignment.


## Task 4: Analyze and Resolve Performance Issues with Logging System for Multiple Users.


* **Per-Call MemoryStream Allocation:** Every invocation of the logging method instantiates a redundant intermediate `MemoryStream` object. This creates double-handling overhead in system RAM by copying bytes from a local array into memory before writing to disk, leading to heavy Object Allocation Thrashing and Garbage Collection spikes.
* **Unshared FileMode.Append:** Initializing the `FileStream` using only the `FileMode.Append` parameter forces the operating system to default to `FileShare.None`. This places an exclusive hardware lock on the file, completely blocking concurrent users or parallel execution paths from accessing the file handle simultaneously.
* **Lack of Synchronization:** The starter routine contains zero mutual-exclusion boundaries or primitive thread-safety safety mechanisms. When multiple background worker threads attempt to execute writes at the exact same millisecond, the application triggers immediate file access crashes.
* **Single-File Contention Bottlenecks:** Forcing a high volume of parallel worker threads or web requests to continuously stream data down into a single shared file handle creates a massive I/O performance roadblock as threads are forced to stall sequentially while waiting for the resource lock to clear.

* **ThreadPool Optimization via Parallel.For:** Upgrading to a parallel loop (`Parallel.For`) eliminates the massive memory footprint by routing all 1,000 simulated user logging routines through the highly optimized **.NET ThreadPool**. Instead of creating 1,000 heavy threads, it creates a small pool of workers matching the local CPU core count, batching and processing the workloads with minimal memory overhead.