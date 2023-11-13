using static VS22_ConsoleApp.Utility.U_Console;
using static VS22_ConsoleApp.Utility.U_IO;
using static VS22_ConsoleApp.Utility.U_Shuffle;

namespace VS22_ConsoleApp
{
    internal class Program
    {
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