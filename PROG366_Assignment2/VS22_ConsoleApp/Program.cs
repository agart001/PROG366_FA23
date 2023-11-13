using static VS22_ConsoleApp.Utility.U_Console;
using static VS22_ConsoleApp.Utility.U_IO;
using static VS22_ConsoleApp.Utility.U_Shuffle;

namespace VS22_ConsoleApp
{
    /// <summary>
    /// The main program class for reading an unshuffled file, shuffling its contents, and writing the shuffled contents to a file.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">Command-line arguments (not used in this program).</param>
        static void Main(string[] args)
        {
            Print("Start program!");

            Print("Read unshuffled file");
            ICollection<string> unshuffled = ReadFile("unshuffled.txt");

            Print("Shuffled contents");
            ICollection<string> shuffled = FYShuffle(unshuffled);

            Print("Write shuffled contents to file");
            WriteFile(shuffled, "shuffled.txt");
        }
    }
}
