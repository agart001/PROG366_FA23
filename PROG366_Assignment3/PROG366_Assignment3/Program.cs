using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Xml;

namespace PROG366_Assignment3
{
    /// <summary>
    /// The main program class for reading data from XML, processing it into different data structures, and printing the results.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Gets or sets the path to the data XML file.
        /// </summary>
        public static string PathToData { get; set; }

        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">Command-line arguments (not used in this program).</param>
        static void Main(string[] args)
        {
            PathToData = $"{Directory.GetCurrentDirectory()}\\data.xml";

            dynamic[][] data_array = ReadIntoArray();

            Hashtable data_table = ReadIntoHashtable();

            Stack<Tuple<dynamic, dynamic>> data_stack = ReadIntoStack();

            Queue<Tuple<dynamic, dynamic>> data_queue = ReadIntoQueue();

            Console.WriteLine("Array: Indexing, Fixed size and data, multiple type");
            PrintCollection(data_array);
            Console.WriteLine("Use Case: fixed-sized data sets and the ability to quickly index into each value");
            Console.Write("\n");

            Console.WriteLine("Hashtable: Keys and Values, dynamic size and fixed data, 1 type");
            PrintHash(data_table);
            Console.WriteLine("Use Case: changing data sets that shift and can be accessed by key, value, or code");
            Console.Write("\n");

            Console.WriteLine("Stack: LIFO (Last In First Out), dynamic data and size, 1 type");
            PrintStack(data_stack);
            Console.WriteLine("Use Case: changing data sets with multiple types, ordered by first entered to last entered");
            Console.Write("\n");

            Console.WriteLine("Queue: FIFO (First In First Out), dynamic data and size, multiple types");
            PrintStack(data_queue);
            Console.WriteLine("Use Case: changing data sets with multiple types, ordered by last entered to first entered");
            Console.Write("\n");

            Console.WriteLine("Best Uses: Arrays/Hashtables are better for storing large amounts of permanent data. Stacks/Queues are best for storing small amounts of temporary data.");
        }

        /// <summary>
        /// Reads data from the XML file and stores it in an array of dynamic arrays.
        /// </summary>
        /// <returns>An array of dynamic arrays containing the data.</returns>
        public static dynamic[][] ReadIntoArray()
        {
            XmlNodeList pairs = GetNodeList("/pairs/pair");
            dynamic[][] array = new dynamic[pairs.Count][];

            int index = 0;
            foreach (XmlElement pair in pairs)
            {
                string s_key = pair.GetAttribute("key");
                int key = int.Parse(s_key);
                string value = pair.GetAttribute("value");

                array[index] = new dynamic[] { key, value };
                index++;
            }

            return array;
        }

        /// <summary>
        /// Reads data from the XML file and stores it in a Hashtable.
        /// </summary>
        /// <returns>A Hashtable containing the data.</returns>
        public static Hashtable ReadIntoHashtable()
        {
            Hashtable hashtable = new Hashtable();
            XmlNodeList pairs = GetNodeList("/pairs/pair");

            foreach (XmlElement pair in pairs)
            {
                string s_key = pair.GetAttribute("key");
                int key = int.Parse(s_key);
                string value = pair.GetAttribute("value");

                hashtable[key] = value;
            }

            return hashtable;
        }

        /// <summary>
        /// Reads data from the XML file and stores it in a Stack of Tuple objects.
        /// </summary>
        /// <returns>A Stack of Tuple objects containing the data.</returns>
        public static Stack<Tuple<dynamic, dynamic>> ReadIntoStack()
        {
            Stack<Tuple<dynamic, dynamic>> stack = new Stack<Tuple<dynamic, dynamic>>();
            XmlNodeList pairs = GetNodeList("/pairs/pair");

            foreach (XmlElement pair in pairs)
            {
                string s_key = pair.GetAttribute("key");
                int key = int.Parse(s_key);
                string value = pair.GetAttribute("value");

                stack.Push(new Tuple<dynamic, dynamic>(key, value));
            }

            return stack;
        }

        /// <summary>
        /// Reads data from the XML file and stores it in a Queue of Tuple objects.
        /// </summary>
        /// <returns>A Queue of Tuple objects containing the data.</returns>
        public static Queue<Tuple<dynamic, dynamic>> ReadIntoQueue()
        {
            Queue<Tuple<dynamic, dynamic>> queue = new Queue<Tuple<dynamic, dynamic>>();
            XmlNodeList pairs = GetNodeList("/pairs/pair");

            foreach (XmlElement pair in pairs)
            {
                string s_key = pair.GetAttribute("key");
                int key = int.Parse(s_key);
                string value = pair.GetAttribute("value");

                queue.Enqueue(new Tuple<dynamic, dynamic>(key, value));
            }

            return queue;
        }

        /// <summary>
        /// Gets a string representation of the elements in a dynamic set.
        /// </summary>
        /// <param name="set">The dynamic set to be converted to a string.</param>
        /// <returns>A string representation of the elements in the set.</returns>
        public static string GetSetString(dynamic set)
        {
            string s_vals = "(";
            int i = 0;
            int len = GetElementCount(set);
            foreach (object val in set)
            {
                if (i == len - 1)
                {
                    s_vals += $"{val}";
                }
                else { s_vals += $"{val}, "; }
                i++;
            }
            s_vals += ")";

            return s_vals;
        }

        /// <summary>
        /// Gets the count of elements in a dynamic set.
        /// </summary>
        /// <param name="set">The dynamic set for which to count the elements.</param>
        /// <returns>The count of elements in the set.</returns>
        public static int GetElementCount(dynamic set)
        {
            int count = 0;
            foreach (object val in set)
            {
                count++;
            }
            return count;
        }

        /// <summary>
        /// Prints the elements in a collection.
        /// </summary>
        /// <param name="dataset">The collection to be printed.</param>
        public static void PrintCollection(IEnumerable dataset)
        {
            int index = 0;
            foreach (dynamic set in dataset)
            {
                string s_vals = GetSetString(set);
                Console.WriteLine($"Data Index ({index}): {s_vals} ");
                index++;
            }
        }

        /// <summary>
        /// Prints the key-value pairs in a Hashtable.
        /// </summary>
        /// <param name="hash">The Hashtable containing key-value pairs to be printed.</param>
        public static void PrintHash(Hashtable hash)
        {
            int index = 0;
            foreach (DictionaryEntry entry in hash)
            {
                string key = entry.Key.ToString();
                string value = entry.Value.ToString();
                Console.WriteLine($"Data Index ({index}): ({key}, {value}) ");
                index++;
            }
        }

        /// <summary>
        /// Prints the elements in a collection as a stack.
        /// </summary>
        /// <param name="dataset">The collection to be printed as a stack.</param>
        public static void PrintStack(IEnumerable dataset)
        {
            int index = 0;
            foreach (dynamic set in dataset)
            {
                Console.WriteLine($"Data Index({index}) : {set}");
                index++;
            }
        }

        /// <summary>
        /// Retrieves a list of XML nodes matching the specified XPath expression.
        /// </summary>
        /// <param name="nodes">The XPath expression to select nodes in the XML document.</param>
        /// <returns>An XMLNodeList containing the selected nodes.</returns>
        public static XMLNodeList GetNodeList(string nodes)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(PathToData);
            XmlNode root = xml.DocumentElement;
            XMLNodeList nodesList = root.SelectNodes(nodes);
            xml.AppendChild(root);

            return nodesList;
        }
    }
}
