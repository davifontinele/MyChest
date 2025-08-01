using MyChest.Models;

namespace MyChest.Data.DAO
{
    internal class UserDAO
    {
        public List<User> GetAllData()
        {
            List<User> users = new List<User>();
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT Users.Name, Users.Password, Roles.name " +
                        "FROM Users " +
                        "INNER JOIN Roles ON Roles.IdRoles = Roles.IdRoles;";
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader.GetString("Name");
                                string password = reader.GetString("Password");
                                string role = reader.GetString("name");
                                User user = new User(name, password, role);
                                users.Add(user);
                            }
                        }
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar usuários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return users;
            }
        }
    }
}
