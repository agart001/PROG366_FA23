# PROG366_FA23
A repository of assignments for PROG366, Algorithms.

####

#### **Assignment 1**
This C# program demonstrates different time complexities in the context of Big O Notation: Constant (O(1)), Linear (O(n)), and Quadratic (O(n^2)).

- **O(1) Example (Lines 16-21 Program.cs | Lines 31-44 Utility.cs):**
  - In this part of the code, the `IsTrue` method is called with a single boolean value, `O1`. The `IsTrue` method checks if the provided boolean value is true or false, always performing the same set of operations regardless of the input value. It exhibits constant time complexity O(1) because the execution time is not dependent on the size of the input.

- **O(n) Example (Lines 21-28 Program.cs | Lines 46-58 Utility.cs):**
  - In this part of the code, the `EnumerablePrintAll` method is called with an array of boolean values, `On`. The method prints all the values in the enumerable sequence with their indices. The time it takes to execute this method is linearly proportional to the number of elements in the array, making it exhibit a linear time complexity O(n).

- **O(n^2) Example (Lines 28-34 Program.cs | Lines 60-79 Utility.cs):**
  - In this part of the code, the `EnumerablePrintCounts` method is called with the same array, `On`. This method prints the counts of distinct values in the input enumerable sequence. Inside the method, there are nested loops, resulting in a quadratic time complexity O(n^2) because the execution time grows quadratically as the input size increases.

####

#### **Assignment 2**
This C# program demonstrates the Fisher-Yates Shuffle algorithm, efficiently shuffling elements randomly to ensure that each possible permutation is equally likely. It is useful for applications like shuffling cards or generating random orderings of items in a list.

- **Initialization (Lines 16-19 U_Shuffle.cs):**
  - The algorithm starts with an unshuffled collection, passed as the input to the `FYShuffle` method.
  - It initializes a random number generator (`Random rand`) to generate random indices used in shuffling.

- **Copying to an Array (Lines 19-22 U_Shuffle.cs):**
  - The input collection is copied to an array (`unshuf_arr`). This array will be used for shuffling the elements.

- **Shuffling (Lines 23-30 U_Shuffle.cs):**
  - The Fisher-Yates Shuffle algorithm iterates over the array in reverse order, swapping elements randomly.
  - After shuffling, the method returns the shuffled array.

- **Result (Line 32 U_Shuffle.cs):**
  - After shuffling is complete, the method returns the shuffled array, now a randomly permuted version of the original unshuffled collection.

- **Summary:**
  - The `FYShuffle` method takes an unshuffled collection, converts it into an array, and then performs the Fisher-Yates Shuffle on that array. The result is a shuffled array of the same type as the input collection.

####

#### **Assignment 3**
This C# program demonstrates the use of different data structures for working with data, including Arrays, Hashtables, Stacks, and Queues.

- **Arrays (Lines 63-80 Program.cs):**
  - In the `ReadIntoArray` method, data from an XML file is read and stored in an array of dynamic arrays.
  - Arrays allow for quick indexing, facilitating fast access to elements by their position (index) in the array.

- **Hashtables (Lines 86-101 Program.cs):**
  - In the `ReadIntoHashtable` method, data from the XML file is read and stored in a Hashtable.
  - Hashtables provide fast key-based access, making them suitable for scenarios where data needs to be accessed using a specific identifier.

- **Stacks (Lines 107-122 Program.cs):**
  - In the `ReadIntoStack` method, data from the XML file is read and stored in a Stack of Tuple objects.
  - Stacks follow the Last-In-First-Out (LIFO) principle, making them useful for scenarios where elements need to be processed in reverse order.

- **Queues (Lines 128-143 Program.cs):**
  - In the `ReadIntoQueue` method, data from the XML file is read and stored in a Queue of Tuple objects.
  - Queues follow the First-In-First-Out (FIFO) principle, making them suitable for scenarios where elements need to be processed in the order of their appearance.

####

#### **Assignment 4**
The provided C# program focuses on implementing and comparing various sorting algorithms. The choice of sorting algorithm depends on the specific requirements of the task, the size of the dataset, and the desired trade-offs between time and space complexity. Each algorithm has its advantages and drawbacks, making them suitable for different scenarios.

- **Bubble Sort (Lines 130-167 Program.cs):**
  - **Description:** Simple comparison-based sorting algorithm that repeatedly steps through the list, compares adjacent elements, and swaps them if they are in the wrong order.
  - **Strengths:**
    - Easy to understand and implement.
    - Works well for small datasets and nearly sorted data.
  - **Weaknesses:**
    - Inefficient for large datasets, especially in its basic form.
    - Performance degrades quickly as the size of the dataset increases.
  - **Use Cases:**
    - Educational purposes.
    - Small datasets prioritizing simplicity over performance.

- **Insertion Sort (Lines 169-200 Program.cs):**
  - **Description:** Builds the final sorted array one item at a time. Less efficient on large lists than more advanced algorithms.
  - **Strengths:**
    - Efficient for small datasets.
    - Adaptive, performs well on partially sorted datasets.
  - **Weaknesses:**
    - Inefficient for large datasets.
    - Time complexity is quadratic.
  - **Use Cases:**
    - Small datasets or nearly sorted data.
    - Situations where online sorting is needed.

- **Selection Sort (Lines 202-230 Program.cs):**
  - **Description:** Simple sorting algorithm that divides the input list into two parts: a sorted and an unsorted region.
  - **Strengths:**
    - Simple to implement.
    - In-place sorting algorithm.
  - **Weaknesses:**
    - Inefficient for large datasets.
    - Time complexity is quadratic.
  - **Use Cases:**
    - Small datasets or situations where memory usage needs to be minimized.

- **Heap Sort (Lines 232-338 Program.cs):**
  - **Description:** Comparison-based sorting algorithm that uses a binary heap data structure to build a max-heap or min-heap.
  - **Strengths:**
    - Time complexity is guaranteed to be O(n log n).
    - In-place sorting algorithm.
  - **Weaknesses:**
    - Less suitable for small datasets compared to simpler algorithms like quicksort.
    - Not stable.
  - **Use Cases:**
    - Situations where a guaranteed time complexity is required.
    - Sorting large datasets with limited memory.

- **Quick Sort (Lines 340-417 Program.cs):**
  - **Description:** Efficient, in-place sorting algorithm that uses a divide-and-conquer strategy.
  - **Strengths:**
    - Average-case time complexity is O(n log n).
    - In-place sorting algorithm.
  - **Weaknesses:**
    - Worst-case time complexity is O(n^2) if the pivot selection is poor.
    - Not stable.
  - **Use Cases:**
    - General-purpose sorting.
    - Situations where average-case performance is critical.

- **Merge Sort (Lines 419-525 Program.cs):**
  - **Description:** Efficient, stable, and comparison-based sorting algorithm that divides the unsorted list into n sub-lists and repeatedly merges sub-lists.
  - **Strengths:**
    - Stable and consistent performance across different datasets.
    - Efficient for large datasets.
  - **Weaknesses:**
    - Space complexity is higher compared to some other algorithms.
    - May not be as fast as quicksort for small datasets.
  - **Use Cases:**
    - Sorting large datasets.
    - Situations where stable sorting is required.

####