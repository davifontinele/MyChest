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
                    string query = "SELECT Users.name, Users.password, Roles.title " +
                        "FROM Users " +
                        "INNER JOIN Roles ON Roles.IdRoles = Roles.IdRoles;";
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader.GetString("name");
                                string password = reader.GetString("password");
                                string role = reader.GetString("title");
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
        public bool VerifyLogin(string user, string password)
        {
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();
                    string query = $"SELECT u.name, u.password, r.title AS role_nome " +
                        $"FROM users u " +
                        $"JOIN roles r ON u.Roles_idRoles = r.idRoles " +
                        $"WHERE u.name = '{user}' " +
                        $"AND u.password = '{password}';";
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Usuário ou senha incorretos.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar login: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
