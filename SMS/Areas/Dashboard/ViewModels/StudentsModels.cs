using SMS.Entities;
using System;
using System.Collections.Generic;

namespace SMS.Areas.Dashboard.ViewModels
{
    public class StudentsListingModel
    {
        public List<Student> Students { get; set; }
        public IEnumerable<Class> Classes { get; set; }
    }
    public class StudentsActionModel
    {
        public int RollNo { get; set; }
        public String StdName { get; set; }
        public String FatherName { get; set; }
        public DateTime DOB { get; set; }
        public int ClassID { get; set; }
        public string  Address { get; set; }
        public IEnumerable<Class> Classes { get; set; }
    }
}