# PROG366_FA23

## Category
App

## Client
C# .NET

## Project Date
Sep. 17 - Dec 20, 2023

## Description
This repository acts as a cache for all the assignment completed during the PROG366 Algorithms course. It is well documented repository, with an extensive README.md which documents the functionality and concepts behind each algorithm that was taught/assigned.


***
## **Assignment 1**
This C# program demonstrates different time complexities in the context of Big O Notation: Constant (O(1)), Linear (O(n)), and Quadratic (O(n^2)).
- ##  **O(1) Example (Lines 16-21 Program.cs | Lines 31-44 Utility.cs):**
  - In this part of the code, the `IsTrue` method is called with a single boolean value, `O1`. The `IsTrue` method checks if the provided boolean value is true or false, always performing the same set of operations regardless of the input value. It exhibits constant time complexity O(1) because the execution time is not dependent on the size of the input.
- ## **O(n) Example (Lines 21-28 Program.cs | Lines 46-58 Utility.cs):**
  - In this part of the code, the `EnumerablePrintAll` method is called with an array of boolean values, `On`. The method prints all the values in the enumerable sequence with their indices. The time it takes to execute this method is linearly proportional to the number of elements in the array, making it exhibit a linear time complexity O(n).
- ## **O(n^2) Example (Lines 28-34 Program.cs | Lines 60-79 Utility.cs):**
  - In this part of the code, the `EnumerablePrintCounts` method is called with the same array, `On`. This method prints the counts of distinct values in the input enumerable sequence. Inside the method, there are nested loops, resulting in a quadratic time complexity O(n^2) because the execution time grows quadratically as the input size increases.
***
## **Assignment 2**
This C# program demonstrates the Fisher-Yates Shuffle algorithm, efficiently shuffling elements randomly to ensure that each possible permutation is equally likely. It is useful for applications like shuffling cards or generating random orderings of items in a list.
- ## **Initialization (Lines 16-19 U_Shuffle.cs):**
  - The algorithm starts with an unshuffled collection, passed as the input to the `FYShuffle` method.
  - It initializes a random number generator (`Random rand`) to generate random indices used in shuffling.
- ## **Copying to an Array (Lines 19-22 U_Shuffle.cs):**
  - The input collection is copied to an array (`unshuf_arr`). This array will be used for shuffling the elements.
- ## **Shuffling (Lines 23-30 U_Shuffle.cs):**
  - The Fisher-Yates Shuffle algorithm iterates over the array in reverse order, swapping elements randomly.
  - After shuffling, the method returns the shuffled array.
- ## **Result (Line 32 U_Shuffle.cs):**
  - After shuffling is complete, the method returns the shuffled array, now a randomly permuted version of the original unshuffled collection.
- ## **Summary:**
  - The `FYShuffle` method takes an unshuffled collection, converts it into an array, and then performs the Fisher-Yates Shuffle on that array. The result is a shuffled array of the same type as the input collection.
***
## **Assignment 3**
This C# program demonstrates the use of different data structures for working with data, including Arrays, Hashtables, Stacks, and Queues.
- ## **Arrays (Lines 63-80 Program.cs):**
  - In the `ReadIntoArray` method, data from an XML file is read and stored in an array of dynamic arrays.
  - Arrays allow for quick indexing, facilitating fast access to elements by their position (index) in the array.
- ## **Hashtables (Lines 86-101 Program.cs):**
  - In the `ReadIntoHashtable` method, data from the XML file is read and stored in a Hashtable.
  - Hashtables provide fast key-based access, making them suitable for scenarios where data needs to be accessed using a specific identifier.
- ## **Stacks (Lines 107-122 Program.cs):**
  - In the `ReadIntoStack` method, data from the XML file is read and stored in a Stack of Tuple objects.
  - Stacks follow the Last-In-First-Out (LIFO) principle, making them useful for scenarios where elements need to be processed in reverse order.
