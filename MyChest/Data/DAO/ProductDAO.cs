using MyChest.Models;

namespace MyChest.Data.DAO
{
    internal class ProductDAO
    {
        public List<Product> GetAllData()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT p.code, p.name, p.brand, p.amount, m.name AS nome_medida," +
                        "GROUP_CONCAT(t.name) AS nomes_tags " +
                        "FROM products p " +
                        "LEFT JOIN products_has_tags pt ON p.code = pt.Products_code " +
                        "LEFT JOIN tags t ON pt.Tags_idTags = t.idTags " +
                        "LEFT JOIN measures m ON p.Measures_idMeasures = m.idMeasures " +
                        "GROUP BY p.code;";
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
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
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return products;
            }
        }
    }
}
