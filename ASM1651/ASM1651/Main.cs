using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    private static List<User> users;
    private static List<Product> products;
    private static User currentUser;
    private static Cart cart;
    private static List<Order> orders;

    static void Main(string[] args)
    {
        users = User.LoadUsersFromFile("C:\\Users\\Dell\\source\\repos\\ASM1651\\ASM1651\\users.txt");
        products = Product.LoadProductsFromFile("C:\\Users\\Dell\\source\\repos\\ASM1651\\ASM1651\\products.txt");
        cart = new Cart();
        orders = new List<Order>();

       Login();

    }

    static void Login()
    {
        Console.WriteLine("Login");
        Console.WriteLine("-----");

        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        if (username == "admin" && password == "123456")
        {
            
            Console.WriteLine("Login successful as admin!");
            AdminMenu();
        }
        else
        {
            currentUser = users.Find(u => u.Username == username && u.Password == password);

            if (currentUser != null)
            {
                Console.WriteLine("Login successful as user!");
                UserMenu();
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.");
                Login();
            }
        }
    }

    static void AdminMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Admin Menu");
        Console.WriteLine("----------");
        Console.WriteLine("1. Create Product");
        Console.WriteLine("2. Update Product");
        Console.WriteLine("3. Delete Product");
        Console.WriteLine("4. Exit");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Product.CreateProduct();
                AdminMenu();
                break;
            case "2":
                Product.UpdateProduct();
                AdminMenu();
                break;
            case "3":
                Product.DeleteProduct();
                AdminMenu();
                break;
            case "4":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                AdminMenu();
                break;
        }
    }

    static void UserMenu()
    {
        Console.WriteLine();
        Console.WriteLine("User Menu");
        Console.WriteLine("---------");
        Console.WriteLine("1. Show All Products");
        Console.WriteLine("2. Add Product to Cart");
        Console.WriteLine("3. Remove Product from Cart");
        Console.WriteLine("4. Clear Cart");
        Console.WriteLine("5. Checkout");
        Console.WriteLine("6. Exit");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Product.ShowAllProducts();
                UserMenu();
                break;
            case "2":
                Product.AddProductToCart();
                UserMenu();
                break;
            case "3":
                Product.RemoveProductFromCart();
                UserMenu();
                break;
            case "4":
               // Cart.ClearCart();
                Console.WriteLine("Cart cleared successfully!");
                UserMenu();
                break;
            case "5":
                Cart.Checkout();
                UserMenu();
                break;
            case "6":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                UserMenu();
                break;
        }
    }

    
   

   

   

  

   


    
}




