using System.Collections.ObjectModel;
using System.IO;

namespace VS22_ConsoleApp.Utility
{
    /// <summary>
    /// A utility class for file input/output operations.
    /// </summary>
    public static class U_IO
    {
        /// <summary>
        /// Reads the contents of a file and returns them as a collection of strings.
        /// </summary>
        /// <param name="file">The name of the file to be read.</param>
        /// <returns>A collection of strings representing the lines of the file.</returns>
        public static ICollection<string> ReadFile(string file)
        {
            string path = $"{Directory.GetCurrentDirectory()}\\{file}";
            ICollection<string> contents = File.ReadAllLines(path);
            return contents;
        }

        /// <summary>
        /// Writes the specified contents to a file, overwriting the existing file if it exists.
        /// </summary>
        /// <param name="contents">The collection of strings to be written to the file.</param>
        /// <param name="outputfile">The name of the file to which the contents will be written.</param>
        public static void WriteFile(ICollection<string> contents, string outputfile)
        {
            ClearFile(outputfile);
            string path = $"{Directory.GetCurrentDirectory()}\\{outputfile}";
            File.WriteAllLines(path, contents);
        }

        /// <summary>
        /// Clears (deletes) a file if it exists.
        /// </summary>
        /// <param name="path">The path of the file to be cleared.</param>
        public static void ClearFile(string path)
        {
            if (File.Exists(path) == false) { return; }
            File.Delete(path);
        }
    }
}
