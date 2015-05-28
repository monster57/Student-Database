using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentApp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseConnector databaseConnector = new DatabaseConnector();

            Student student = new Student();
            string value = this.id.Text;

            student.ID = Convert.ToInt32(this.id.Text);
            student.FirstName = this.fName.Text;
            student.LastName = this.lName.Text;
            student.Age = (this.age.Text=="")?0:Convert.ToInt32(this.age.Text);
//            student.Sub = this.subject.Text;

            QueryCreator queryCreator = new QueryCreator(student);
            Executor executor = new Executor(student, databaseConnector, queryCreator);
            String message = executor.Execute(QueryType.UPDATEQUERY);
            MessageBox.Show(message);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fr1 = new Form1();
            fr1.ShowDialog();
        }
    }
}
