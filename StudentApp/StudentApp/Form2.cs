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

namespace StudentApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            DatabaseConnector databaseConnector = new DatabaseConnector();
            
            Student student = new Student();
            student.Fname = this.fName.Text;
            student.Lname = this.lName.Text;
            student.Age = Convert.ToInt32(this.age.Text);
            student.Subject = this.subject.Text;
            Operation operation = new Operation();
            Executor executor = new Executor(operation , student, databaseConnector);

            String message = executor.Execute();
            MessageBox.Show(message);
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fr1 = new Form1();
            fr1.ShowDialog();
        }
    }
}
