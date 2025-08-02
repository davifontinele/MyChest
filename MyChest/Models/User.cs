namespace MyChest.Models
{
    public class User
    {
        /// <summary>
        /// Representa um usuário no sistema.
        /// Cada instância contém informações como nome, senha e cargo.
        /// </summary>
        public string Name { get; set; }
        public string Password { get; set; }
        public string?  Role { get; set; }
        public User(string name, string password, string role)
        {
            Name = name;
            Password = password;
            Role = role;
        }
        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
