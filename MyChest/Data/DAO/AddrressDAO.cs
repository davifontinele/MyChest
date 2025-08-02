using MyChest.Models;

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
    }
}
