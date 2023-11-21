using System.Diagnostics;

namespace PROG366_Assignment4
{
    /// <summary>
    /// Represents the main program class.
    /// </summary>
    internal class Program
    {
        #region Main
        /// <summary>
        /// Array to store the scores read from the file.
        /// </summary>
        static int[] scores;

        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            // Read lines from the file and convert them to a list of strings
            List<string> lines = File.ReadAllLines($"{Directory.GetCurrentDirectory()}\\scores.txt").ToList();

            // Initialize the scores array with the count of lines
            scores = new int[lines.Count];
            int i = 0;

            // Iterate through each line, parse the integer, and populate the scores array
            lines.ForEach(l =>
            {
                int s = int.Parse(l);
                scores[i] = s;
                i++;
            });

            // Sort and measure execution time for various sorting algorithms

            // Bubble Sort
            int[] bubble_scores = SortExecutionTime(BubbleSort, scores);

            // Insertion Sort
            int[] insertion_scores = SortExecutionTime(InsertionSort, scores);

            // Selection Sort
            int[] selection_scores = SortExecutionTime(SelectionSort, scores);

            // Heap Sort
            int[] heap_scores = SortExecutionTime(HeapSort, scores);

            // Quick Sort
            int[] qsort_scores = SortExecutionTime(QuickSort, scores);

            // Merge Sort
            int[] merge_scores = SortExecutionTime(MergeSort, scores);
        }
        #endregion

        #region Utility
        /// <summary>
        /// Reverses the elements of an IEnumerable.
        /// </summary>
        /// <typeparam name="T">The type of elements in the input collection.</typeparam>
        /// <param name="input">The input collection to reverse.</param>
        /// <returns>A reversed IEnumerable.</returns>
        public static IEnumerable<T> Reverse<T>(IEnumerable<T> input) => input.Reverse();

        /// <summary>
        /// Creates a deep copy of an array.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="input">The array to copy.</param>
        /// <returns>A new array with the same elements as the input array.</returns>
        public static T[] Copy<T>(T[] input)
        {
            // Create a new array of the same length as the input array
            T[] copy = new T[input.Length];

            // Copy the elements from the input array to the new array
            Array.Copy(input, copy, input.Length);

            // Return the new array
            return copy;
        }

        /// <summary>
        /// Executes a sorting method and measures its execution time.
        /// </summary>
        /// <param name="method">The sorting method to execute.</param>
        /// <param name="input">The input array to be sorted.</param>
        /// <returns>The sorted array.</returns>
        public static int[] SortExecutionTime(Func<int[], int[]> method, int[] input)
        {
            // Stopwatch is used to measure the execution time of the sorting method
            Stopwatch sw = new Stopwatch();

            try
            {
                sw.Start();

                // Call the sorting method
                return method(input);
            }
            finally
            {
                sw.Stop();

                // Print the execution time to the console
                Console.WriteLine($"{method.Method.Name} Execution Time: {sw.Elapsed}");
            }
        }

        /// <summary>
        /// Swaps two elements in an integer array.
        /// </summary>
        /// <param name="array">The integer array in which to swap elements.</param>
        /// <param name="i1">Index of the first element to swap.</param>
        /// <param name="i2">Index of the second element to swap.</param>
        public static void Swap(int[] array, int i1, int i2)
        {
            // Swap the elements at indices in1 and in2 in the array
            int temp = array[i1];
            array[i1] = array[i2];
            array[i2] = temp;
        }
        #endregion

        #region Sorts

        #region Bubble
        /// <summary>
        /// Sorts an array using the Bubble Sort algorithm.
        /// </summary>
        /// <param name="input">The input array to be sorted.</param>
        /// <returns>The sorted array.</returns>
        public static int[] BubbleSort(int[] input)
        {
            // Create a copy of the input array
            int[] copy = Copy(input);

            // Flag to indicate if any swaps were made in the last iteration
            bool sorted = false;

            // Continue iterating until no swaps are made
            while (!sorted)
            {
                // Assume the array is sorted at the beginning
                sorted = true;

                // Iterate through the array
                for (int i = 0; i < copy.Length - 1; i++)
                {
                    // Compare adjacent elements
                    if (copy[i] < copy[i + 1])
                    {
                        // Swap if the current element is less than the next element
                        Swap(copy, i, i + 1);
                        // Set sorted to false since a swap was made
                        sorted = false;
                    }
                }
            }

            // Return the reversed copy of the array
            return Reverse(copy).ToArray();
        }
        #endregion

