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
        public List<Student> getAllStudents()
        {
        var cntxt = new SMSContext();
        
            return cntxt.Students.ToList();
        }

        public void saveStudent(Student std)
        {
            var cntxt = new SMSContext();
            cntxt.Students.Add(std);
            cntxt.SaveChanges();
        }

        public Student getStudentByRoll(int rollNo)
        {
            var cntxt = new SMSContext();
            return cntxt.Students.Where(x => x.RollNo == rollNo).FirstOrDefault();

        }

        public void EditStudent(Student std)
        {
            var cntxt = new SMSContext();
            cntxt.Entry(std).State = System.Data.Entity.EntityState.Modified;
            cntxt.SaveChanges();
        }

        public void DeleteStudent(Student std)
        {
            var cntxt = new SMSContext();
            cntxt.Entry(std).State = System.Data.Entity.EntityState.Deleted;
            cntxt.SaveChanges();
        }

        public List<Student> getAllStudentByName(string stdName,int ID)
        {
            var cntxt = new SMSContext();
             return cntxt.Students.Where(x => x.StdName.ToLower().Contains(stdName.ToLower())||x.ClassID==ID).ToList();
        }
    }
}
