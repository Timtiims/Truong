using HolmesglenStudentManagementSystem.DataAccessLayer;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.BusinessLogicLayer
{
    public class SubjectBLL
    {
        AppDAL appDAL;
        public SubjectBLL() 
        {
            appDAL = new AppDAL();  
        }
        public List<Subject> GetAll()
        {
            return appDAL.SubjectDALInstance.ReadAll();
        }
        public Subject GetOne(string id) 
        {
            return appDAL.SubjectDALInstance.Read(id);
        }
        public bool Create(Subject subject)
        {
            if (GetOne(subject.SubjectId) != null)
            {
                // if subject id exists, return false
                return false;
            }
            else
            {
                // if subject id does not exist, create it
                appDAL.SubjectDALInstance.Create(subject);
            }

            return true;
        }

        public bool Update(Subject subject)
        {
            if (GetOne(subject.SubjectId) == null)
            {
                // if subject id does not exist, return false
                return false;
            }
            else
            {
                // if subject id exists, update it
                appDAL.SubjectDALInstance.Update(subject);
            }

            return true;
        }

        public bool Delete(string id)
        {
            if (GetOne(id) == null)
            {
                // if subject id does not exist, return false
                return false;
            }
            else
            {
                // if subject id exists, delete it
                appDAL.SubjectDALInstance.Delete(id);
            }

            return true;
        }

    }
}
