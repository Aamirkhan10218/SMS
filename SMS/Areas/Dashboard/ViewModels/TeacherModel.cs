using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Areas.Dashboard.ViewModels
{
    public class TeacherModel
    {
      
    }
    public class TeacherListingModel
    {
        public IEnumerable<Teacher> Teachers { get; set; }
    }
    public class TeacherActionModel
    {
        public int ID { get; set; }
        public String Name { get; set; }

    }
}