- ## **Queues (Lines 128-143 Program.cs):**
  - In the `ReadIntoQueue` method, data from the XML file is read and stored in a Queue of Tuple objects.
  - Queues follow the First-In-First-Out (FIFO) principle, making them suitable for scenarios where elements need to be processed in the order of their appearance.
***
## **Assignment 4**
The provided C# program focuses on implementing and comparing various sorting algorithms. The choice of sorting algorithm depends on the specific requirements of the task, the size of the dataset, and the desired trade-offs between time and space complexity. Each algorithm has its advantages and drawbacks, making them suitable for different scenarios.
- ## **Bubble Sort (Lines 130-167 Program.cs):**
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
- ## **Insertion Sort (Lines 169-200 Program.cs):**
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
- ## **Selection Sort (Lines 202-230 Program.cs):**
  - **Description:** Simple sorting algorithm that divides the input list into two parts: a sorted and an unsorted region.
  - **Strengths:**
    - Simple to implement.
    - In-place sorting algorithm.
  - **Weaknesses:**
    - Inefficient for large datasets.
    - Time complexity is quadratic.
  - **Use Cases:**
    - Small datasets or situations where memory usage needs to be minimized.
- ## **Heap Sort (Lines 232-338 Program.cs):**
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
- ## **Quick Sort (Lines 340-417 Program.cs):**
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
- ## **Merge Sort (Lines 419-525 Program.cs):**
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
***
## **Assignment 6**
This C# program focuses on searching algorithms and their implementation. The assignment utilizes a dataset of integer values stored in the 'scores.txt' file and aims to demonstrate three searching algorithms: Linear Search, Binary Search, and Interpolation Search.

- ## **Linear Search (Lines 258-282 Program.cs):**
    - **Definition:** Sequentially checks each element of a dataset.
    - **Implementation:** The linear search method is applied to the ordered dataset.
    - **Results:** Displays the index of the target, the target element, and nearby elements.
    - **Big O Notation:**
        - Worst: O(n)
        - Best: O(1)
        - Average: O(n/2)
    - **Strengths:**
        - Simplicity.
        - Suitable for small datasets.
        - Easy integration into larger methods.
    - **Weaknesses:**
        - Inefficient for large datasets.
        - Limited suitability for dynamic datasets.
- ## **Binary Search (Lines 284-318 Program.cs):**
    - **Definition:** Compares the middle value of the dataset to the target, narrowing down the search space.
    - **Implementation:** The binary search method is applied to the ordered dataset.
    - **Results:** Displays the index of the target, the target element, and nearby elements.
    - **Big O Notation:**
        - Worst: O(log n)
        - Best: O(1)
        - Average: O(log n)
    - **Strengths:**
        - Early termination.
        - Efficient for sorted datasets.
        - Simplicity in context.
    - **Weaknesses:**
        - Inefficient for dynamic datasets.
        - Requires a pre-sorted dataset.
- ## **Interpolation Search (Lines 320-380 Program.cs):**
    - **Definition:** Compares the target to an interpolated position in the dataset.
    - **Implementation:** The interpolation search method is applied to the ordered dataset.
    - **Results:** Displays the index of the target, the target element, and nearby elements.
    - **Big O Notation:**
        - Worst: O(n)
        - Best: O(1)
        - Average: O(log log n)
    - **Strengths:**
        - Adaptable.
        - Potential for faster convergence.
        - Versatile with sorted data.
    - **Weaknesses:**
        - Potential degradation.
        - Sensitive to misinterpretation.
        - Adds additional complexity and time.
