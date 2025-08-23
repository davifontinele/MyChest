using MyChest.Interfaces;
using MyChest.Models;

namespace MyChest.Data.DAO
{
    internal class ProductDAO : IData<Product>
    {
        Product IData<Product>.GetById(int id)
        {
            Product product = new Product();
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    string query = $"SELECT p.code,p.name,p.brand,p.amount,m.name AS nome_medida " +
                        $"FROM products p " +
                        $"LEFT JOIN measures m ON p.Measures_idMeasures = m.idMeasures " +
                        $"WHERE p.code = {id};";

                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
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
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null!;
            }
        }
        List<Product> IData<Product>.GetAllData()
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

        /// <summary>
        /// Pesquisa o endereço usando o código do produto como parâmetro.
        /// </summary>
        /// <param name="productCode">Código do produto</param>
        /// <returns>Retorna um objeto endereço</returns>
        public Address GetAddressByProductId(int productCode)
        {
            Address address = new Address();
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    string query = $"SELECT * FROM addresses WHERE Products_code = {productCode};";

                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                address.Id = reader.GetInt32("idaddress");
                                address.Corridor = reader.GetInt32("corridor");
                                address.Column = reader.GetInt32("column");
                                address.Level = reader.GetInt32("level");
                                address.Hall = reader.GetInt32("hall");
                                address.ProductCode = reader.IsDBNull(reader.GetOrdinal("Products_code")) ? null : reader.GetInt32("Products_code");
                            }
                        }
                    }
                }
                return address;
            }
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
        public int GetAddressIdByProductId(int codeProd)
        {
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    string query = $"SELECT idaddress FROM addresses WHERE Products_code = {codeProd};";

                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                                return reader.GetInt32("idaddress");
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
        public void SwapAddressesBetweenProducts(int firstProdCode, int secondProdCode)
        {
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    string query = "START TRANSACTION; " +
                        "UPDATE addresses " +
                        $"SET Products_code = {firstProdCode} " +
                        $"WHERE idaddress = {GetAddressIdByProductId(secondProdCode)}; " +
                        "UPDATE addresses " +
                        $"SET Products_code = {secondProdCode} " +
                        $"WHERE idaddress = {GetAddressIdByProductId(firstProdCode)}; " +
                        "COMMIT;";

                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
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
