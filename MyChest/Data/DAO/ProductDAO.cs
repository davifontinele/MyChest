using MyChest.Models;

namespace MyChest.Data.DAO
{
    internal class ProductDAO
    {
        /// <summary>
        /// Representa o acesso aos dados dos produtos no banco de dados.
        /// </summary>
        /// <returns>Retorna os dados da pesquisa em especifico</returns>
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
    }
}
