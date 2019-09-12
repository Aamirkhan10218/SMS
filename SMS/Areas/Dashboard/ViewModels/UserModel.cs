using SMS.Entities;
using SMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Areas.Dashboard.ViewModels
{
    public class UserListingModel
    {
        public List<SMSUser> Users { get; set; }
        public Pager Pager { get; set; }
        public string  RoleID { get; set; }
        public String UserName { get; set; }
        public String  Email { get; set; }
    }
    public class UserActionModel
    {
        public string ID { get; set; }
        public String FullName { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
    }
}