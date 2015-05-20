using System;
using System.Runtime.ExceptionServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentApp
{
    class Executor
    {
        private Operation operation;
        private Student student;
        private readonly DatabaseConnector databaseConnector;

        public Executor(Operation operation, Student student, DatabaseConnector databaseConnector)
        {
            this.student = student;
            this.databaseConnector = databaseConnector;
            this.operation = operation;

        }

        public string Execute()
        {
            string query;
            query =  (student.ID == 0) ? operation.InsertData(student) : operation.UpdateData(student);
            MySqlConnection myconn = databaseConnector.CreateConnection();
            MySqlCommand command = new MySqlCommand(query, myconn);
            command.CommandText = query;
            GetValue(student, command);
            try
            {
                using (MySqlConnection connection = myconn)
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return (student.ID == 0) ? "Inserted" : "updated";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        public static void GetValue(Student student, MySqlCommand command)
        {
            command.Parameters.AddWithValue("@fName", student.Fname);
            command.Parameters.AddWithValue("@lName", student.Lname);
            command.Parameters.AddWithValue("@age", student.Age);
            command.Parameters.AddWithValue("@subject", student.Subject);
            command.Parameters.AddWithValue("@id", student.ID);
        }
    }
}