***
## **Assignment 7**
This C# assignment, part of the PROG366 course, revolves around the implementation and visualization of binary search trees (BST), emphasizing the structure of nodes and their relationships within the tree.
- ## **Node\<T\>**
    - The `Node<T>` class represents a generic tree node capable of storing data of type `T`. This class extends `BaseSerializable` and implements a constraint on `T` to be comparable.
    - ### **Structure:**
        - **ID**: A unique identifier generated using a new GUID.
        - **Data**: The data stored in the node.
        - **Parent**: Reference to the parent node.
        - **LeftChild**: Reference to the left child node.
        - **RightChild**: Reference to the right child node.
    - ### **Functionality:**
        - #### **Node Data:**
            - **GetID()**: Gets the unique identifier of the node.
            - **SetData(T data)**: Sets the data of the node.
            - **GetData()**: Gets the data stored in the node.
        - #### **Relational Data:**
            - **Parent:**
                - **SetParent(Node<T> parent)**: Sets the parent node of the current node.
                - **GetParent()**: Gets the parent node of the current node.
            - **Left Child:**
                - **SetLeftChild(Node<T> left)**: Sets the left child node of the current node.
                - **GetLeftChild()**: Gets the left child node of the current node.
            - **Right Child:**
                - **SetRightChild(Node<T> right)**: Sets the right child node of the current node.
                - **GetRightChild()**: Gets the right child node of the current node.
- ## **Tree\<T\>**
    - The `Tree<T>` class represents a generic tree data structure with elements of type `T`. This class extends `BaseSerializable` and imposes a constraint on `T` to implement `IComparable<T>`.
    - ### **Structure:**
        - **Count**: Gets or sets the count of nodes in the tree.
        - **Root**: Gets or sets the root node of the tree.
    - ### **Functionality:**
        - #### **Add Node:**
            - **AddNode(Node<T> node)**: Adds a node to the tree.
            - **AddNode(Node<T> currentNode, Node<T> newNode)**: Recursively adds a node to the tree based on the comparison of data values.
        - #### **Traverse:**
            - **Traverse (Action):**
                - **Action\<T\>:**
                    - **Traverse(Action<T> action)**: Traverses the tree and applies an action to each element.
                    - **TraverseNodes(Node<T>? node, Action<T> action)**: Recursively traverses the nodes of the tree and applies an action to each element.
                - **Action\<Node\<T\>\>:**
                    - **Traverse(Action<Node<T>> action)**: Traverses the tree and applies an action to each node.
                    - **TraverseNodes(Node<T>? node, Action<Node<T>> action)**: Recursively traverses the nodes of the tree and applies an action to each node.
            - **Traverse (Func):**
                - **Func\<Node\<T\>, O\>:**
                - **Traverse\<O\>(Func<Node<T>, O> action)**: Traverses the tree and applies a function to each node, collecting the results in a list.
                - **TraverseNodes\<O\>(Node<T> node, Func<Node<T>, O> action, List<O> result)**: Recursively traverses the nodes of the tree and applies a function to each node, collecting the results in a list.
- ## **Overview:**
    - Data Tree/Node Structures are hierarchical data structures composed of nodes connected by edges, forming a tree-like arrangement. Each node contains a value, and nodes with the same parent are siblings. The structure is defined by its hierarchical nature, starting from a unique root node and extending to leaf nodes.
    - ### **Strengths:**
        - **Efficient Search:** Binary Search Trees offer efficient search and retrieval operations with O(log n) time complexity.
        - **Hierarchical Organization:** Natural representation for hierarchical relationships, making it intuitive for certain types of data.
        - **Recursive Operations:** Recursive operations (traversals, modifications) are often simpler to implement on trees.
    - ### **Weaknesses:**
        - **Memory Overhead:** Additional memory is required for storing pointers/references, leading to potential memory overhead.
        - **Complexity:** Implementing and managing complex trees (e.g., self-balancing trees) can be challenging.
        - **Not Always Optimal:** Trees might not be the best choice for certain data access patterns (e.g., sequential access).
    - ### **Use Cases:**
        - **File Systems:** Representing directory structures with folders and files.
        - **Databases:** Index structures like B-trees for efficient data retrieval.
        - **Compiler Design:** Abstract Syntax Trees (AST) are used in compilers for syntax analysis.
        - **Routing Algorithms:** Hierarchical routing tables in computer networks.
        - **AI and Decision Trees:** Decision trees are used in machine learning for decision-making processes.
        - **XML/HTML Parsing:** Document Object Model (DOM) structures for XML/HTML parsing.
***