        #region Insertion
        /// <summary>
        /// Sorts an array using the Insertion Sort algorithm.
        /// </summary>
        /// <param name="input">The input array to be sorted.</param>
        /// <returns>The sorted array.</returns>
        public static int[] InsertionSort(int[] input)
        {
            // Create a copy of the input array
            int[] copy = Copy(input);

            // Start iterating from the second element
            int i = 1;
            while (i < copy.Length)
            {
                // Save the current index
                int j = i;

                // Continue moving elements to the left until in order
                while (j > 0 && copy[j - 1] > copy[j])
                {
                    // Swap elements if out of order
                    Swap(copy, j, j - 1);
                    j--;
                }
                i++;
            }

            // Return the sorted array
            return copy;
        }
        #endregion

        #region Selection
        /// <summary>
        /// Sorts an array using the Selection Sort algorithm.
        /// </summary>
        /// <param name="input">The input array to be sorted.</param>
        /// <returns>The sorted array.</returns>
        public static int[] SelectionSort(int[] input)
        {
            // Create a copy of the input array
            int[] copy = Copy(input);

            // Iterate through the array
            for (int i = 0; i < copy.Length - 1; i++)
            {
                // Iterate through the remaining unsorted part of the array
                for (int j = i + 1; j < copy.Length; j++)
                {
                    // Compare and swap elements if necessary
                    if (copy[j] >= copy[i])
                    {
                        Swap(copy, i, j);
                    }
                }
            }

            // Return the reversed copy of the array
            return Reverse(copy).ToArray();
        }
        #endregion

        #region Heap
        /// <summary>
        /// Builds a max heap from an input array.
        /// </summary>
        /// <param name="input">The input array to be converted into a max heap.</param>
        /// <returns>A new array representing the max heap.</returns>
        public static int[] MakeHeap(int[] input)
        {
            // Create a copy of the input array
            int[] copy = Copy(input);

            // Iterate through the array
            for (int i = 0; i < copy.Length; i++)
            {
                int index = i;

                // Adjust the heap structure by moving the current element up
                while (index != 0)
                {
                    int parent = (index - 1) / 2;

                    // Break if the current element is less than or equal to its parent
                    if (copy[index] <= copy[parent])
                    {
                        break;
                    }

                    // Swap the current element with its parent
                    Swap(copy, index, parent);
                    index = parent;
                }
            }

            // Return the resulting max heap
            return copy;
        }

        /// <summary>
        /// Removes the top element (root) from a max heap and maintains the heap property.
        /// </summary>
        /// <param name="input">The max heap array.</param>
        /// <param name="count">The current count of elements in the heap.</param>
        /// <returns>The value of the removed top element.</returns>
        public static int RemoveTop(int[] input, int count)
        {
            // Store the value of the top element (root)
            int result = input[0];

            // Replace the root with the last element in the heap
            input[0] = input[count - 1];

            int index = 0;

            // Adjust the heap structure by moving the new root down
            while (index < count)
            {
                int c1 = 2 * index + 1;
                int c2 = 2 * index + 2;

                // Ensure child indices are within the valid range
                if (c1 >= count) { c1 = index; }
                if (c2 >= count) { c2 = index; }

                // Break if the current element is greater than or equal to both children
                if (input[index] < input[c1] || input[index] < input[c2])
                {
                    int sc = (input[c1] >= input[c2]) ? c1 : c2;

                    // Swap the current element with the larger child
                    Swap(input, index, sc);
                    index = sc;
                }
                else
                {
                    // Break if the heap property is satisfied
                    break;
                }
            }

            // Return the value of the removed top element
            return result;
        }

        /// <summary>
        /// Sorts an array using the Heap Sort algorithm.
        /// </summary>
        /// <param name="input">The input array to be sorted.</param>
        /// <returns>The sorted array.</returns>
        public static int[] HeapSort(int[] input)
        {
            // Build a max heap from the input array
            int[] heap = MakeHeap(input);

            // Iterate through the heap elements
            for (int i = heap.Length - 1; i > 0; i--)
            {
                // Swap the root (max element) with the last element in the heap
                Swap(heap, 0, i);

                // Remove the top element to maintain the heap property
                RemoveTop(heap, i);
            }

            // Return the sorted array
            return heap;
        }
        #endregion

