using MyChest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChest.Data.DAO
{
    internal class ProductDAO
    {
        public List<Product> Search()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT \r\n  p.code,\r\n  p.name,\r\n  p.brand,\r\n  p.description,\r\n  p.amount,\r\n  m.name AS nome_medida,\r\n  GROUP_CONCAT(t.name) AS nomes_tags\r\nFROM \r\n  products p\r\nLEFT JOIN \r\n  products_has_tags pt ON p.code = pt.Products_code\r\nLEFT JOIN \r\n  tags t ON pt.Tags_idTags = t.idTags\r\nLEFT JOIN \r\n  measures m ON p.Measures_idMeasures = m.idMeasures\r\nGROUP BY \r\n  p.code;\r\n";
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int code = reader.GetInt32("code");
                                string name = reader.GetString("name");
                                string brand = reader.GetString("brand");
                                string description = reader.GetString("description");
                                int amount = reader.GetInt32("amount");
                                string tagsId = reader.GetString("nomes_tags");
                                string measure = reader.GetString("nome_medida");
                                Product product = new Product(code, name, brand, description, amount, tagsId, measure);
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
