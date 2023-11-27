namespace Assignment_5
{
    public class Program
    {
        private static BackgroundOperation backgroundOperation = new BackgroundOperation();

        public static async Task Main()
        {
            try
            {
                ShowMenu();
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int choice))
                {
                    await ExecuteNonBlockingOperation(choice);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Displays the menu options for the Kiosk system.
        /// </summary>
        private static void ShowMenu()
        {
            Console.WriteLine("Kiosk Menu:");
            Console.WriteLine("1. Write \"Hello World\"");
            Console.WriteLine("2. Write Current Date");
            Console.WriteLine("3. Write OS Version");
            Console.Write("Enter your choice (1, 2, or 3): ");
        }

        /// <summary>
        /// Executes the chosen non-blocking operation based on user input. Retrieves the appropriate message,
        /// performs the non-blocking write operation, and handles exceptions if they occur.
        /// </summary>
        /// <param name="choice">The user's menu choice.</param>
        private static async Task ExecuteNonBlockingOperation(int choice)
        {
            string message = GetMessageBasedOnChoice(choice);

            try
            {
                Console.WriteLine("Performing non-blocking operation...");
                await backgroundOperation.WriteToFileAsync(message);
                Console.WriteLine("Operation completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the operation: {ex.Message}");
            }
        }

        /// <summary>
        /// Returns a message based on the user's menu choice. 
        /// </summary>
        /// <param name="choice">The user's menu choice.</param>
        /// <returns>A message corresponding to the user's choice.</returns>
        private static string GetMessageBasedOnChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    return "Hello World";
                case 2:
                    return DateTime.Now.ToString();
                case 3:
                    return Environment.OSVersion.VersionString;
                default:
                    throw new ArgumentException("Invalid choice.");
            }
        }
    }
}