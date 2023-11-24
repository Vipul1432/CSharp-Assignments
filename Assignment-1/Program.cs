namespace Assignment_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Employee Details:");
                Console.Write("Id: ");
                int id = ReadIntFromConsole();

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Department Name: ");
                string departmentName = Console.ReadLine();

                // Creating an object of the Employee class
                Employee employee = new Employee(id, name, departmentName);

                // Subscribing to the event
                employee.MethodCalled += Employee_MethodCalled;

                // Printing details using getter methods
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nEmployee Details:");
                Console.WriteLine($"ID: {employee.GetId()}");
                Console.WriteLine($"Name: {employee.GetName()}");
                Console.WriteLine($"Department Name: {employee.GetDepartmentName()}");
                Console.ForegroundColor = ConsoleColor.White;

                // Ask the user if they want to update any property in a loop
                bool updateOption = true;
                while (updateOption)
                {
                    Console.Write("\nDo you want to update any property? (Y/N): ");
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        // Ask which property to update
                        Console.Write("Enter property to update (Id, Name, or DepartmentName): ");
                        string propertyToUpdate = Console.ReadLine();

                        // Update the chosen property
                        if (propertyToUpdate.Equals("Id", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.Write("Enter new Id: ");
                            int newId = ReadIntFromConsole();
                            employee.UpdateId(newId);
                        }
                        else if (propertyToUpdate.Equals("Name", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.Write("Enter new Name: ");
                            string newName = Console.ReadLine();
                            employee.UpdateName(newName);
                        }
                        else if (propertyToUpdate.Equals("DepartmentName", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.Write("Enter new Department Name: ");
                            string newDepartmentName = Console.ReadLine();
                            employee.UpdateDepartmentName(newDepartmentName);
                        }
                        else
                        {
                            Console.WriteLine("Invalid property name.");
                        }

                        // Print updated details using getter methods
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nUpdated Employee Details:");
                        Console.WriteLine($"ID: {employee.GetId()}");
                        Console.WriteLine($"Name: {employee.GetName()}");
                        Console.WriteLine($"Department Name: {employee.GetDepartmentName()}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        // Exit the loop if the user chooses not to update
                        updateOption = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Reads an integer input from the console, continuously prompting the user until a valid integer is entered.
        /// If the input is not a valid integer, an error message is displayed in red.
        /// </summary>
        /// <returns>The valid integer entered by the user.</returns>
        private static int ReadIntFromConsole()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        /// <summary>
        /// Event handler method for the MethodCalled event in the Employee class.
        /// Displays a message in blue indicating that a method has been called in the Employee class.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>

        private static void Employee_MethodCalled(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Event: Method called in Employee class");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
