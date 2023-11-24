using System;
using System.Collections.Generic;

namespace Assignment_2
{
    public class Program
    {
        private static List<Product> productList = new List<Product>();

        static void Main(string[] args)
        {
            // Adding default products
            AddProduct.AddDefaultProducts(productList);
            Console.WriteLine($"Total number of products in the list: {productList.Count}");

            // Taking user input for a new product
            Console.WriteLine("Enter details for the new product (Name, Price RS, Quantity, Type):");
            AddProduct.TakeInputProduct(productList);

            // Printing all products
            PrintProduct.PrintAllProduct(productList);
            Console.WriteLine($"Total number of products in the list: {productList.Count}");

            Console.WriteLine("**************************************************************");

            // Printing products of type 'Leafy green'
            Console.WriteLine("Printing all Leafy Green type products........");
            PrintProduct.PrintByType("Leafy green", productList);

            Console.WriteLine("**************************************************************");

            // Removing Garlic from the list
            RemoveProduct.RemoveGarlic(productList);
            PrintProduct.PrintAllProduct(productList);
            Console.WriteLine($"Total number of products in the list: {productList.Count}");

            Console.WriteLine("**************************************************************");

            // Calculating the total price for user's purchases
            PriceCalculate.CalculatePrice(productList, "lettuce", 1, "zucchini", 2, "broccoli", 1);
        }
    }
}
