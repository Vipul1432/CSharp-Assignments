namespace Assignment_6
{
    public class Program
    {
        static async Task Main()
        {
            try
            {
                Console.Write("Enter URL: ");
                string url = Console.ReadLine();

                string content = await DownloadContentAsync(url);

                string filePath = Path.Combine("C:", "Users", "admin", "source", "repos", "Assignment-1", "Assignment-6", "A.txt");
                await WriteToFileAsync(filePath, content);

                Console.WriteLine("Content downloaded and written to A.txt successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Downloads the content from the specified URL asynchronously using HttpClient.
        /// </summary>
        /// <param name="url">The URL from which to download the content.</param>
        /// <returns>A Task representing the asynchronous operation, returning the downloaded content as a string.</returns>
        /// <remarks>Handles exceptions that may occur during the HTTP request.</remarks>
        static async Task<string> DownloadContentAsync(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    return await client.GetStringAsync(url);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during content download: {ex.Message}");
                return string.Empty; // or handle the error in an appropriate way for your application
            }
        }

        /// <summary>
        /// Writes the specified content to a file asynchronously.
        /// </summary>
        /// <param name="message">The content to write to the file.</param>
        /// <returns>A Task representing the asynchronous file writing operation.</returns>
        /// <remarks>Handles exceptions that may occur during the file writing process.</remarks>
        static async Task WriteToFileAsync(string fileName, string content)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    await writer.WriteAsync(content);
                }
                Console.WriteLine($"Content written to {fileName} successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during file writing: {ex.Message}");
            }
        }
    }
}