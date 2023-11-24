using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2
{
    public class RemoveProduct
    {
        /// <summary>
        /// Removes all occurrences of garlic products from the given list.
        /// Throws an exception if garlic is not found in the list.
        /// </summary>
        /// <param name="productList">The list of products to remove garlic from.</param>
        public static void RemoveGarlic(List<Product> productList)
        {
            try
            {
                var garlicProducts = productList.Where(p => p.Name.Equals("garlic")).ToList();

                if (garlicProducts.Any())
                {
                    productList.RemoveAll(p => p.Name.Equals("garlic"));
                    Console.WriteLine("Garlic removed from the list.");
                }
                else
                {
                    throw new InvalidOperationException("Garlic not found in the list.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
