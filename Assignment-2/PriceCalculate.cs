using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2
{
    public class PriceCalculate
    {
        /// <summary>
        /// Calculates and prints the total price of specified product purchases.
        /// </summary>
        /// <param name="productList">The list of products available for purchase.</param>
        /// <param name="productName1">The name of the first product to purchase.</param>
        /// <param name="quantity1">The quantity of the first product to purchase.</param>
        /// <param name="productName2">The name of the second product to purchase.</param>
        /// <param name="quantity2">The quantity of the second product to purchase.</param>
        /// <param name="productName3">The name of the third product to purchase.</param>
        /// <param name="quantity3">The quantity of the third product to purchase.</param>
        public static void CalculatePrice(List<Product> productList, string productName1, int quantity1, string productName2, int quantity2, string productName3, int quantity3)
        {
            double price = 0;

            price += GetTotalPrice(productList, productName1, quantity1);
            price += GetTotalPrice(productList, productName2, quantity2);
            price += GetTotalPrice(productList, productName3, quantity3);

            // Taking round off value using Math function.
            Console.WriteLine("Total price of your purchases: " + Math.Round(price));
        }

        /// <summary>
        /// Calculates the total price for a specified product and quantity.
        /// </summary>
        /// <param name="productList">The list of products available for purchase.</param>
        /// <param name="productName">The name of the product for which to calculate the total price.</param>
        /// <param name="quantity">The quantity of the product to purchase.</param>
        /// <returns>The total price for the specified product and quantity.</returns>
        private static double GetTotalPrice(List<Product> productList, string productName, int quantity)
        {
            var product = productList.FirstOrDefault(p => p.Name.Equals(productName));
            return product != null ? product.Price * quantity : 0;
        }
    }
}
