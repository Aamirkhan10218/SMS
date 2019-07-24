using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Data;
using SMS.Entities;

namespace SMS.Services
{
    public class ClassServices
    {
        public IEnumerable<Class> getAllClasses()
        {
            var cntxt = new SMSContext();
            return cntxt.Classes.ToList();
        }

        public void saveClass(Class cla)
        {
          
            var cntxt = new SMSContext();
            cntxt.Classes.Add(cla);
            cntxt.SaveChanges();
        }
    }
}
