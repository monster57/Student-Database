using System.Text;

namespace StudentApp
{
    class QueryCreator
    {
        private Student student;

        public QueryCreator(Student student)
        {
            this.student = student;
        }

        public string CreateInsertQuery()
        {
            return "INSERT INTO new_student.std_details(first_name  , last_name , age) values (@fName , @lName , @age)";
        }

        public string CreateUpdateQuery()
        {   
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append("UPDATE new_student.std_detail SET");
            if (student.FirstName != "")
                queryBuilder.Append(" first_name = @fName ");
            
//            if (student.FirstName != "" && (student.LastName != "" || student.Age != 0 || student.Sub != ""))
//                queryBuilder.Append(",");
            
            if (student.LastName != "")
                queryBuilder.Append(" last_name = @lName ");
//            
//            if (student.LastName != "" && (student.Age != 0 || student.Sub != ""))
//                queryBuilder.Append(",");
//            
//            if (student.Age != 0)
//                queryBuilder.Append(" age = @age ");
//            
//            if (student.Age != 0 && student.Sub != "")
//                queryBuilder.Append(",");
//            
//            if (student.Sub !="")
//                queryBuilder.Append("  Subject = @subject ");
            
            queryBuilder.Append("where Id = @id ");
            return queryBuilder.ToString();
        }

        public string CreateSelectQuery()
        {
            return "select s.id, s.f_name, s.l_name , s.age , "+ 
                    "Max(if(sd.subject = 'Math' , sd.subject , null)) as subject1, "+
                    "Max(if(sd.subject = 'Geography' , sd.subject , null)) as subject2, "+
                    " Max(if(sd.subject = 'History' , sd.subject , null)) as subject3 , + " +
                   " Max(if(sd.subject = 'English', sd.subject , null)) as subject4, "+
                   "Max(if(sd.subject = 'Biology', sd.subject , null)) as subject5 "+
                   "from new_student.std_details s "+
                   "INNER JOIN new_student.sub_std_connection su "+
                   " ON s.id = su.std_id INNER JOIN new_student.sub_detail sd "+
                   "ON sd.id = su.sub_id GROUP BY s.id, s.f_name, s.l_name;";
        }
    }
}