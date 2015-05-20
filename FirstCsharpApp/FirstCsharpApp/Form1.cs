using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FirstCsharpApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=ro";
                MySqlConnection myconn = new MySqlConnection(myConnection);
                MySqlDataAdapter mydatAdapter = new MySqlDataAdapter();
                mydatAdapter.SelectCommand = new MySqlCommand("select * from sakila.actor", myconn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(mydatAdapter);
                myconn.Open();
                DataSet ds = new DataSet();
                MessageBox.Show("Connected");
                myconn.Close();
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }


        }
    }
}
