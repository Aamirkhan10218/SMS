using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
   public class Student
    {
        [Key]
        public int RollNo { get; set; }
        public String StdName { get; set; }
        public String FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Class ClassID { get; set; }
        public Teacher ID { get; set; }
    }
}
