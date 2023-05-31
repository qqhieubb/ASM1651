public class User
{
    public int Id { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
   

    public User(int id, string username, string password, bool isAdmin = false)
    {
        Id = id;
        Username = username;
        Password = password;
        
    }

    public static List<User> LoadUsersFromFile(string filePath)
    {
        List<User> userList = new List<User>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                int id = int.Parse(data[0]);
                string username = data[1];
                string password = data[2];

                User user = new User(id, username, password);
                userList.Add(user);
            }
        }

        return userList;
    }

}