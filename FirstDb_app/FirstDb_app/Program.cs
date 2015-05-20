using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FirstDb_app
{
    class ConnecDatabase
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string userId;
        private string password;

        public ConnecDatabase()
        {
            Initialize();
            OpenConnection();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "sakila";
            userId = "root";
            password = "root";
            string connectionString;
            connectionString = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + userId + ";PASSWORD=" + password +
                               ";";
            connection= new MySqlConnection(connectionString);

        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
    
    class Program
    {

        static void Main(string[] args)
        {
            ConnecDatabase cd = new ConnecDatabase();

        }
    }
}