        #region Quick
        /// <summary>
        /// Partitions the array into two halves, elements less than the pivot on the left,
        /// and elements greater than the pivot on the right.
        /// </summary>
        /// <param name="input">The input array to be partitioned.</param>
        /// <param name="lo">The low index of the partition.</param>
        /// <param name="hi">The high index of the partition.</param>
        /// <returns>The index of the pivot after partitioning.</returns>
        public static int Partition(int[] input, int lo, int hi)
        {
            // Choose the pivot as the last element in the partition
            int pivot = input[hi];

            // Initialize the index of the smaller element
            int i = lo - 1;

            // Iterate through the elements in the partition
            for (int j = lo; j < hi - 1; j++)
            {
                // If the current element is less than or equal to the pivot
                if (input[j] <= pivot)
                {
                    // Move to the next position for the smaller element
                    i++;

                    // Swap the current element with the smaller element
                    Swap(input, i, j);
                }
            }

            // Move the pivot to its correct position
            i++;
            Swap(input, i, hi);

            // Return the index of the pivot after partitioning
            return i;
        }

        /// <summary>
        /// Recursively sorts the elements within a given range using the QuickSort algorithm.
        /// </summary>
        /// <param name="input">The input array to be sorted.</param>
        /// <param name="lo">The low index of the range to be sorted.</param>
        /// <param name="hi">The high index of the range to be sorted.</param>
        private static void QSort(int[] input, int lo, int hi)
        {
            // Base case: If the low index is greater than or equal to the high index, return
            if (lo >= hi || lo < 0)
            {
                return;
            }

            // Partition the array and get the index of the pivot
            int p = Partition(input, lo, hi);

            // Recursively sort the left and right sub-arrays
            QSort(input, lo, p - 1);
            QSort(input, p + 1, hi);
        }

        /// <summary>
        /// Sorts an array using the QuickSort algorithm.
        /// </summary>
        /// <param name="input">The input array to be sorted.</param>
        /// <returns>The sorted array.</returns>
        public static int[] QuickSort(int[] input)
        {
            // Create a copy of the input array
            int[] copy = Copy(input);

            // Call the recursive QuickSort method on the entire array
            QSort(copy, 0, copy.Length - 1);

            // Return the sorted array
            return copy;
        }
        #endregion

        #region Merge
        /// <summary>
        /// Merges two sub-arrays into a single sorted array.
        /// </summary>
        /// <param name="input">The input array containing the sub-arrays to be merged.</param>
        /// <param name="start">The start index of the first sub-array.</param>
        /// <param name="mid">The end index of the first sub-array and start index of the second sub-array.</param>
        /// <param name="end">The end index of the second sub-array.</param>
        public static void Merge(int[] input, int start, int mid, int end)
        {
            // Calculate the sizes of the two sub-arrays
            int l = mid - start + 1;
            int r = end - mid;

            // Create temporary arrays to hold the elements of the two sub-arrays
            int[] left = new int[l];
            int[] right = new int[r];

            // Copy elements to the temporary arrays
            for (int i = 0; i < l; i++)
            {
                left[i] = input[start + i];
            }

            for (int j = 0; j < r; j++)
            {
                right[j] = input[mid + 1 + j];
            }

            // Merge the two sub-arrays back into the original array
            int il = 0; // Index for the left array
            int ir = 0; // Index for the right array
            int im = start; // Index for the merged array

            while (il < l && ir < r)
            {
                // Compare elements from the left and right arrays and merge them in ascending order
                if (left[il] <= right[ir])
                {
                    input[im] = left[il];
                    il++;
                }
                else
                {
                    input[im] = right[ir];
                    ir++;
                }
                im++;
            }

            // Copy any remaining elements from the left array
            while (il < l)
            {
                input[im] = left[il];
                il++;
                im++;
            }

            // Copy any remaining elements from the right array
            while (ir < r)
            {
                input[im] = right[ir];
                ir++;
                im++;
            }
        }

        /// <summary>
        /// Recursively sorts an array using the MergeSort algorithm.
        /// </summary>
        /// <param name="input">The input array to be sorted.</param>
        /// <param name="start">The start index of the range to be sorted.</param>
        /// <param name="end">The end index of the range to be sorted.</param>
        private static void MSort(int[] input, int start, int end)
        {
            // Base case: If the start index is less than the end index
            if (start < end)
            {
                // Calculate the middle index
                int mid = (start + end) / 2;

                // Recursively sort the left and right halves
                MSort(input, start, mid);
                MSort(input, mid + 1, end);

                // Merge the sorted halves
                Merge(input, start, mid, end);
            }
        }

        /// <summary>
        /// Sorts an array using the MergeSort algorithm.
        /// </summary>
        /// <param name="input">The input array to be sorted.</param>
        /// <returns>The sorted array.</returns>
        public static int[] MergeSort(int[] input)
        {
            // Create a copy of the input array
            int[] copy = Copy(input);

            // Call the recursive MergeSort method on the entire array
            MSort(copy, 0, copy.Length - 1);

            // Return the sorted array
            return copy;
        }
        #endregion

        #endregion
    }
}