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
        public List<Student> getAllStudents(int recordSize,int page)
        {
        var cntxt = new SMSContext();

            var skip =(page-1)*recordSize;
            return cntxt.Students.OrderBy(x=>x.StdName).Skip(skip).Take(recordSize).ToList();
        }
        public int getAllStudentsCount()
        {
            var cntxt = new SMSContext();
            return cntxt.Students.Count();
      
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

        public List<Student> getAllStudentByName(string stdName,int ID,int recordSize, int page)
        {
            var cntxt = new SMSContext();
             var students= cntxt.Students.Where(x => x.StdName.ToLower().Contains(stdName.ToLower())||x.ClassID==ID);
            var skip = (page - 1 )* recordSize;
            return students.OrderBy(x=>x.StdName).Skip(skip).Take(recordSize).ToList();
        }
        public int getAllStudentByNameCount(int? ID, string stdName)
        {
            var cntxt = new SMSContext();
            var students = cntxt.Students.Where(x => x.StdName.ToLower().Contains(stdName.ToLower()) || x.ClassID == ID.Value);
            return students.Count();
        }
    }
}
