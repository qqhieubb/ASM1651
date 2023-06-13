using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1651
{
    public class Admin : User
    {
        public Admin(string username, string password)
            : base(username, password)
        {
        }

        public override void DisplayMenu()
        {
            base.DisplayMenu();
            Console.WriteLine("========== ADMIN MENU ==========");
            Console.WriteLine("1. Display available products");
            Console.WriteLine("2. Add a product");
            Console.WriteLine("3. Remove a product");
            Console.WriteLine("4. Update a product");
            Console.WriteLine("5. Search for a product");
            Console.WriteLine("6. Exit");
        }

        public void DisplayAvailableProducts(List<Product> products)
        {
            Console.WriteLine("Available products:");
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
        }

        public void AddProduct(List<Product> products)
        {
            Console.Write("Enter product ID: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter product price: ");
            decimal productPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter additional info (author/size): ");
            string additionalInfo = Console.ReadLine();

            Product product;
            if (additionalInfo.Contains('/'))
            {
                string[] infoParts = additionalInfo.Split('/');
                string author = infoParts[0];
                string size = infoParts[1];
                product = new Book(productId, productName, productPrice, author);
            }
            else
            {
                string size = additionalInfo;
                product = new Clothing(productId, productName, productPrice, size);
            }
                                            
            Console.WriteLine("Product added.");
        }

        public void RemoveProduct(List<Product> products)
        {
            Console.Write("Enter product ID to remove: ");
            int idToRemove = Convert.ToInt32(Console.ReadLine());
            Product productToRemove = products.Find(p => p.Id == idToRemove);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                Console.WriteLine("Product removed.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public void UpdateProduct(List<Product> products)
        {
            Console.Write("Enter product ID to update: ");
            int idToUpdate = Convert.ToInt32(Console.ReadLine());
            Product productToUpdate = products.Find(p => p.Id == idToUpdate);
            if (productToUpdate != null)
            {
                Console.Write("Enter new name: ");
                string newName = Console.ReadLine();
                Console.Write("Enter new price: ");
                decimal newPrice = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter new additional info: ");
                string newAdditionalInfo = Console.ReadLine();
                Console.WriteLine("Product updated.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }
}
