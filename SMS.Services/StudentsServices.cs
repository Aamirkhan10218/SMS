using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class StudentsServices
     {
        public IEnumerable<Student> getAllStudents()
        {
        var cntxt = new SMSContext();
        
            return cntxt.Students.ToList();
        }

        public void saveStudent(Teacher tt)
        {
          
                var cntxt = new SMSContext();
            cntxt.Teachers.Add(tt);
                cntxt.SaveChanges();
           
        }
    }
}
