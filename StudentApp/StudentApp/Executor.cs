using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentApp
{
    class Executor
    {
        private Student student;
        private readonly DatabaseConnector databaseConnector;
        private readonly QueryCreator queryCreator;
        SortedDictionary<Enum, string> sd;
        SortedDictionary<Enum, string> sdMessage; 
        
       
        public Executor(Student student, DatabaseConnector databaseConnector, QueryCreator queryCreator)
        {
            this.student = student;
            this.databaseConnector = databaseConnector;
            this.queryCreator = queryCreator;
            sdMessage = new SortedDictionary<Enum, string>();
            sd = new SortedDictionary<Enum, string>();
            sd.Add(QueryType.INSERTQUERY, queryCreator.CreateInsertQuery());
            sd.Add(QueryType.UPDATEQUERY, queryCreator.CreateUpdateQuery());
            sd.Add(QueryType.SELECTQUERY, queryCreator.CreateSelectQuery());
            sdMessage.Add(QueryType.INSERTQUERY , "Inserted");
            sdMessage.Add(QueryType.UPDATEQUERY , "Updated");
            sdMessage.Add(QueryType.SELECTQUERY , "Selected");
        }

        public string GiveQuery(QueryType query)
        {       
            return sd[query];
        }

        public string Execute(QueryType queryType)
        {
            string query;
            query = GiveQuery(queryType);
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
                return sdMessage[queryType];
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        public static void GetValue(Student student, MySqlCommand command)
        {
            command.Parameters.AddWithValue("@fName", student.FirstName);
            command.Parameters.AddWithValue("@lName", student.LastName);
            command.Parameters.AddWithValue("@age", student.Age);
//            command.Parameters.AddWithValue("@subject", student.Sub);
            command.Parameters.AddWithValue("@id", student.ID);
        }
    }
}