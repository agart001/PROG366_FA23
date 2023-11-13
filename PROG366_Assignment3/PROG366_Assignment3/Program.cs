using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Xml;

namespace PROG366_Assignment3
{
    internal class Program
    {
        public static string PathToData {  get; set; }

        static void Main(string[] args)
        {
            PathToData = $"{Directory.GetCurrentDirectory()}\\data.xml";

            dynamic[][] data_array = ReadIntoArray();

            Hashtable data_table = ReadIntoHashtable();

            Stack<Tuple<dynamic, dynamic>> data_stack = ReadIntoStack();

            Queue<Tuple<dynamic, dynamic>> data_queue = ReadIntoQueue();

            Console.WriteLine("Array: Indexing, Fixed size and data, multiple type");
            PrintCollection(data_array);
            Console.WriteLine("Use Case: fixed sized data sets and the ability to quickly index into each value");
            Console.Write("\n");

            Console.WriteLine("Hashtable: Keys and Values, dyanmic size and fixed data, 1 type");
            PrintHash(data_table);
            Console.WriteLine("Use Case: changing data sets that shift and can be accessed by key, value, or code");
            Console.Write("\n");

            Console.WriteLine("Stack: LIFO (Last In First Out), dynamic data and size, 1 type");
            PrintStack(data_stack);
            Console.WriteLine("Use Case: changing data sets with multiple types" +
                ", ordered by first entered to last entered");
            Console.Write("\n");

            Console.WriteLine("Queue: FIFO (First In First Out), dyanmic data and size, multiple type");
            PrintStack(data_queue);
            Console.WriteLine("Use Case: changing data sets with multiple types" +
                ", ordered by last entered to first entered");
            Console.Write("\n");

            Console.WriteLine("Best Uses: Arrays/Hashtables are better for storing large amounts of permanent data." +
                "Stacks/Queues are best for storing small amounts of temporary data.");
        }

        public static dynamic[][] ReadIntoArray()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(PathToData);
            XmlNode root = xml.DocumentElement;
            XmlNodeList pairs = root.SelectNodes("/pairs/pair");
            xml.AppendChild(root);

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

        public static Hashtable ReadIntoHashtable()
        {
            Hashtable hashtable = new Hashtable();

            XmlDocument xml = new XmlDocument();
            xml.Load(PathToData);
            XmlNode root = xml.DocumentElement;
            XmlNodeList pairs = root.SelectNodes("/pairs/pair");
            xml.AppendChild(root);

            foreach (XmlElement pair in pairs)
            {
                string s_key = pair.GetAttribute("key");
                int key = int.Parse(s_key);
                string value = pair.GetAttribute("value");

                hashtable[key] = value;
            }

            return hashtable;
        }

        public static Stack<Tuple<dynamic, dynamic>> ReadIntoStack()
        {
            Stack<Tuple<dynamic, dynamic>> stack = new Stack<Tuple<dynamic, dynamic>>();

            XmlDocument xml = new XmlDocument();
            xml.Load(PathToData);
            XmlNode root = xml.DocumentElement;
            XmlNodeList pairs = root.SelectNodes("/pairs/pair");
            xml.AppendChild(root);

            foreach (XmlElement pair in pairs)
            {
                string s_key = pair.GetAttribute("key");
                int key = int.Parse(s_key);
                string value = pair.GetAttribute("value");
                
                stack.Push(new Tuple<dynamic, dynamic>(key, value));
            }

            return stack;
        }

        public static Queue<Tuple<dynamic, dynamic>> ReadIntoQueue()
        {
            Queue<Tuple<dynamic, dynamic>> queue = new Queue<Tuple<dynamic, dynamic>>();

            XmlDocument xml = new XmlDocument();
            xml.Load(PathToData);
            XmlNode root = xml.DocumentElement;
            XmlNodeList pairs = root.SelectNodes("/pairs/pair");
            xml.AppendChild(root);

            foreach (XmlElement pair in pairs)
            {
                string s_key = pair.GetAttribute("key");
                int key = int.Parse(s_key);
                string value = pair.GetAttribute("value");

                queue.Enqueue(new Tuple<dynamic, dynamic>(key, value));
            }

            return queue;
        }

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

        public static int GetElementCount(dynamic set)
        {
            int count = 0;
            foreach(object val in set)
            {
                count++;
            }
            return count;
        }

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

        public static void PrintStack(IEnumerable dataset)
        {
            int index = 0;
            foreach(dynamic set in dataset)
            {
                Console.WriteLine($"Data Index({index}) : {set}");
                index++;
            }
        }
    }
}