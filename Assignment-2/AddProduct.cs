using System;
using System.Collections.Generic;

namespace Assignment_2
{
    public class AddProduct
    {
        /// <summary>
        /// Adds a predefined list of default products to the given product list.
        /// </summary>
        /// <param name="productList">The list of products to which default products will be added.</param>
        public static void AddDefaultProducts(List<Product> productList)
        {
            productList.AddRange(new List<Product>
            {
                new Product("lettuce", 10.5, 50, "Leafy green"),
                new Product("cabbage", 20, 100, "Cruciferous"),
                new Product("pumpkin", 30, 30, "Marrow"),
                new Product("cauliflower", 10, 25, "Cruciferous"),
                new Product("zucchini", 20.5, 50, "Marrow"),
                new Product("yam", 30, 50, "Root"),
                new Product("spinach", 10, 100, "Leafy green"),
                new Product("broccoli", 20.2, 75, "Cruciferous"),
                new Product("garlic", 30, 20, "Leafy green"),
                new Product("silverbeet", 10, 50, "Marrow")
            });
        }

        /// <summary>
        /// Takes user input to add a new product to the given product list.
        /// Handles exceptions for invalid input.
        /// </summary>
        /// <param name="productList">The list of products to which the new product will be added.</param>
        public static void TakeInputProduct(List<Product> productList)
        {
            try
            {
                Console.Write("Name: ");
                var name = Console.ReadLine();

                Console.Write("Price: ");
                var price = double.Parse(Console.ReadLine());

                Console.Write("Quantity: ");
                var quantity = int.Parse(Console.ReadLine());

                Console.Write("Type: ");
                var type = Console.ReadLine();

                Product product = new Product(name, price, quantity, type);

                // Check if the product is cabbage and quantity is 50, then print the total number of cabbage in the list.
                if (product.Name.Equals("cabbage", StringComparison.OrdinalIgnoreCase) && product.Quantity == 50)
                {
                    Console.WriteLine($"Total number of cabbage in the list: {Product.GetQuantity(productList, "cabbage") + 50}");
                }

                productList.Add(product);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric value for Price and Quantity.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
