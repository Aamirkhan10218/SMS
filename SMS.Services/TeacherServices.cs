using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
  public class TeacherServices
    {
        public List<Teacher> getAllTeacher()
        {
            using(SMSContext cntxt=new SMSContext())
            {
                var data=cntxt.Teachers.ToList();
                return data;
            }
        }
    }
}
