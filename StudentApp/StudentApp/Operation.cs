using System;
using System.Security.Cryptography.X509Certificates;
using MySql.Data.MySqlClient;

namespace StudentApp
{
    internal class Operation
    {
        private Student student;
      

        public string InsertData(Student student)
        {

            return 
                "INSERT INTO new_student.std_detail(first_name , last_name , age , Subject) values (@fName , @lName , @age , @subject)";
            
        }

        public string UpdateData(Student student)
        {

            return
                "UPDATE new_student.std_detail SET first_name = @fName ,last_name = @lName , age = @age , Subject = @subject where Id = @id ";
        }

   
    }
}