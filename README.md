## - PROG366_FA23:
    A repo of Assignments for PROG366, Alogrithms.

####

# - Assignment 1:
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

####         

# - Assignment 2:
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

####

# - Assignment 3:
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

####

# - Assignment 4:
    The provided C# program focuses on implementing and comparing various sorting algorithms. The choice of sorting algorithm depends on the specific requirements of the task, the size of the dataset, and the desired trade-offs between time and space complexity. Each algorithm has its advantages and drawbacks, making them suitable for different scenarios.
    
    - Bubble Sort:
      - Description: Bubble Sort is a simple comparison-based sorting algorithm. It repeatedly
        steps through the list, compares adjacent elements, and swaps them if they are in the wrong order. The pass through the list is repeated until the list is sorted.
      - Strengths:
        - Easy to understand and implement.
        - Works well for small datasets and nearly sorted data.
      - Weaknesses:
        - Inefficient for large datasets, especially in its basic form.
        - Performance degrades quickly as the size of the dataset increases.
      - Use Cases:
        - Educational purposes.
        - Small datasets where simplicity is prioritized over performance.

    - Insertion Sort:
      - Description: Insertion Sort builds the final sorted array one item at a time. It is much
        less efficient on large lists than more advanced algorithms such as quicksort, heapsort, or merge sort.
      - Strengths:
        - Efficient for small datasets.
        - Adaptive, performs well on partially sorted datasets.
      - Weaknesses:
        - Inefficient for large datasets.
        - Time complexity is quadratic.
      - Use Cases:
        - Small datasets or nearly sorted data.
        - Situations where online sorting (adding items to a sorted list) is needed.

    - Selection Sort:
      - Description: Selection Sort is a simple sorting algorithm that divides the input list
        into two parts: a sorted and an unsorted region. The algorithm repeatedly selects the smallest (or largest) element from the unsorted region and swaps it with the first unsorted element.
      - Strengths:
        - Simple to implement.
        - In-place sorting algorithm.
      - Weaknesses:
        - Inefficient for large datasets.
        - Time complexity is quadratic.
      - Use Cases:
        - Small datasets or situations where memory usage needs to be minimized.

    - Heap Sort:
      - Description: Heap Sort is a comparison-based sorting algorithm that uses a binary heap
        data structure to build a max-heap or min-heap. The heap is then reduced to a sorted array by repeatedly removing the root element and rebuilding the heap.
      - Strengths:
        - Time complexity is guaranteed to be O(n log n).
        - In-place sorting algorithm.
      - Weaknesses:
        - Less suitable for small datasets compared to simpler algorithms like quicksort.
        - Not stable.
      - Use Cases:
        - Situations where a guaranteed time complexity is required.
        - Sorting large datasets with limited memory.

    - Quick Sort:
      - Description: Quick Sort is a widely used, efficient, and in-place sorting algorithm that
        uses a divide-and-conquer strategy. It selects a 'pivot' element and partitions the other elements into two sub-arrays according to whether they are less than or greater than the pivot. The sub-arrays are then sorted recursively.
      - Strengths:
        - Average-case time complexity is O(n log n).
        - In-place sorting algorithm.
      - Weaknesses:
        - Worst-case time complexity is O(n^2) if the pivot selection is poor.
        - Not stable.
      - Use Cases:
        - General-purpose sorting.
        - Situations where average-case performance is critical.

    - Merge Sort:
      - Description: Merge Sort is an efficient, stable, and comparison-based sorting algorithm.
        It divides the unsorted list into n sub-lists, each containing one element, and then repeatedly merges sub-lists to produce new sorted sub-lists until there is only one sub-list remaining.
      - Strengths:
        - Stable and consistent performance across different datasets.
        - Efficient for large datasets.
      - Weaknesses:
        - Space complexity is higher compared to some other algorithms.
        - May not be as fast as quicksort for small datasets.
      - Use Cases:
        - Sorting large datasets.
        - Situations where stable sorting is required.

####
