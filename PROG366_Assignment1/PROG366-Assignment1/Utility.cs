using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG366_Assignment1
{
    /// <summary>
    /// A utility class containing various helper methods.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Prints the specified input to the console.
        /// </summary>
        /// <param name="input">The input string to be printed.</param>
        /// <param name="newline">Set to <c>true</c> to print with a newline, or <c>false</c> to print without a newline.</param>
        public static void Print(string input, bool newline)
        {
            if (newline)
            {
                Console.WriteLine(input);
            }
            else
            {
                Console.Write(input);
            }
        }

        /// <summary>
        /// Checks if the specified boolean value is true.
        /// </summary>
        /// <param name="toCheck">The boolean value to check.</param>
        /// <returns>Returns "Is True" if the value is true, otherwise "Is False."</returns>
        public static string IsTrue(bool toCheck)
        {
            bool check = false;
            string result = "Is False";

            if (toCheck != check) result = "Is True";

            return result;
        }

        /// <summary>
        /// Prints all elements in an enumerable with their indices.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable to print.</param>
        public static void EnumerablePrintAll<T>(IEnumerable<T> enumerable)
        {
            int index = 0;
            foreach (T value in enumerable)
            {
                Print($"{index + 1} : {value}", true);
            }
        }

        /// <summary>
        /// Prints the counts of distinct elements in an enumerable.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable to analyze and print counts for distinct elements.</param>
        public static void EnumerablePrintCounts<T>(IEnumerable<T> enumerable)
        {
            IEnumerable<T> distinct = enumerable.Distinct();

            foreach (T distinctvalue in distinct)
            {
                int count = 0;
                foreach (T value in enumerable)
                {
                    if (value.Equals(distinctvalue)) count += 1;
                }

                Print($"{distinctvalue} : {count}", true);
            }
        }
    }

}
