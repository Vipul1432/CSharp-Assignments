using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    public class BackgroundOperation
    {
        /// <summary>
        /// Writes a message to a file asynchronously with a simulated delay.
        /// </summary>
        /// <param name="message">The message to be written to the file.</param>
        /// <returns>An asynchronous task representing the file writing operation.</returns>
        public async Task WriteToFileAsync(string message)
        {
            try
            {
                Console.WriteLine("Writing to file...");
                await Task.Delay(3000);
                string filePath = Path.Combine("C:", "Users", "admin", "source", "repos", "Assignment-1", "Assignment-5", "tmp.txt");
                await File.WriteAllTextAsync(filePath, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during file writing: {ex.Message}");
            }
        }
    }
}
