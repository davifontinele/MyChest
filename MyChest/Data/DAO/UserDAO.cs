using MyChest.Interfaces;
using MyChest.Models;
using MySql.Data.MySqlClient;

namespace MyChest.Data.DAO
{
    internal class UserDAO : IData<Models.User>
    {
        public List<Models.User> GetAllData()
        {
            List<Models.User> users = new List<Models.User>();
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT u.idUsers, u.name, u.password, p.name AS permission_title " +
                                   "FROM users u " +
                                   "LEFT JOIN users_has_permissions up ON u.idUsers = up.Users_idUsers " +
                                   "LEFT JOIN permissions p ON up.Permissions_idPermissions = p.idPermissions " +
                                   "ORDER BY u.idUsers;";

                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            Dictionary<int, Models.User> userMap = new Dictionary<int, Models.User>();

                            while (reader.Read())
                            {
                                int userId = reader.GetInt32("idUsers");

                                if (!userMap.ContainsKey(userId))
                                {
                                    string name = reader.GetString("name");
                                    string password = reader.GetString("password");
                                    userMap[userId] = new Models.User
                                    {
                                        Name = name,
                                        Password = password,
                                        Permissions = new List<Permissions>()
                                    };
                                }

                                if (!reader.IsDBNull(reader.GetOrdinal("permission_title")))
                                {
                                    string permissionName = reader.GetString("permission_title");

                                    if (Enum.TryParse<Permissions>(permissionName, ignoreCase: true, out var permissionEnum))
                                    {
                                        userMap[userId].Permissions.Add(permissionEnum);
                                    }
                                }
                            }
                            users = userMap.Values.ToList();
                        }
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar todos os usuários. | {ex.GetType().Name} - {ex.Message}", "ERROR [GetAllData]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    string query = "SELECT u.name, u.password, p.idPermissions " +
                                   "FROM users u " +
                                   "JOIN users_has_permissions up ON u.idUsers = up.Users_idUsers " +
                                   "JOIN permissions p ON up.Permissions_idPermissions = p.idPermissions " +
                                   "WHERE u.idUsers = @id;";

                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (string.IsNullOrEmpty(user.Name))
                                {
                                    user.Name = reader.GetString("name");
                                    user.Password = reader.GetString("password");
                                }

                                int permissionId = reader.GetInt32("idPermissions");

