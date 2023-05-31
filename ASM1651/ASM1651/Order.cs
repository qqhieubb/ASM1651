
public class Order
{
    private static int nextOrderId = 1;

    public int Id { get; private set; }
    public List<CartItem> Items { get; private set; }

    public Order(Cart cart)
    {
        Id = nextOrderId++;
        Items = cart.GetItems();
    }

    public static void WriteOrderDetailsToFile(Order order)
    {
        string orderDetails = $"Order ID: {order.Id}\n";

        foreach (CartItem item in order.Items)
        {
            orderDetails += $"Product ID: {item.Product.Id}, Name: {item.Product.Name}, Quantity: {item.Quantity}, Subtotal: {item.Subtotal}\n";
        }

        File.AppendAllText("C:\\Users\\Dell\\source\\repos\\ASM1651\\ASM1651\\orders.txt", orderDetails);
    }
}
