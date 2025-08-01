namespace MyChest.Models
{
    internal class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string  Role { get; set; }
        public User(string name, string password, string role)
        {
            Name = name;
            Password = password;
            Role = role;
        }
    }
}
