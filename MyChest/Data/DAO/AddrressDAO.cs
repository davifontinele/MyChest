using MyChest.Models;

namespace MyChest.Data.DAO
{
    internal class AddressDAO
    {
        public List<Address> GetAllData()
        {
            List<Address> addresses = new List<Address>();
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM `addresses`";
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int corridor = reader.GetInt32("corridor");
                                int column = reader.GetInt32("column");
                                int level = reader.GetInt32("level");
                                int hall = reader.GetInt32("hall");
                                int productCode = reader.IsDBNull(reader.GetOrdinal("Products_code")) ? 0 : reader.GetInt32("Products_code");
                                Address address = new Address(corridor, column, level, hall, productCode);
                                addresses.Add(address);
                            }
                        }
                    }
                }
                return addresses;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar endereços: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return addresses;
            }
        }
    }
}
