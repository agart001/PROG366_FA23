using System.Collections.ObjectModel;

namespace VS22_ConsoleApp.Utility
{
    /// <summary>
    /// A utility class for shuffling collections.
    /// </summary>
    public static class U_Shuffle
    {
        /// <summary>
        /// Shuffles the elements of a collection using the Fisher-Yates algorithm.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="unshuffled">The unshuffled collection to be shuffled.</param>
        /// <returns>A shuffled collection of the same type as the input.</returns>
        public static ICollection<T> FYShuffle<T>(ICollection<T> unshuffled)
        {
            Random rand = new Random();

            T[] unshuf_arr = new T[unshuffled.Count];
            unshuffled.CopyTo(unshuf_arr, 0);

            for (int i = unshuf_arr.Length - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);

                T temp = unshuf_arr[i];
                unshuf_arr[i] = unshuf_arr[j];
                unshuf_arr[j] = temp;
            }

            return unshuf_arr;
        }
    }
}
