using Microsoft.AspNet.Identity.EntityFramework;
using SMS.Entities;
using System.Data.Entity;

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
