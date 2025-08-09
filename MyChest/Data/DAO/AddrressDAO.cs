using MyChest.Models;
using System;
using static Mysqlx.Notice.Warning.Types;

namespace MyChest.Data.DAO
{
    internal class AddressDAO
    {
        /// <summary>
        /// Representa as pesquisas feitas na tabela endereços.
        /// </summary>
        /// <returns>Retorna os dados da pesquisa em especifico</returns>
        /// 
        /// <summary>
        /// Busca todos os endereços.
        /// <summary>
        public List<Address> GetAllData()
        {
            List<Address> addresses = new List<Address>();
            try
            {
                // Abre uma conexão com o banco de dados de forma temporária e executa o bloco a seguir.
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    // Define a consulta SQL em questão
                    string query = "SELECT * FROM `addresses`";

                    // Executa a consulta SQL e lê os resultados
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        // Cria um leitor para ler os dados retornados pela consulta
                        using (var reader = command.ExecuteReader())
                        {
                            // Enquanto houver dados a serem lidos, adiciona os endereços à lista
                            while (reader.Read())
                            {
                                int corridor = reader.GetInt32("corridor");
                                int column = reader.GetInt32("column");
                                int level = reader.GetInt32("level");
                                int hall = reader.GetInt32("hall");

                                // Verifica se o campo Products_code é nulo; caso sim o define como 0 caso contrário atribui o valor
                                // Se fosse feito da forma tradicional, retornaria uma exceção; porque o campo não reconhece valores nulos
                                int productCode = reader.IsDBNull(reader.GetOrdinal("Products_code")) ? 0 : reader.GetInt32("Products_code");
                                Address address = new Address(corridor, column, level, hall, productCode);
                                addresses.Add(address);
                            }
                        }
                    }
                }
                return addresses;
            }

