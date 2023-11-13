using System.Collections.ObjectModel;
using System.IO;

namespace VS22_ConsoleApp.Utility
{
    
    public static class U_IO
    {
        

        public static ICollection<string> ReadFile(string file)
        {
            string path = $"{Directory.GetCurrentDirectory()}\\{file}";
            
            ICollection<string> contents = File.ReadAllLines(path);

            return contents;
        }


        public static void WriteFile(ICollection<string> contents, string outputfile)
        {
            ClearFile(outputfile);

            string path = $"{Directory.GetCurrentDirectory()}\\{outputfile}";

            File.WriteAllLines(path, contents);
        }


        public static void ClearFile(string path)
        {
            if (File.Exists(path) == false) { return; }

            File.Delete(path);
        }

    }

}