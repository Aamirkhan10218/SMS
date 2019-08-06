using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Entities
{
    public class Student
    {
        [Key]
        public int RollNo { get; set; }
        public String StdName { get; set; }
        public String FatherName { get; set; }
        public DateTime DOB { get; set; }
        public int ClassID { get; set; }
        public virtual Class Class { get; set; }
        public String Address { get; set; }
    }
}
