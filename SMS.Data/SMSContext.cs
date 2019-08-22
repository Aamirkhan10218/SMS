using Microsoft.AspNet.Identity.EntityFramework;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data
{
   public  class SMSContext : IdentityDbContext<SMSUser>
    {
        public SMSContext() :
            base("SMSConnection")
        {
        }
        public static SMSContext Create()
        {
            return new SMSContext();
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
    }
}
