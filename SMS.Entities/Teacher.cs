﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
  public class Teacher
    {
        [Key]
        public int ID { get; set; }
        public String  Name { get; set; }
        
    }
}
