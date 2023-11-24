using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with specified details.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="price">The price of the product.</param>
        /// <param name="quantity">The quantity of the product.</param>
        /// <param name="type">The type of the product.</param>
        public Product(string name, double price, int quantity, string type)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Type = type;
        }

        /// <summary>
        /// Retrieves the quantity of a specific product from the given list.
        /// </summary>
        /// <param name="productList">The list of products to search.</param>
        /// <param name="productName">The name of the product whose quantity is to be retrieved.</param>
        /// <returns>The quantity of the specified product, or 0 if not found.</returns>
        public static int GetQuantity(List<Product> productList, string productName)
        {
            var product = productList.FirstOrDefault(p => p.Name.Equals(productName));
            return product != null ? product.Quantity : 0;
        }
    }
}
