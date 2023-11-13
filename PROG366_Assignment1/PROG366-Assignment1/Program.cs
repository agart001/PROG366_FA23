using static PROG366_Assignment1.Utility;

namespace PROG366_Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Print("O(1) Example:", true);
            Print("IsTrue() Checks if a boolean value is true. n = 1, it is called once", true);
            bool O1 = true;
            Print(IsTrue(O1), true);

            Print(Environment.NewLine, false);

            Print("O(n) Example:", true);
            Print($"EnumerablePrintAll() prints all the values in an enumerable sequence.{Environment.NewLine}The n is linear, the execution is determined length of the sequence", true);
            bool[] On = new bool[] { true, false, true, false, true};
            EnumerablePrintAll(On);

            Print(Environment.NewLine, false);

            Print("O(n^2) Example:", true);
            Print($"EnumerablePrintsCounts() prints all the counts of each distinct values in an enumerable sequence.{Environment.NewLine}The n is quadratic, the execution is deteremined by the number of distinct and the length of the sequence", true);

            EnumerablePrintCounts(On);
        }
    }
}