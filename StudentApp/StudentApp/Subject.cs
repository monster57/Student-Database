using System.Collections.Generic;

namespace StudentApp
{
    public class Subject
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }

        public virtual ISet<Student> Students { get; set; }
    }
}