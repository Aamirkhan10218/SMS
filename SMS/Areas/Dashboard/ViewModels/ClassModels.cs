using SMS.Entities;
using System;
using System.Collections.Generic;
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
        public String Name { get; set; }
    }
}