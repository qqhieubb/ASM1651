namespace ASM1651
{
    public abstract class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public virtual void DisplayMenu()
        {
            Console.WriteLine("HIEUSHOP Menu");
            Console.WriteLine("Welcome to my shop!");

        }

        public static User Login(string username, string password)
        {
            if (username == "admin" && password == "123456")
            {
                return new Admin(username, password);
            }
            else if (username == "customer" && password == "123456")
            {
                return new Customer(username, password);
            }

            return null;
        }
    }
}