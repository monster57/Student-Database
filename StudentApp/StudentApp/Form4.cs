using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using NHibernate;

namespace StudentApp
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {  
           MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
            ISession session = NHibernateHelper.GetCurrentSession();
            IQuery query = session.CreateQuery("SELECT s FROM Student s");
            string[]  arrayStrings ;
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Id", typeof (int));
            datatable.Columns.Add("Name", typeof (string));
            datatable.Columns.Add("age", typeof(int));
            datatable.Columns.Add("Subject1", typeof(string));
            datatable.Columns.Add("Subject2", typeof(string));
            datatable.Columns.Add("Subject3", typeof(string));
            datatable.Columns.Add("Subject4", typeof(string));

            foreach (Student student in query.List<Student>())
            {
                arrayStrings = student.Subjects.Select(sub => sub.Name).ToArray();
                datatable.Rows.Add(student.ID, student.FirstName + " " + student.LastName, student.Age, arrayStrings[0],
                    arrayStrings[1], arrayStrings[2], arrayStrings[3]);
            }
            dataGridView1.DataSource = datatable;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }
    }
}
