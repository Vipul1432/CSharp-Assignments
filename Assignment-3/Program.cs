namespace Assignment_3
{
    public class Program
    {
        static void Main()
        {
            // Create a dictionary with the year and the prime minister
            Dictionary<int, string> primeMinisters = new Dictionary<int, string>();

            try
            {
                // Add prime ministers to the dictionary
                AddPrimeMinister(primeMinisters, 1998, "Atal Bihari Vajpayee");
                AddPrimeMinister(primeMinisters, 2014, "Narendra Modi");
                AddPrimeMinister(primeMinisters, 2004, "Manmohan Singh");

                // Find the prime minister of 2004
                PrintPrimeMinister(primeMinisters, 2004);

                // Add the current prime minister in the dictionary for the year 2023
                AddPrimeMinister(primeMinisters, 2023, "Narendra Modi");

                // Sort the dictionary by year and print the details
                SortAndPrintDictionary(primeMinisters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Method to add a prime minister to the dictionary.
        /// </summary>
        /// <param name="dict">The dictionary containing prime ministers.</param>
        /// <param name="year">The year for which the prime minister is added.</param>
        /// <param name="primeMinister">The name of the prime minister.</param>
        static void AddPrimeMinister(Dictionary<int, string> dict, int year, string primeMinister)
        {
            try
            {
                // If the year already exists, update the prime minister
                if (dict.ContainsKey(year))
                {
                    dict[year] = primeMinister;
                }
                // Otherwise, add a new entry
                else
                {
                    dict[year] = primeMinister;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding prime minister for year {year}: {ex.Message}");
            }
        }

        /// <summary>
        /// Method to print the prime minister for a specific year.
        /// </summary>
        /// <param name="dict">The dictionary containing prime ministers.</param>
        /// <param name="year">The year for which the prime minister is printed.</param>
        static void PrintPrimeMinister(Dictionary<int, string> dict, int year)
        {
            try
            {
                if (dict.ContainsKey(year))
                {
                    Console.WriteLine($"Prime minister of {year}: {dict[year]}");
                }
                else
                {
                    Console.WriteLine($"No prime minister found for {year}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error printing prime minister for year {year}: {ex.Message}");
            }
        }

        /// <summary>
        /// Method to sort and print the dictionary by year.
        /// </summary>
        /// <param name="dict">The dictionary containing prime ministers.</param>
        static void SortAndPrintDictionary(Dictionary<int, string> dict)
        {
            try
            {
                var sortedDict = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine("\nSorted Dictionary:");
                foreach (var kvp in sortedDict)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error sorting and printing dictionary: {ex.Message}");
            }
        }
    }
}