using static PROG366_Assignment1.Utility;

namespace PROG366_Assignment1
{
    /// <summary>
    /// The main program class for demonstrating different time complexities.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">Command-line arguments (not used in this program).</param>
        static void Main(string[] args)
        {
            Print("O(1) Example:", true);
            Print("IsTrue() Checks if a boolean value is true. n = 1, it is called once", true);
            bool O1 = true;
            Print(IsTrue(O1), true);

            Print(Environment.NewLine, false);

            Print("O(n) Example:", true);
            Print($"EnumerablePrintAll() prints all the values in an enumerable sequence.{Environment.NewLine}The 'n' is linear, and the execution time is determined by the length of the sequence.", true);
            bool[] On = new bool[] { true, false, true, false, true };
            EnumerablePrintAll(On);

            Print(Environment.NewLine, false);

            Print("O(n^2) Example:", true);
            Print($"EnumerablePrintCounts() prints all the counts of each distinct value in an enumerable sequence.{Environment.NewLine}The 'n' is quadratic, and the execution time is determined by the number of distinct values and the length of the sequence.", true);

            EnumerablePrintCounts(On);
        }
    }
}
