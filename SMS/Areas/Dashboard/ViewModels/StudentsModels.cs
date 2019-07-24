using SMS.Entities;
using System;
using System.Collections.Generic;

namespace SMS.Areas.Dashboard.ViewModels
{
    public class StudentsListingModel
    {
        public IEnumerable<Student> Students { get; set; }
    }
    public class StudentsActionModel
    {
        public String StdName { get; set; }
        public String FatherName { get; set; }
        public DateTime DOB { get; set; }
    }
}