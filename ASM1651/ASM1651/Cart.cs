
public class Cart
{
    private List<CartItem> items;
    private static Cart cart;
    private static List<Order> orders;

    public Cart()
    {
        items = new List<CartItem>();
    }

    public void AddToCart(Product product)
    {
        CartItem cartItem = items.Find(item => item.Product.Id == product.Id);

        if (cartItem != null)
        {
            cartItem.Quantity++;
        }
        else
        {
            cartItem = new CartItem(product, 1);
            items.Add(cartItem);
        }
    }

    public void RemoveFromCart(Product product)
    {
        CartItem cartItem = items.Find(item => item.Product.Id == product.Id);

        if (cartItem != null)
        {
            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
            }
            else
            {
                items.Remove(cartItem);
            }
        }
    }

    public void ClearCart()
    {
        items.Clear();
    }

    public int GetTotalQuantity()
    {
        int totalQuantity = 0;

        foreach (CartItem item in items)
        {
            totalQuantity += item.Quantity;
        }

        return totalQuantity;
    }

    public decimal GetTotalAmount()
    {
        decimal totalAmount = 0;

        foreach (CartItem item in items)
        {
            totalAmount += item.Subtotal;
        }

        return totalAmount;
    }

    public List<CartItem> GetItems()
    {
        return items;
    }

    public static void Checkout()
    {
        Console.WriteLine("Checkout");
        Console.WriteLine("--------");

        if (cart.GetTotalQuantity() == 0)
        {
            Console.WriteLine("Cart is empty. Please add products to the cart first.");
        }
        else
        {
            Console.WriteLine("Thank you for your order!");

            // Create a new order
            Order order = new Order(cart);

            // Add the order to the list of orders
            orders.Add(order);

            // Write the order details to the file
            Order.WriteOrderDetailsToFile(order);


        }

       
    }

    

}