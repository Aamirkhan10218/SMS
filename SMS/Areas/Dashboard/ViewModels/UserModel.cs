using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Areas.Dashboard.ViewModels
{
    public class UserListingModel
    {
        public IQueryable<SMSUser> Users { get; set; }
    }
}