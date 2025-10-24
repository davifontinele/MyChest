using MyChest.Interfaces;
using MyChest.Models;

namespace MyChest.Data.DAO
{
    internal class AddressDAO : IData<Address>
    {
        List<Address> IData<Address>.GetAllData()
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
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show($"Elemento de pesquisa fora do alcançe ou não existe. | {ex.GetType().Name} - {ex.Message}", "ERROR [GetAllData]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return addresses;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar todos os endereços. | {ex.GetType().Name} - {ex.Message}", "ERROR [GetAllData]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return addresses;
            }
        }

        Address IData<Address>.GetById(int id)
        {
            Address address = new Address();
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT idaddress ,corridor, `column`, level, hall, Products_code " +
                        "FROM addresses " +
                        $"WHERE idaddress = {id};";

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
                            return address;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar endereço pelo Id. | {ex.GetType().Name} - {ex.Message}", "ERROR [GetById]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return address;
            }
        }

        public void InsertNewAddress(Address address)
        {
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO `addresses` (`corridor`, `column`, `level`, `hall`, `Products_code`) " +
                                   "VALUES (@corridor, @column, @level, @hall, @productCode)";
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@corridor", address.Corridor);
                        command.Parameters.AddWithValue("@column", address.Column);
                        command.Parameters.AddWithValue("@level", address.Level);
                        command.Parameters.AddWithValue("@hall", address.Hall);
                        command.Parameters.AddWithValue("@productCode",
                            address.ProductCode.HasValue ? address.ProductCode.Value : DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Endereço inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Erro ao inserir um novo endereço. | {e.GetType().Name} - {e.Message}", "ERROR [InsertNewAddress]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Pesquisa todos os endereços que estão vazios, ou seja, onde o campo Products_code é nulo.
        /// </summary>
        /// <returns>Retorna uma lista dos endereços vazios</returns>
        public List<Address> GetAllAddressesEmpty()
        {
            List<Address> addresses = new List<Address>();
            try
            {
                using (var connetion = DbConnection.GetConnection())
                {
                    connetion.Open();

                    string query = "SELECT * FROM addresses " +
                        "WHERE Products_code IS NULL;";

                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connetion))
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
                                Address address = new Address(corridor, column, level, hall, productCode == 0 ? null : productCode);
                                addresses.Add(address);
                            }
                        }
                    }
                }
                return addresses;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar todos os enderços vazios. | {ex.GetType().Name} - {ex.Message}", "ERROR [GetAllAddressesEmpty]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return addresses;
            }
        }

        /// <summary>
        /// Pesquisa um endereço específico baseado no número do corredor, coluna, nível e hall.
        /// </summary>
        /// <param name="corridor">Valor do corredor do endereço</param>
        /// <param name="column">Valor da coluna do endereço</param>
        /// <param name="level">Valor do nivel do endereço</param>
        /// <param name="hall">Valor do hall do endereço</param>
        /// <returns>Retorna o Objeto "Address" com os parâmetros preenchidos,
        /// usado para preencher um dataGridView</returns>
        public Address GetAddressByNumbers(int corridor, int column, int level, int hall)
        {
            Address address = new Address();
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT idaddress ,corridor, `column`, level, hall, Products_code " +
                        "FROM addresses " +
                        $"WHERE corridor = {corridor} " +
                        $"AND `column` = {column} " +
                        $"AND level = {level} " +
                        $"AND hall = {hall};";

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
                            return address;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao pesquisar endereço especificado. | {ex.GetType().Name} - {ex.Message}", "ERROR [GetAddressByNumbers]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT idaddress " +
                        "FROM addresses " +
                        $"WHERE addresses.corridor = {corridor} " +
                        $"AND addresses.column = {column} " +
                        $"AND addresses.level = {level} " +
                        $"AND addresses.hall = {hall};";

                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar o Id do endereço especificado. | {ex.GetType().Name} - {ex.Message}", "ERROR [GetAddressId]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public int GetProductIdOnAddress(int corridor, int column, int level, int hall)
        {
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT Products_code " +
                        "FROM addresses " +
                        $"WHERE addresses.corridor = {corridor} " +
                        $"AND addresses.corridor = {column} " +
                        $"AND addresses.level = {level} " +
                        $"AND addresses.hall = {hall};";

                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar código do produto no endereço especificado. | {ex.GetType().Name} - {ex.Message}", "ERROR [GetProductIdOnAddress]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Move o produto especificado para o endereço especificado.
        /// </summary>
        /// <param name="codeProd">Código do produto a ser movido</param>
        /// <param name="address">Destino ou endereço que o produto será movido</param>
        public void MoveProductForAddress(int codeProd, Address address)
        {
            if (
                GetAddressByNumbers(address.Corridor, address.Column, address.Level, address.Hall).ProductCode == 0 || 
                GetAddressByNumbers(address.Corridor, address.Column, address.Level, address.Hall).ProductCode == null)
            {
                try
                {
                    using (var connection = DbConnection.GetConnection())
                    {
                        connection.Open();

                        string query = "UPDATE `addresses` " +
                            $"SET `Products_code` = '{codeProd}' " +
                            $"WHERE `addresses`.`idaddress` = {GetAddressId(address.Corridor, address.Column, address.Level, address.Hall)}";

                        using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show($"Produto {codeProd} movimentado para {address.Corridor}-{address.Column}-{address.Level}-{address.Hall}.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível movimentar o produto {codeProd} | {ex.GetType().Name} - {ex.Message}", "ERROR [MoveProductForAddress]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    $"O endereço {address.Corridor}-{address.Column}-{address.Level}-{address.Hall} já possui um produto associado. Deseja fazer a troca entre de produtos?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (var connection = DbConnection.GetConnection())
                        {
                            connection.Open();

                            ProductDAO productDAO = new ProductDAO();

                            string query = "START TRANSACTION; " +
                                "UPDATE addresses a " +
                                "JOIN (" +
                                "SELECT idaddress, " +
                                    "Products_code " +
                                    "FROM addresses " +
                                    $"WHERE idaddress IN ({GetAddressId(address.Corridor, address.Column, address.Level, address.Hall)}, {productDAO.GetAddressIdByProductId(codeProd)})" +
                                    ") " +
                                    "AS temp " +
                                    "ON a.idaddress = temp.idaddress " +
                                    "SET a.Products_code = ( " +
                                    "SELECT Products_code " +
                                    "FROM addresses " +
                                    $"WHERE idaddress = IF(temp.idaddress = {GetAddressId(address.Corridor, address.Column, address.Level, address.Hall)}, {productDAO.GetAddressIdByProductId(codeProd)}, {GetAddressId(address.Corridor, address.Column, address.Level, address.Hall)})" +
                                    "); " +
                                    "COMMIT;";

                            using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show($"Produtos movimentados com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Não foi possível movimentar os produtos {codeProd} | {ex.GetType().Name} - {ex.Message}", "ERROR [MoveProductForAddress]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return;
            }
        }
    }
}
