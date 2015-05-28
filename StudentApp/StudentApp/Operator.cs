using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentApp
{
    class Operator

    {
        private DatabaseConnector databaseConnector;
        private QueryCreator query;

        public Operator(DatabaseConnector databaseConnector ,QueryCreator query)
        {
            this.databaseConnector = databaseConnector;
            this.query = query;
        }

        public string ShowData(DataGridView dataGridView1)
        {
            MySqlConnection myconn = databaseConnector.CreateConnection();
            string q = query.CreateSelectQuery();
            MySqlCommand command = new MySqlCommand(q, myconn);
            command.CommandText = q;

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable studentDataTable = new DataTable();
                DataTable connectionsDataTable = new DataTable();
                DataTable subjectDataTable = new DataTable();
                sda.Fill(studentDataTable);

                sda.SelectCommand = new MySqlCommand("SELECT * FROM `NEW_STUDENT`.`SUB_STD_CONNECTION` ORDER BY STD_ID, SUB_ID", myconn);
                sda.Fill(connectionsDataTable);

                sda.SelectCommand = new MySqlCommand("SELECT * FROM `NEW_STUDENT`.`SUB_DETAIL`", myconn);
                sda.Fill(subjectDataTable);

                var subjects = subjectDataTable.Rows.Cast<DataRow>().ToDictionary(row => row["ID"].ToString(), row => row["SUBJECT"].ToString());

                var x = 10;
                var y = 20;
                var z = (x + 10)*y;


                var studentSubjects = new Dictionary<string, List<string>>();

                foreach (DataRow row in connectionsDataTable.Rows)
                {
                    var studentId = row["STD_ID"].ToString();
                    if (studentSubjects.ContainsKey(studentId))
                    {
                        studentSubjects[studentId].Add(row["SUB_ID"].ToString());
                    }
                    else
                    {
                        studentSubjects.Add(studentId, new List<string>());
                        studentSubjects[studentId].Add(subjects[row["SUB_ID"].ToString()]);
                    }

                }

                BindingSource bs = new BindingSource { DataSource = studentDataTable };


                MessageBox.Show("this is the data ");

                dataGridView1.DataSource = bs;
                
                MessageBox.Show("this is the data again");
                sda.Update(studentDataTable);
                return "select";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}