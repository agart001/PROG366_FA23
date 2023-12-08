using System.ComponentModel;
using System.Diagnostics;

namespace PROG366_Assignment6
{
    internal class Program
    {
        #region Main
        /// <summary>
        /// The path to the data file.
        /// </summary>
        static string Path;

        static void Main(string[] args)
        {
            #region Read Data/Sort
            Path = $"{Directory.GetCurrentDirectory()}\\scores.txt";
            string[] lines = File.ReadAllLines(Path);
            int[] scores = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                int num = int.Parse(lines[i]);
                scores[i] = num;
            }

            int target = 72;
            int[] ordered = scores.OrderBy(x => x).ToArray();
            #endregion

            #region Introduction
            Print(new string[]
            {
                "----------------------------------------------",
                "PROG366, Assignment 6: Searching Algorithms:",
                "----------------------------------------------",
                "The assignment demonstrates the following: ",
                " - Linear Search.",
                " - Binary Search.",
                " - Interpolation Search",
                "----------------------------------------------",
                "Dataset:",
                " - Name: scores.txt.",
                " - Type: integer.",
                $" - Length: {scores.Length + 1}",
                " - Order: Ascending.",
                "----------------------------------------------",
                $"Target: {target}.",
                "----------------------------------------------"
            });

            Print(new string[]
            {
                Environment.NewLine,
                Environment.NewLine
            });
            #endregion

            #region Linear Search
            Print(new string[]
            {
                "----------------------------------------------",
                "The Linear Search:",
                "----------------------------------------------",
                "Definition: A searching algorithm which checks",
                "each element of a dataset sequentially.",
                "----------------------------------------------"
            });
            int linear = SearchExecutionTime(LinearSearch, ordered, target);
            Console.WriteLine($"Index: {linear}");
            Console.WriteLine($"Element: {ordered.ElementAt(linear)}");
            Console.WriteLine($"Near Elements(-5/+5):{Environment.NewLine}{ElementsInRange(ordered, linear, 5)}");
            Print(new string[]
            {
                "----------------------------------------------",
                "Big O Notation:",
                " - Worst: O(n)",
                " - Best: O(1)",
                " - Average: O(n/2)",
                "----------------------------------------------",
                "Strengths:",
                " - Simple.",
                " - Small datasets.",
                " - Easy integration into larger methods.",
                "----------------------------------------------",
                "Weaknesses:",
                " - Inefficient.",
                " - Large datasets.",
                " - Does not mesh with expanding datasets.",
                "----------------------------------------------"
            });

            Print(new string[]
            {
                Environment.NewLine,
                Environment.NewLine
            });
            #endregion

            #region Binary Search
            Print(new string[]
            {
                "----------------------------------------------",
                "The Binary Search:",
                "----------------------------------------------",
                "Definition: A searching algorithm which",
                "compares the value in the middle of the dataset set",
                "to the value being targeted for. If the values",
                "are equal, the target has been found.",
                "----------------------------------------------"
            });
            int binary = SearchExecutionTime(BinarySearch, ordered, target);
            Console.WriteLine($"Index: {binary}");
            Console.WriteLine($"Element: {ordered.ElementAt(binary)}");
            Console.WriteLine($"Near Elements(-5/+5):{Environment.NewLine}{ElementsInRange(ordered, binary, 5)}");
            Print(new string[]
            {
                "----------------------------------------------",
                "Big O Notation:",
                " - Worst: O(log n)",
                " - Best: O(1)",
                " - Average: O(log n)",
                "----------------------------------------------",
                "Strengths:",
                " - Early termination.",
                " - Sorted datasets.",
                " - Simplicity in context.",
                "----------------------------------------------",
                "Weaknesses:",
                " - Dynamic data.",
                " - Unsorted datasets.",
                " - Sorting is required.",
                "----------------------------------------------"
            });

            Print(new string[]
            {
                Environment.NewLine,
                Environment.NewLine
            });
            #endregion

            #region Interpolation Search
            Print(new string[]
            {
                "----------------------------------------------",
                "The Interpolation Search:",
                "----------------------------------------------",
                "Definition: A searching algorithm which",
                "compares the value in a interpolated position",
                "of the dataset set to the value being targeted",
                "for. If the values are equal, the target has",
                "been found.",
                "----------------------------------------------"
            });
            int interpolation = SearchExecutionTime(InterpolationSearch, ordered, target);
            Console.WriteLine($"Index: {interpolation}");
            Console.WriteLine($"Element: {ordered.ElementAt(interpolation)}");
            Console.WriteLine($"Near Elements(-5/+5):{Environment.NewLine}{ElementsInRange(ordered, interpolation, 5)}");
            Print(new string[]
            {
                "----------------------------------------------",
                "Big O Notation:",
                " - Worst: O(n)",
                " - Best: O(1)",
                " - Average: O(log log n)",
                "----------------------------------------------",
                "Strengths:",
                " - Adaptable.",
                " - Potential convergence speed.",
                " - Versatile with sorted data.",
                "----------------------------------------------",
                "Weaknesses:",
                " - Degradation.",
                " - Misinterpretation.",
                " - Adds additional complexity/time.",
                "----------------------------------------------"
            });
            #endregion
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Prints an array of strings.
        /// </summary>
        /// <param name="lines">The array of strings to be printed.</param>
        static void Print(string[] lines) 
        {
            foreach(string line in lines)
            {
                Console.WriteLine(line);
            }
        }

