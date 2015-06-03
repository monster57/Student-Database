using System;
using System.Collections.Generic;
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
         ISession session = NHibernateHelper.GetCurrentSession();
        private ISession anotherSession = NHibernateHelper.GetCurrentSession();

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            
            IQuery query = session.CreateQuery("SELECT s FROM Student s");
            string[]  arrayStrings ;
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Id", typeof (int));
            datatable.Columns.Add(" First Name", typeof(string));
            datatable.Columns.Add("Last Name", typeof (string));
            datatable.Columns.Add("age", typeof(int));
            datatable.Columns.Add("Subject1", typeof(string));
            datatable.Columns.Add("Subject2", typeof(string));
            datatable.Columns.Add("Subject3", typeof(string));
            datatable.Columns.Add("Subject4", typeof(string));

            foreach (Student student in query.List<Student>())
            {
                arrayStrings = student.Subjects.Select(sub => sub.Name).ToArray();
                datatable.Rows.Add(student.ID, student.FirstName , student.LastName, student.Age, arrayStrings[0],
                    arrayStrings[1], arrayStrings[2], arrayStrings[3]);
            }
//            dataGridView1.Width = datatable.Columns.
            dataGridView1.DataSource = datatable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView1.RowCount + "");
            if (dataGridView1.RowCount != 0)
            {
               
                 IQuery query = session.CreateQuery("SELECT s FROM Student s");
            // MessageBox.Show(dataGridView1.Rows[1].Cells[1].Value.ToString()); 


               
                
                using (session.BeginTransaction())
                {
                    for (int i = 1; i < dataGridView1.RowCount; i++)
                    {
                        Student student = session.Load<Student>(i);
                        student.ID = Convert.ToInt32(dataGridView1.Rows[i - 1].Cells[0].Value.ToString());
                        student.FirstName = dataGridView1.Rows[i-1].Cells[1].Value.ToString();
                        student.LastName = dataGridView1.Rows[i - 1].Cells[2].Value.ToString();
                        student.Age = Convert.ToInt32(dataGridView1.Rows[i - 1].Cells[3].Value.ToString());

                        session.SaveOrUpdate(student);

                    }
                    session.Transaction.Commit();
                    
                }
                
            int rowCount = dataGridView1.RowCount;

            MessageBox.Show("" + rowCount);
            }


        }
    }
}
