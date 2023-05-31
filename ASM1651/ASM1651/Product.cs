
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    private static List<Product> products;

    private static Cart cart;
    public Product(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public static void CreateProduct()
    {
        Console.WriteLine("Create Product");
        Console.WriteLine("--------------");

        Console.Write("Enter Product ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Product Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Product Price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Product product = new Product(id, name, price);
        products.Add(product);

        Console.WriteLine("Product created successfully!");
        Product.SaveProductsToFile("C:\\Users\\Dell\\source\\repos\\ASM1651\\ASM1651\\products.txt");

       
    }

    public static void UpdateProduct()
    {
        Console.WriteLine("Update Product");
        Console.WriteLine("--------------");

        Console.Write("Enter Product ID to update: ");
        int id = int.Parse(Console.ReadLine());

        Product productToUpdate = products.Find(p => p.Id == id);

        if (productToUpdate != null)
        {
            Console.Write("Enter new Product Name: ");
            string newName = Console.ReadLine();

            Console.Write("Enter new Product Price: ");
            decimal newPrice = decimal.Parse(Console.ReadLine());

            productToUpdate.Name = newName;
            productToUpdate.Price = newPrice;

            Console.WriteLine("Product updated successfully!");
            Product.SaveProductsToFile("C:\\Users\\Dell\\source\\repos\\ASM1651\\ASM1651\\products.txt");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }

        
    }

    public static void DeleteProduct()
    {
        Console.WriteLine("Delete Product");
        Console.WriteLine("--------------");

        Console.Write("Enter Product ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        Product productToDelete = products.Find(p => p.Id == id);

        if (productToDelete != null)
        {
            products.Remove(productToDelete);
            Console.WriteLine("Product deleted successfully!");
            Product.SaveProductsToFile("C:\\Users\\Dell\\source\\repos\\ASM1651\\ASM1651\\products.txt");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }

       
    }

    public static void ShowAllProducts()
    {
        Console.WriteLine("All Products");
        Console.WriteLine("------------");

        foreach (Product product in products)
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
        }

       
    }

    public static void AddProductToCart()
    {
        Console.WriteLine("Add Product to Cart");
        Console.WriteLine("-------------------");

        Console.Write("Enter Product ID to add to cart: ");
        int id = int.Parse(Console.ReadLine());

        Product productToAdd = products.Find(p => p.Id == id);

        if (productToAdd != null)
        {
            cart.AddToCart(productToAdd);
            Console.WriteLine("Product added to cart successfully!");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }

      
    }

    public static void RemoveProductFromCart()
    {
        Console.WriteLine("Remove Product from Cart");
        Console.WriteLine("------------------------");

        Console.Write("Enter Product ID to remove from cart: ");
        int id = int.Parse(Console.ReadLine());

        Product productToRemove = products.Find(p => p.Id == id);

        if (productToRemove != null)
        {
            cart.RemoveFromCart(productToRemove);
            Console.WriteLine("Product removed from cart successfully!");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }

       
    }



    public static List<Product> LoadProductsFromFile(string filePath)
    {
        List<Product> productList = new List<Product>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                int id = int.Parse(data[0]);
                string name = data[1];
                decimal price = decimal.Parse(data[2]);

                Product product = new Product(id, name, price);
                productList.Add(product);
            }
        }

        return productList;
    }
    public static void SaveProductsToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Product product in products)
            {
                writer.WriteLine($"{product.Id},{product.Name},{product.Price}");
            }
        }
    }
}

