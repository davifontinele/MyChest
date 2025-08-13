namespace MyChest.Data.DAO
{
    internal class UserDAO
    {
        /// <summary>
        /// Representa as pesquisas feitas na tabela usuários.
        /// </summary>
        /// <returns>Retorna os dados da pesquisa em especifico</returns>
        ///
        /// <summary>
        /// Busca todos os usuários e seus papéis no banco de dados.
        /// <summary>
        /// <returns>Retorna uma lista de todos usuários encontrados</returns>
        public List<Models.User> GetAllData()
        {
            List<Models.User> users = new List<Models.User>();
            try
            {
                // Abre uma conexão com o banco de dados de forma temporária e executa o bloco a seguir.
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    // Define a consulta SQL em questão
                    string query = "SELECT users.name, users.password, roles.title " +
                        "FROM users " +
                        "INNER JOIN roles ON users.Roles_idRoles = roles.idRoles;";

                    // Executa a consulta SQL e lê os resultados
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        // Cria um leitor para ler os dados retornados pela consulta
                        using (var reader = command.ExecuteReader())
                        {
                            // Enquanto houver dados a serem lidos, adiciona os usuários à lista
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

            // Captura qualquer exceção que ocorra durante a execução do código
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar usuários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return users;
            }
        }

        /// <summary>
        /// Verifica e compara as credenciais do usuário passado se estão registradas e retorna um booleano.
        /// </summary>
        /// <param name="user">Nome de usuário a ser pesquisado</param>
        /// <param name="password">Senha do usuário a ser pesquisado</param>
        /// <returns>Retorna true se o login existir e false caso contrário</returns>
        public bool VerifyLogin(string user, string password)
        {
            try
            {
                // Abre uma conexão com o banco de dados de forma temporária e executa o bloco a seguir.
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    // Define a consulta SQL para verificar as credenciais do usuário
                    string query = $"SELECT u.name, u.password, r.title AS role_nome " +
                        $"FROM users u " +
                        $"JOIN roles r ON u.Roles_idRoles = r.idRoles " +
                        $"WHERE u.name = '{user}' " +
                        $"AND u.password = '{password}';";

                    // Executa a consulta SQL e lê os resultados
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        {
                            return command.ExecuteScalar() != null;
                        }
                    }
                }
            }
            // Captura qualquer exceção que ocorra durante a execução do código
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar login: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Pesquisa um usuário pesquisando pelo nome passado
        /// </summary>
        /// <param name="userName">Nome utilziado como parâmetro para a pesquisa</param>
        /// <returns>Retorna um obj User</returns>
        public Models.User GetByUserName(string userName)
        {
            Models.User user = new Models.User();
            try
            {
                // Abre uma conexão com o banco de dados de forma temporária e executa o bloco a seguir.
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    // Define a consulta SQL para verificar as credenciais do usuário
                    string query = $"SELECT u.name, u.password, r.title AS role_nome " +
                        $"FROM users u " +
                        $"JOIN roles r ON u.Roles_idRoles = r.idRoles " +
                        $"WHERE u.name = '{userName}';";

                    // Executa a consulta SQL e lê os resultados
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
            // Captura qualquer exceção que ocorra durante a execução do código
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar login: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Models.User();
            }
        }
    }
}
