using MySql.Data.MySqlClient;

namespace MyChest.Data
{
    public class DbConnection
    {
        public static MySqlConnection GetConnection()
        {
            string dbConnection = $"Server=localhost;" +
            $"DataBase=mychestdb;" +
            $"User Id=root;" +
            $"Password=teste;";
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
