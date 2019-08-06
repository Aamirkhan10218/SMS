using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Services
{
    public class ClassServices
    {
        public List<Class> getAllClasses()
        {
            var cntxt = new SMSContext();
            return cntxt.Classes.ToList();
        }

        public IEnumerable<Class> getSearchResult(string searchTerm)
        {
          
            var cntxt = new SMSContext();
            return  cntxt.Classes.Where(x => x.ClassName.ToLower().Contains(searchTerm.ToLower())).ToList();
           // return cntxt.Classes.ToList();
        }

        public void saveClass(Class cla)
        {
          
            var cntxt = new SMSContext();
            cntxt.Classes.Add(cla);
            cntxt.SaveChanges();
        }
        public Class getClassbyID(int? id)
        {
            var contxt = new SMSContext();

            var data = contxt.Classes.Find(id);
            return data;
        }
        public void eidtClass(Class cla)
        {
            var cntxt = new SMSContext();
            cntxt.Entry(cla).State = System.Data.Entity.EntityState.Modified;
            cntxt.SaveChanges();
        }
        public void deleteClass(Class cla)
        {
            var cntxt = new SMSContext();
            cntxt.Entry(cla).State = System.Data.Entity.EntityState.Deleted;
            cntxt.SaveChanges();
        }

    }
}
