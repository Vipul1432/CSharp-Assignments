using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class PrintProduct
    {
        /// <summary>
        /// Prints details of all products in the given list.
        /// </summary>
        /// <param name="productList">The list of products to print.</param>
        public static void PrintAllProduct(List<Product> productList)
        {
            Console.WriteLine("**************************************************************");
            foreach (var product in productList)
            {
                Console.WriteLine(product.Name + ", " + product.Price + "RS, " + product.Quantity + ", " + product.Type);
            }
        }

        /// <summary>
        /// Prints details of products of a specific type from the given list.
        /// </summary>
        /// <param name="productType">The type of products to print.</param>
        /// <param name="productList">The list of products to filter and print.</param>
        public static void PrintByType(String productType, List<Product> productList)
        {
            foreach (Product product in productList)
            {
                if (product.Type.Equals(productType))
                {
                    Console.WriteLine(product.Name + ", " + product.Price + "RS, " + product.Quantity + ", " + product.Type);
                }
            }
        }
    }
}
