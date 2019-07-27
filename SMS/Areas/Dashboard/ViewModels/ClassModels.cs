using SMS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Areas.Dashboard.ViewModels
{
    public class ClassListingModel
    {
        public IEnumerable<Class> Classes { get; set; }
    }
    public class ClassActionModel
    {
        [Key]
        public int ClassID { get; set; }
        public String Name { get; set; }
    }
}