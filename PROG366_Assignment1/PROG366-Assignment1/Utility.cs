using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG366_Assignment1
{
    public static class Utility
    {
        public static void Print(string input, bool newline)
        {
            if(newline)
            {
                Console.WriteLine(input);
            }
            else
            {
                Console.Write(input);
            }
        }

        public static string IsTrue(bool toCheck)
        {
            bool check = false;
            string result = "Is False";

            if (toCheck != check) result = "Is True";

            return result;
        }

        public static void EnumerablePrintAll<T>(IEnumerable<T> enumerable)
        {
            int index = 0;
            foreach (T value in enumerable) 
            {
                Print($"{index + 1} : {value}", true);
            }
        }

        public static void EnumerablePrintCounts<T>(IEnumerable<T> enumerable)
        {
            IEnumerable<T> distinct = enumerable.Distinct();


            foreach(T distinctvalue in distinct)
            {
                int count = 0;
                foreach(T value in enumerable)
                {
                    if(value.Equals(distinctvalue)) count += 1;
                }

                Print($"{distinctvalue} : {count}", true);
            }
        }
    }
}
