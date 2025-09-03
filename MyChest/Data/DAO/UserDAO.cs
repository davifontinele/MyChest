using MyChest.Interfaces;
using MyChest.Models;

namespace MyChest.Data.DAO
{
    internal class UserDAO : IData<Models.User>
    {
        List<Models.User> IData<Models.User>.GetAllData()
        {
            List<Models.User> users = new List<Models.User>();
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT users.name, users.password, roles.title " +
                        "FROM users " +
                        "INNER JOIN roles ON users.Roles_idRoles = roles.idRoles;";

                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader.GetString("name");
                                string password = reader.GetString("password");
                                string role = reader.GetString("title");
                                Models.User user = new Models.User(name, password, role);
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

        public Models.User GetById(int id)
        {
            Models.User user = new Models.User();
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    string query = $"SELECT u.name, u.password, r.title AS role_nome " +
                        $"FROM users u " +
                        $"JOIN roles r ON u.Roles_idRoles = r.idRoles " +
                        $"WHERE u.idUsers = '{id}';";

                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user.Name = reader.GetString("name");
                                user.Password = reader.GetString("password");
                                user.Role = reader.GetString("role_nome");
                            }
                        }
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar login: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Models.User();
            }
        }

        /// <summary>
        /// Verifica se as credenciais passadas se estão registradas
        /// </summary>
        /// <param name="user">Nome de usuário a ser pesquisado</param>
        /// <param name="password">Senha do usuário a ser pesquisado</param>
        /// <returns>Retorna true se o login existir e false caso contrário</returns>
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
                        {
                            return command.ExecuteScalar() != null;
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

        /// <summary>
        /// Pesquisa um usuário usando o nome passado
        /// </summary>
        /// <param name="userName">Nome utilziado como parâmetro para a pesquisa</param>
        /// <returns>Retorna um obj User</returns>
        public Models.User GetByUserName(string userName)
        {
            Models.User user = new Models.User();
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    string query = $"SELECT u.name, u.password, r.title AS role_nome " +
                        $"FROM users u " +
                        $"JOIN roles r ON u.Roles_idRoles = r.idRoles " +
                        $"WHERE u.name = '{userName}';";

                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user.Name = reader.GetString("name");
                                user.Password = reader.GetString("password");
                                user.Role = reader.GetString("role_nome");
                            }
                        }
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar login: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Models.User();
            }
        }

        public List<Permissions> GetUserPermissionsByUserName(string userName)
        {
            List<Permissions> userPermissions = new List<Permissions>();
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    string query = $"SELECT p.name AS permissao_nome " +
                        $"FROM users u " +
                        $"JOIN roles r ON u.Roles_idRoles = r.idRoles " +
                        $"JOIN roles_has_permissions rp ON r.idRoles = rp.Roles_idRoles " +
                        $"JOIN permissions p ON rp.Permissions_idPermissions = p.idPermissions " +
                        $"WHERE u.name = '{userName}';";

                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                userPermissions.Add(Enum.Parse<Permissions>(reader.GetString("permissao_nome")));
                            }
                        }
                    }
                }
                return userPermissions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar permissões do usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Permissions>();
            }
        }
    }
}
