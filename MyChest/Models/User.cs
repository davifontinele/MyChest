namespace MyChest.Models
{
    public class User
    {

        // Remover os '?' das propriedades depois, estão por enquanto para testes
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public User(string name, string password, string role)
        {
            Name = name;
            Password = password;
            Role = role;
        }

        /// <summary>
        /// Construtor apenas para testes remover depois
        /// </summary>
        /// <param name="name">Nome do usuário</param>
        /// <param name="password">Senha do usuário</param>
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
