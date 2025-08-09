using MySql.Data.MySqlClient;

namespace MyChest.Data
{
    public class DbConnection
    {
        /// <summary>
        /// Representa a conexão com o banco de dados MySQL.
        /// </summary>
        /// <returns>Retorna uma instância de MySqlConnection.</returns>
        public static MySqlConnection GetConnection()
        {
            // Define as  informações de conexão com o banco de dados.
            string dbConnection = $"Server=localhost;" +
            $"DataBase=mychestdb;" +
            $"User Id=root;" +
            $"Password={null};";

            // Retorna uma nova instância de MySqlConnection com as informações de conexão.
            return new MySqlConnection(dbConnection);
       }
        public static MySqlConnection GetConnection(string server, string database, string userId, string password)
        {
            string dbConnection = $"Server={server};" +
            $"DataBase={database};" +
            $"User Id={userId};" +
            $"Password={password};";
            return new MySqlConnection(dbConnection);
        }
    }
}
