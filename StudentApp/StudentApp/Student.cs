using System;
using System.Collections.Generic;

namespace StudentApp
{
    public class Student
    {
        public virtual int ID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Age { get; set; }

        public virtual ISet<Subject> Subjects { get; set; }
    }
}