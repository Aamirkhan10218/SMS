using Microsoft.AspNet.Identity.EntityFramework;
using SMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Areas.Dashboard.ViewModels
{
    public class RoleListingModel
    {
        public List<IdentityRole> Roles { get; set; }
        public String  searchTerm { get; set; }
        public Pager Pager { get; set; }
    }
    public class RoleActionModel
    {
        public String ID { get; set; }
        public String Name { get; set; }
    }
}