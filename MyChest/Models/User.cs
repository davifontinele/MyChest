namespace MyChest.Models
{
    public class User
    {

        // Remover os '?' das propriedades depois, estão por enquanto para testes
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public List<Permissions> Permissions { get; set; }
        public User(string name, string password, string role)
        {
            Name = name;
            Password = password;
            Role = role;
        }
        public User(string name, string password, List<Permissions> permissions)
        {
            Name = name;
            Password = password;
            Permissions = permissions;
        }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public User()
        {
            
        }
    }
}
