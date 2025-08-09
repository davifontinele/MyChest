using MyChest.Models;
using MySql.Data.MySqlClient;

namespace MyChest.Data.DAO
{
    internal class ProductDAO
    {
        /// <summary>
        /// Representa o acesso aos dados dos produtos no banco de dados.
        /// </summary>
        /// 
        /// <summary>
        /// Busca todos os produtos.
        /// <summary>
        public List<Product> GetAllData()
        {
            List<Product> products = new List<Product>();
            try
            {
                // Abre uma conexão com o banco de dados de forma temporária e executa o bloco a seguir.
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    // Define a consulta SQL em questão
                    string query = "SELECT p.code, p.name, p.brand, p.amount, m.name AS nome_medida," +
                        "GROUP_CONCAT(t.name) AS nomes_tags " +
                        "FROM products p " +
                        "LEFT JOIN products_has_tags pt ON p.code = pt.Products_code " +
                        "LEFT JOIN tags t ON pt.Tags_idTags = t.idTags " +
                        "LEFT JOIN measures m ON p.Measures_idMeasures = m.idMeasures " +
                        "GROUP BY p.code;";

                    // Executa a consulta SQL e lê os resultados
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        // Cria um leitor para ler os dados retornados pela consulta
                        using (var reader = command.ExecuteReader())
                        {
                            // Enquanto houver dados a serem lidos, adiciona os produtos à lista
                            while (reader.Read())
                            {
                                int code = reader.GetInt32("code");
                                string name = reader.GetString("name");
                                string brand = reader.GetString("brand");
                                int amount = reader.GetInt32("amount");
                                string tagsId = reader.GetString("nomes_tags");
                                string measure = reader.GetString("nome_medida");
                                Product product = new Product(code, name, brand, amount, tagsId, measure);
                                products.Add(product);
                            }
                        }
                    }
                }
                return products;
            }

            // Captura qualquer exceção que ocorra durante a execução do código
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return products;
            }
        }

        /// <summary>
        /// Procura o produto usando o código passado como parâmetro.
        /// </summary>
        /// <param name="prodCode">Código do produto a ser utilizado como parâmetro de pesquisa</param>
        /// <returns>Retorna um obj do Product</returns>
        public Product GetByCode(int prodCode)
        {
            Product product = new Product();
            try
            {
                // Abre uma conexão com o banco de dados de forma temporária e executa o bloco a seguir.
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    // Define a consulta SQL em questão
                    string query = $"SELECT p.code,p.name,p.brand,p.amount,m.name AS nome_medida " +
                        $"FROM products p " +
                        $"LEFT JOIN measures m ON p.Measures_idMeasures = m.idMeasures " +
                        $"WHERE p.code = {prodCode};";

                    // Executa a consulta SQL e lê os resultados
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        // Cria um leitor para ler os dados retornados pela consulta
                        using (var reader = command.ExecuteReader())
                        {
                            // Enquanto houver dados a serem lidos, atribui os valores ao objeto produto
                            while (reader.Read())
                            {
                                product.Code = reader.GetInt32("code");
                                product.Name = reader.GetString("name");
                                product.Brand = reader.GetString("brand");
                                product.Amount = reader.GetInt32("amount");
                                product.Measure = reader.GetString("nome_medida");
                            }
                        }
                    }
                }
                return product;
            }
            // Captura qualquer exceção que ocorra durante a execução do código
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null!;
            }
        }
        /// <summary>
        /// Pesquisa o endereço usando o código do produto como parâmetro.
        /// </summary>
        /// <param name="productCode">Código do produto</param>
        /// <returns>Retorna um objeto endereço</returns>
        public Address GetAddressByProdCode(int productCode)
        {
            Address address = new Address();
            try
            {
                // Abre uma conexão com o banco de dados de forma temporária e executa o bloco a seguir.
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();
                    // Define a consulta SQL em questão
                    string query = $"SELECT * FROM addresses WHERE Product_code = {productCode};";
                    // Executa a consulta SQL e lê os resultados
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        // Cria um leitor para ler os dados retornados pela consulta
                        using (var reader = command.ExecuteReader())
                        {
                            // Enquanto houver dados a serem lidos, atribui os valores ao objeto endereço
                            while (reader.Read())
                            {
                                address.Id = reader.GetInt32("id");
                                address.Corridor = reader.GetInt32("corridor");
                                address.Column = reader.GetInt32("column");
                                address.Level = reader.GetInt32("level");
                                address.Hall = reader.GetInt32("hall");
                                address.ProductCode = reader.IsDBNull(reader.GetOrdinal("Product_code")) ? null : reader.GetInt32("Product_code");
                            }
                        }
                    }
                }
                return address;
            }
            // Captura qualquer exceção que ocorra durante a execução do código
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar endereço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null!;
            }
        }
        /// <summary>
        /// Pesquisa o ID do endereço usando o código do produto como parâmetro.
        /// </summary>
        /// <param name="codeProd">Código do produto associado ao endereço</param>
        /// <returns>Retorna o id do endereço que o produto e associado</returns>
        public int GetAddressId(int codeProd)
        {
            try
            {
                // Abre uma conexão com o banco de dados de forma temporária e executa o bloco a seguir.
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();
                    // Define a consulta SQL em questão
                    string query = $"SELECT idaddress FROM addresses WHERE Products_code = {codeProd};";
                    // Executa a consulta SQL e lê os resultados
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        // Cria um leitor para ler os dados retornados pela consulta
                        using (var reader = command.ExecuteReader())
                        {
                            // Enquanto houver dados a serem lidos, retorna o ID do endereço
                            if (reader.Read())
                            {
                                return reader.GetInt32("idaddress");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar ID do endereço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0;
        }

        /// <summary>
        /// Troca os produtos de endereço entre si usando os códigos dos produtos como parâmetro.
        /// </summary>
        /// <param name="firstProdCode">Código do primeiro produto</param>
        /// <param name="secondProdCode">Código do segundo produto</param>
        public void MoveProdForProd(int firstProdCode, int secondProdCode)
        {
            try
            {
                // Abre uma conexão com o banco de dados de forma temporária e executa o bloco a seguir.
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    // Define a consulta SQL em questão
                    string query = "START TRANSACTION; " +
                        "UPDATE addresses " +
                        $"SET Products_code = {firstProdCode} " +
                        $"WHERE idaddress = {GetAddressId(secondProdCode)}; " +
                        "UPDATE addresses " +
                        $"SET Products_code = {secondProdCode} " +
                        $"WHERE idaddress = {GetAddressId(firstProdCode)}; " +
                        "COMMIT;";

                    // Executa a consulta SQL para atualizar o endereço
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        // Executa o comando SQL
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Produto movimentado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao movimentar os produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