            // Captura qualquer exceção que ocorra durante a execução do código
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar endereços: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return addresses;
            }
        }
        /// <summary>
        /// Pesquisa todos os endereços que estão vazios, ou seja, onde o campo Products_code é nulo.
        /// </summary>
        /// <returns>Retorna uma lista dos endeços vazios</returns>
        public List<Address> GetAllEmpty()
        {
            List<Address> addresses = new List<Address>();
            try
            {
                // Abre uma conexão com o banco de dados de forma temporária e executa o bloco a seguir.
                using (var connetion = DbConnection.GetConnection())
                {
                    connetion.Open();

                    // Define a consulta SQL para buscar endereços onde o campo Products_code é nulo
                    string query = "SELECT * FROM addresses " +
                        "WHERE Products_code IS NULL;";

                    // Executa a consulta SQL e lê os resultados
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connetion))
                    {
                        // Cria um leitor para ler os dados retornados pela consulta
                        using (var reader = command.ExecuteReader())
                        {
                            // Enquanto houver dados a serem lidos, adiciona os endereços à lista
                            while (reader.Read())
                            {
                                int corridor = reader.GetInt32("corridor");
                                int column = reader.GetInt32("column");
                                int level = reader.GetInt32("level");
                                int hall = reader.GetInt32("hall");

                                // Verifica se o campo Products_code é nulo; caso sim o define como 0 caso contrário atribui o valor
                                // Se fosse feito da forma tradicional, retornaria uma exceção; porque o campo não reconhece valores nulos
                                int productCode = reader.IsDBNull(reader.GetOrdinal("Products_code")) ? 0 : reader.GetInt32("Products_code");
                                Address address = new Address(corridor, column, level, hall, productCode == 0 ? null : productCode);
                                addresses.Add(address);
                            }
                        }
                    }
                }
                return addresses;
            }
            // Captura qualquer exceção que ocorra durante a execução do código
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar endereços vazios: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return addresses;
            }
        }
        /// <summary>
        /// Pesquisa um endereço específico baseado no número do corredor, coluna, nível e hall.
        /// </summary>
        /// <param name="corridor">Valor do corredor a ser pesquisado</param>
        /// <param name="column">Valor da coluna a ser pesquisado</param>
        /// <param name="level">Valor do nivel a ser pesquisado</param>
        /// <param name="hall">Valor do hall a ser pesquisado</param>
        /// <returns>Retorna o Objeto "Address" com os parâmetros preenchidos,
        /// usado para preencher um dataGridView</returns>
        public Address GetAddressByNumbers(int corridor, int column, int level, int hall)
        {
            Address address = new Address();
            try
            {
                // Abre uma conexão com o banco de dados de forma temporária e executa o bloco a seguir.
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    // Define a consulta SQL para buscar o endereço com base nos parâmetros fornecidos
                    string query = "SELECT idaddress ,corridor, `column`, level, hall, Products_code " +
                        "FROM addresses " +
                        $"WHERE corridor = {corridor} " +
                        $"AND `column` = {column} " +
                        $"AND level = {level} " +
                        $"AND hall = {hall};";

                    // Executa a consulta SQL e lê os resultados
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        // Cria um leitor para ler os dados retornados pela consulta
                        using (var reader = command.ExecuteReader())
                        {
                            // Enquanto houver dados a serem lidos, atribui os valores ao objeto Address
                            while (reader.Read())
                            {
                                address.Id = reader.GetInt32("idaddress");
                                address.Corridor = reader.GetInt32("corridor");
                                address.Column = reader.GetInt32("column");
                                address.Level = reader.GetInt32("level");
                                address.Hall = reader.GetInt32("hall");
                                address.ProductCode = reader.IsDBNull(reader.GetOrdinal("Products_code")) ? null : reader.GetInt32("Products_code");
                            }
                            return address;
                        }
                    }
                }
            }
            // Captura qualquer exceção que ocorra durante a execução do código
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar endereços: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return address;
            }
        }

        /// <summary>
        /// Retorno o ID do endereço baseado no corredor, coluna, nível e hall.
        /// </summary>
        /// <param name="corridor">Valor do corredor do endereço</param>
        /// <param name="column">Valor da coluna do endereço</param>
        /// <param name="level">Valor do nivel do endereço</param>
        /// <param name="hall">Valor do hall do endereço</param>
        /// <returns>Retorna o valor inteiro do Id do endereço pesquisado</returns>
        public int GetAddressId(int corridor, int column, int level, int hall)
        {
            try
            {
                // Abre uma conexão com o banco de dados de forma temporária e executa o bloco a seguir.
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    // Define a consulta SQL para buscar o ID do endereço com base nos parâmetros fornecidos
                    string query = "SELECT idaddress " +
                        "FROM addresses " +
                        $"WHERE addresses.corridor = {corridor} " +
                        $"AND addresses.column = {column} " +
                        $"AND addresses.level = {level} " +
                        $"AND addresses.hall = {hall};";

                    // Executa a consulta SQL e lê o resultado
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        // Retorna o ID do endereço 
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            // Captura qualquer exceção que ocorra durante a execução do código
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar o ID do endereço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        /// <summary>
        /// Pesquisa o código do produto vinculado a um endereço específico baseado no corredor, coluna, nível e hall.
        /// </summary>
        /// <param name="corridor">Valor do corredor do endereço</param>
        /// <param name="column">Valor da coluna do endereço</param>
        /// <param name="level">Valor do nivel do endereço</param>
        /// <param name="hall">Valor do hall do endereço</param>
        /// <returns>Retorna o código do produto vinculado ao endereço pesquisado baseado no corredor, coluna, nível e hall.</returns>
        public int GetProdCode(int corridor, int column, int level, int hall)
        {
            try
            {
                // Abre uma conexão com o banco de dados de forma temporária e executa o bloco a seguir.
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    // Define a consulta SQL para buscar o ID do endereço com base nos parâmetros fornecidos
                    string query = "SELECT Products_code " +
                        "FROM addresses " +
                        $"WHERE addresses.corridor = {corridor} " +
                        $"AND addresses.corridor = {column} " +
                        $"AND addresses.level = {level} " +
                        $"AND addresses.hall = {hall};";

                    // Executa a consulta SQL e lê o resultado
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        // Retorna o código do produto vinculado ao endereço pesquisado
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            // Captura qualquer exceção que ocorra durante a execução do código
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar o código do produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        /// <summary>
        /// Move o produto especificado para o endereço especificado.
        /// </summary>
        /// <param name="codeProd">Código do produto a ser movido</param>
        /// <param name="address">Destino ou endereço que o produto será movido</param>
        public void MoveProdForAddress(int codeProd, Address address)
        {
            // Verifica se o endereço já possui um produto associado
            if (GetAddressByNumbers(address.Corridor, address.Column, address.Level, address.Hall).ProductCode == 0 || GetAddressByNumbers(address.Corridor, address.Column, address.Level, address.Hall).ProductCode == null)
            {
                try
                {
                    // Abre uma conexão com o banco de dados de forma temporária e executa o bloco a seguir.
                    using (var connection = DbConnection.GetConnection())
                    {
                        connection.Open();

                        // Define a consulta SQL para atualizar o endereço com o código do produto
                        string query = "UPDATE `addresses` " +
                            $"SET `Products_code` = '{codeProd}' " +
                            $"WHERE `addresses`.`idaddress` = {GetAddressId(address.Corridor, address.Column, address.Level, address.Hall)}";

                        // Executa a consulta SQL para atualizar o endereço
                        using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                        {
                            // Executa o comando SQL
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show($"Produto {codeProd} movimentado para {address.Corridor}-{address.Column}-{address.Level}-{address.Hall}.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Captura qualquer exceção que ocorra durante a execução do código
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro movimentar o produto {codeProd}: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Se o endereço já possui um produto associado, pergunta se deseja trocar os produtos
            else
            {
                DialogResult result = MessageBox.Show($"O endereço {address.Corridor}-{address.Column}-{address.Level}-{address.Hall} já possui um produto associado. Deseja fazer a troca entre de produtos?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Abre uma conexão com o banco de dados de forma temporária e executa o bloco a seguir.
                        using (var connection = DbConnection.GetConnection())
                        {
                            connection.Open();

                            ProductDAO productDAO = new ProductDAO();

                            // Define a consulta SQL para atualizar o endereço com o código do produto
                            string query = "START TRANSACTION; " +
                                "UPDATE addresses a " +
                                "JOIN (" +
                                "SELECT idaddress, " +
                                    "Products_code " +
                                    "FROM addresses " +
                                    $"WHERE idaddress IN ({GetAddressId(address.Corridor, address.Column, address.Level, address.Hall)}, {productDAO.GetAddressId(codeProd)})" +
                                    ") " +
                                    "AS temp " +
                                    "ON a.idaddress = temp.idaddress " +
                                    "SET a.Products_code = ( " +
                                    "SELECT Products_code " +
                                    "FROM addresses " +
                                    $"WHERE idaddress = IF(temp.idaddress = {GetAddressId(address.Corridor, address.Column, address.Level, address.Hall)}, {productDAO.GetAddressId(codeProd)}, {GetAddressId(address.Corridor, address.Column, address.Level, address.Hall)})" +
                                    "); " +
                                    "COMMIT;";

                            // Executa a consulta SQL para atualizar o endereço
                            using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                            {
                                // Executa o comando SQL
                                command.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show($"Produtos movimentados com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    // Captura qualquer exceção que ocorra durante a execução do código
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro movimentar o produto {codeProd}: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}
