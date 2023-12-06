using HolmesglenStudentManagementSystem.DataAccessLayer;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.BusinessLogicLayer
{
    public class StudentBLLDisconnected
    {
        AppDAL appDAL;
        public StudentBLLDisconnected()
        {
            appDAL = new AppDAL();
        }
        public List<Student> ReadAll()
        {
            return appDAL.DALDisconnectedInstance.StudentReadAll();
        }
    }

}


