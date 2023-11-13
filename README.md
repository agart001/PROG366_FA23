- PROG366_FA23:
    A repo of Assignments for PROG366, Alogrithms.

----

- Assignment 1:
    This C# program demonstrates different time complexities in the context of Big O Notation: Constant (O(1)), Linear (O(n)), and Quadratic (O(n^2)).

    - O(1) Example (Lines 16-21 Program.cs | Lines 31-44 Utility.cs):
        - In this part of the code, the `IsTrue` method is called with a single boolean value,
          `O1`. The `IsTrue` method checks if the provided boolean value is true or false, and it always performs the same set of operations regardless of the input value. Therefore, it exhibits a constant time complexity O(1) because the execution time is not dependent on the size of the input. It's a single operation, so it has a constant time complexity.

    - O(n) Example (Lines 21-28 Program.cs | Lines 46-58 Utility.cs):
        - In this part of the code, the `EnumerablePrintAll` method is called with an array of
          boolean values, `On`. The method prints all the values in the enumerable sequence with their indices. The time it takes to execute this method is linearly proportional to the number of elements in the array. If there are 'n' elements in the input array, the method will iterate through all 'n' elements, making it exhibit a linear time complexity O(n).

    - O(n^2) Example (Lines 28-34 Program.cs | Lines 60-79 Utility.cs):
        - In this part of the code, the `EnumerablePrintCounts` method is called with the same
          array, `On`. This method prints the counts of distinct values in the input enumerable sequence. Inside the method, there are nested loops. The outer loop iterates over distinct values, and the inner loop iterates over the entire input sequence to count occurrences of each distinct value. As a result, the total number of iterations is proportional to the product of the number of distinct values and the length of the sequence. This results in a quadratic time complexity O(n^2) because the execution time grows quadratically as the input size increases.

----          

- Assignment 2:
    This C# program demostrates the Fisher-Yates Shuffle algorithm, which is used to randomly shuffle the elements of a collection. The Fisher-Yates Shuffle algorithm is an efficient way to shuffle elements randomly, ensuring that each possible permutation is equally likely, making it useful for applications like shuffling cards or generating random orderings of items in a list.

    - Initialization (Lines 16-19 U_Shuffle.cs):
        - The algorithm starts with an unshuffled collection,
          which is passed as the input to the `FYShuffle` method.
        - It also initializes a random number generator (`Random rand`)
          to generate random indices used in shuffling.

    - Copying to an Array (Lines 19-22 U_Shuffle.cs):
        - The input collection is copied to an array (`unshuf_arr`). 
          This array will be used for shuffling the elements.

    - Shuffling (Lines 23-30 U_Shuffle.cs):
        - The Fisher-Yates Shuffle algorithm iterates over the array in reverse order,
          starting from the last element and moving towards the first element.
        - For each element at the current position (`i`), a random index `j` is generated
          within the range [0, i]. This index `j` is used to swap the current element at position `i` with the element at position `j`.
        - The swap operation is performed using a temporary variable (`temp`), ensuring that the elements are randomly rearranged within the array.

    - Result (Line 32 U_Shuffle.cs):
        - After the shuffling is complete, the method returns the shuffled array, which is now a randomly permuted version of the original unshuffled collection.

    - Summary:
        - The `FYShuffle` method takes an unshuffled collection of any type `T`, converts it into
          an array, and then performs the Fisher-Yates Shuffle on that array. The result is a shuffled array of the same type as the input collection. The main program reads an unshuffled file, shuffles its contents using the `FYShuffle` method, and then writes the shuffled contents to another file.

----

- Assignment 3:
    This C# program demonstrates the use of different data structures for working with data, including Arrays, Hashtables, Stacks, and Queues. Arrays provide quick indexing, Hashtables enable fast key-based access, Stacks and Queues allow for last-in-first-out and first-in-first-out processing, respectively.

    - Arrays (Lines 63-80 Program.cs):
        - In the `ReadIntoArray` method, data from an XML file is read and stored in an array of
          dynamic arrays.
        - Arrays are fixed-size data structures used for storing elements of the same or different
          types.
        - In this context, the array is used to store key-value pairs from the XML file, where each
          element in the outer array represents a key-value pair, and the inner arrays contain the key and value.
        - Arrays allow for indexing, which means you can quickly access elements by their
          position(index) in the array.

    - Hashtables (Lines 86-101 Program.cs):
        - In the `ReadIntoHashtable` method, data from the XML file is read and stored in a
          Hashtable.
        - Hashtables are dynamic-size data structures used to store key-value pairs, where the keys
          are unique.
        - In this case, the keys are read from the XML file, and the corresponding values are
          stored in the Hashtable.
        - Hashtables are particularly useful for quickly accessing values based on their keys,
          making them suitable for scenarios where data needs to be accessed using a specific identifier.

    - Stacks (Lines 107-122 Program.cs):
        - In the `ReadIntoStack` method, data from the XML file is read and stored in a Stack of
          Tuple objects.
        - Stacks are dynamic data structures that follow the Last-In-First-Out (LIFO) principle,
          meaning the last element added is the first one to be removed.
        - In this context, the Stack is used to store key-value pairs from the XML file in
          reverse order of their appearance, with the last pair being the first to be popped (removed).
        - Stacks are commonly used in scenarios where elements need to be processed in reverse
          order, like parsing expressions or tracking function call execution.

    - Queues (Lines 128-143 Program.cs):
        - In the `ReadIntoQueue` method, data from the XML file is read and stored in a Queue of
          Tuple objects.
        - Queues are dynamic data structures that follow the First-In-First-Out (FIFO)
          principle, meaning the first element added is the first one to be removed.
        - In this case, the Queue is used to store key-value pairs from the XML file in the
          order of their appearance, and the first pair added is the first one to be dequeued (removed).
        - Queues are often used for tasks like managing tasks in a queue, handling requests in a
          web server, or implementing breadth-first search in graphs.

----