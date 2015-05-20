using MySql.Data.MySqlClient;

namespace StudentApp
{
    internal class DatabaseConnector
    {
        public MySqlConnection CreateConnection()
        {
            MySqlConnectionStringBuilder mySqlConnection = new MySqlConnectionStringBuilder();
            mySqlConnection.Server = "localhost";
            mySqlConnection.UserID = "root";
            mySqlConnection.Password = "root";
            mySqlConnection.Database = "new_student";
            
            return new MySqlConnection(mySqlConnection.ToString());
        }

        
    }
}