using System.Collections.ObjectModel;

namespace VS22_ConsoleApp.Utility
{

    public static class U_Shuffle
    {

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