        /// <summary>
        /// Executes A searching algorithm and measures its execution time.
        /// </summary>
        /// <param name="method">The searching method to execute.</param>
        /// <param name="dataset">The input dataset.</param>
        /// <param name="target">The input target value.</param>
        /// <returns>The index of the first instance of the target parameter.</returns>
        static int SearchExecutionTime<T>(Func<IEnumerable<T>, T, int> method, IEnumerable<T> dataset, T target)
        {
            // Stopwatch is used to measure the execution time of the sorting method
            Stopwatch sw = new Stopwatch();

            try
            {
                sw.Start();

                // Call the sorting method
                return method(dataset, target);
            }
            finally
            {
                sw.Stop();

                // Print the execution time to the console
                Console.WriteLine($"Execution Time: {sw.Elapsed}");
            }
        }

        /// <summary>
        /// Generates a string containing elements within a range of an index in a dataset.
        /// </summary>
        /// <param name="dataset">The input dataset.</param>
        /// <param name="index">The input index</param>
        /// <param name="range">The element range</param>
        /// <returns>A string of dataset elements centered around an index.</returns>
        static string ElementsInRange<T>(IEnumerable<T> dataset, int index, int range)
        {
            string elements = "";
            int left = index - range;
            int right = index + range;

            for(int i = left; i < right; i++)
            {
                T current = dataset.ElementAt(i);

                if(i == left) { elements += "|"; }
                
                if(i == index)
                {
                    elements += $"({current})";
                }
                else
                {
                    elements += $"|{current}|";
                }

                if (i == right) { elements += "|"; }
            }

            return elements;
        }
        #endregion Utilities

        #region Linear Search
        /// <summary>
        /// A searching algorithm which checks each element of a dataset sequentially.
        /// </summary>
        /// <param name="dataset">The input dataset.</param>
        /// <param name="target">The input target value.</param>
        /// <returns>The index of the first instance of the target in the dataset.</returns>
        static int LinearSearch<T>(IEnumerable<T> dataset, T target)
        {
            int index = 0;
            int len = dataset.Count();

            for (int i = 0; i < len; i++)
            {
                T current = dataset.ElementAt(i) ?? throw new ArgumentNullException(nameof(dataset));
                if (current.Equals(target))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
        #endregion

        #region Binary Search
        /// <summary>
        /// A searching algorithm which compares the value in the middle of the dataset set to the value being targeted for.
        /// If the values are equal, the target has been found.
        /// </summary>
        /// <param name="dataset">The input dataset.</param>
        /// <param name="target">The input target value.</param>
        /// <returns>The index of the first instance of the target in the dataset.</returns>
        static int BinarySearch<T>(IEnumerable<T> dataset, T target) where T : IComparable<T>
        {
            int index = 0;
            int len = dataset.Count();

            int left = 0;
            int right = len - 1;

            while (left < right)
            {
                int mid = (left + right) / 2;
                T current = dataset.ElementAt(mid);
                int comp = current.CompareTo(target);

                switch (comp)
                {
                    case -1: left = mid + 1; break;
                    case 1: right = mid - 1; break;
                    case 0: index = mid; break;
                }

                if (comp == 0) break;
            }

            return index;
        }
        #endregion

        #region Interpolation Search
        /// <summary>
        /// A searching algorithm which compares the value in a interpolated position of the dataset set to the value being targeted for.
        /// If the values are equal, the target has been found.
        /// </summary>
        /// <param name="dataset">The input dataset.</param>
        /// <param name="target">The input target value.</param>
        /// <returns>The index of the first instance of the target in the dataset.</returns>
        static int InterpolationSearch<T>(IEnumerable<T> dataset, T target) where T : IComparable<T>, IConvertible
        {
            int index = 0;
            int len = dataset.Count();

            int left = 0;
            int right = len - 1;

            while (left < right)
            {
                int pos = InterpolationPosition(dataset, target, left, right);
                T current = dataset.ElementAt(pos);
                int comp = current.CompareTo(target);
                switch (comp)
                {
                    case -1: left = pos + 1; break;
                    case 1: right = pos - 1; break;
                    case 0: index = pos; break;
                }

                if(comp == 0) break;
            }

            return index;
        }

        /// <summary>
        /// A method which returns the interpolation position of a dataset.
        /// </summary>
        /// <param name="dataset">The input dataset.</param>
        /// <param name="target">The input target value.</param>
        /// <param name="left">The left search index.</param>
        /// <param name="right">The right search index.</param>
        /// <returns>The interpolation position.</returns>
        static int InterpolationPosition<T>(IEnumerable<T> dataset, T target, int left, int right) where T : IConvertible
        {
            T l_el = dataset.ElementAt(left);
            T r_el = dataset.ElementAt(right);
            if (target is not IConvertible && l_el is not IConvertible && r_el is not IConvertible)
                throw new InvalidCastException(nameof(InterpolationSearch));

            int pos = 0;
            double t = Convert.ToDouble(target);
            double l = Convert.ToDouble(l_el);
            double r = Convert.ToDouble(r_el);

            double fraction = (t - r) / (l - r);
            double interpolated = fraction * (r - l);
            pos = left + (int)interpolated;

            return pos;
        }
        #endregion
    }
}