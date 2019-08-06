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

        public void saveTeacher(Teacher tc)
        {
         using(SMSContext cntxt=new SMSContext())
            {
                cntxt.Teachers.Add(tc);
                cntxt.SaveChanges();
            }   
        }

        public void DeleteTeacher(int iD)
        {
            using (SMSContext cntxt=new SMSContext())
            {
                var findRes=cntxt.Teachers.Find(iD);
                cntxt.Teachers.Remove(findRes);
                cntxt.SaveChanges();
            }
        }

        public Teacher getTeacherByID(int value)
        {
            using (SMSContext cntxt = new SMSContext())
            {
                var data=cntxt.Teachers.Find(value);
                return data;
            }
        }

        public void EditTeacher(Teacher tt)
        {
            using (SMSContext cntxt=new SMSContext())
            {
                cntxt.Entry(tt).State = System.Data.Entity.EntityState.Modified;
                cntxt.SaveChanges();
            }
        }

        public List<Teacher> searchTeacher(string searchTerm)
        {
            SMSContext cntxt = new SMSContext();
            var res = cntxt.Teachers.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
            return res;
        }
    }
}
