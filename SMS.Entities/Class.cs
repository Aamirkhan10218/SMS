using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
  public  class Class
    {
        /// <summary>
        /// Class ID Define the Class No of Student
        /// </summary>
        /// 
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Class Name in English
        /// </summary>
        public String ClassName { get; set; }
    }
}