                                if (Enum.IsDefined(typeof(Permissions), permissionId))
                                {
                                    var permissionEnum = (Permissions)permissionId;
                                    user.Permissions.Add(permissionEnum);
                                }
                            }
                        }
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar usuário pelo Id especificado. | {ex.GetType().Name} - {ex.Message}", "ERROR [GetById]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Models.User();
            }
        }

        public void InsertUser(User user)
        {
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO `users` (`name`, `password`) " +
                        $"VALUES ('{user.Name}', '{user.Password}')";
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Erro ao cadastrar novo usuário. | {e.GetType().Name} - {e.Message}", "ERROR [InsertUser]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InsertUserPermissions(int userId, List<int> permissionId)
        {
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();
                    foreach (int item in permissionId)
                    {
                        string query = "INSERT INTO `users_has_permissions` (`Users_idUsers`, `Permissions_idPermissions`) " +
                        $"VALUES ({userId}, {item})";
                        using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Erro ao cadastrar permissões do usuário. | {e.GetType().Name} - {e.Message}", "ERROR [InsertUserPermissions]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int GetUserId(string userName)
        {
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT idUsers " +
                        "FROM users " +
                        "WHERE name = @userName;";
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userName", userName);
                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Erro ao buscar Id do usuário. | {e.GetType().Name} - {e.Message}", "ERROR [GetUserId]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
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

                    string query = "SELECT COUNT(*) " +
                                   "FROM users " +
                                   "WHERE name = @user AND password = @password;";

                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@user", user);
                        command.Parameters.AddWithValue("@password", password);

                        var result = Convert.ToInt32(command.ExecuteScalar());
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar login. | {ex.GetType().Name} - {ex.Message}", "ERROR [VerifyLogin]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Models.User user = new Models.User { Permissions = new List<Permissions>() };
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT u.name, u.password, p.idPermissions " +
                                   "FROM users u " +
                                   "JOIN users_has_permissions up ON u.idUsers = up.Users_idUsers " +
                                   "JOIN permissions p ON up.Permissions_idPermissions = p.idPermissions " +
                                   "WHERE u.name = @userName;";

                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userName", userName);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (string.IsNullOrEmpty(user.Name))
                                {
                                    user.Name = reader.GetString("name");
                                    user.Password = reader.GetString("password");
                                }

                                int permissionId = reader.GetInt32("idPermissions");

                                if (Enum.IsDefined(typeof(Permissions), permissionId))
                                {
                                    var permissionEnum = (Permissions)permissionId;
                                    user.Permissions.Add(permissionEnum);
                                }
                            }
                        }
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar usuário pelo nome especificado. | {ex.GetType().Name} - {ex.Message}", "ERROR [GetByUserName]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    string query = "SELECT p.name AS permissao_nome " +
                                   "FROM users u " +
                                   "JOIN users_has_permissions up ON u.idUsers = up.Users_idUsers " +
                                   "JOIN permissions p ON up.Permissions_idPermissions = p.idPermissions " +
                                   "WHERE u.name = @userName;";

                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userName", userName);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nomePermissao = reader.GetString("permissao_nome");

                                if (Enum.TryParse<Permissions>(nomePermissao, ignoreCase: true, out var permissaoEnum))
                                {
                                    userPermissions.Add(permissaoEnum);
                                }
                            }
                        }
                    }
                }
                return userPermissions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar permissões do usuário especificado. | {ex.GetType().Name} - {ex.Message}", "ERROR [GetUserPermissionsByUserName]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Permissions>();
            }
        }

        public Dictionary<int, Permissions> GetAllPermissions()
        {
            Dictionary<int, Permissions> allPermissions = new Dictionary<int, Permissions>();
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT permissions.name, permissions.idPermissions FROM `permissions`";

                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string permission = reader.GetString("name");
                                int permissionId = reader.GetInt32("idPermissions");
                                if (Enum.TryParse<Permissions>(permission, ignoreCase: true, out var permissaoEnum))
                                {
                                    allPermissions.Add(permissionId, permissaoEnum);
                                }
                            }
                        }
                    }
                }
                return allPermissions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar permissões. | {ex.GetType().Name} - {ex.Message}", "ERROR [GetAllPermissions]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Dictionary<int, Permissions>();
            }
        }

        public int GetPermissionId(string permissionName)
        {
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();
                    string query = $"SELECT idPermissions FROM permissions WHERE name = '{permissionName}';";
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Erro ao buscar Id da permissão. | {e.GetType().Name} - {e.Message}", "ERROR [GetPermissionId]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public void UpdateUser(int userId, string updatedLogin, string updatedPassword)
        {
            try
            {
                using (var connnection = DbConnection.GetConnection())
                {
                    connnection.Open();

                    UserDAO userDAO = new UserDAO();
                    string query = "UPDATE `users` " +
                        $"SET `name` = '{updatedLogin}', " +
                        $"`password` = '{updatedPassword}' " +
                        $"WHERE `users`.`idUsers` = {userId}";
                    using (var command = new MySqlCommand(query, connnection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Erro ao atualizar usuário especificado. | {e.GetType().Name} - {e.Message}", "ERROR [UpdateUser]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteUser(int userId)
        {
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();
                    string query = $"DELETE FROM users_has_permissions WHERE Users_idUsers = {userId};" +
                        $"DELETE FROM users WHERE idUsers = {userId};";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Erro ao deletar o usuário especificado. | {e.GetType().Name} - {e.Message}", "ERROR [DeleteUser]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
