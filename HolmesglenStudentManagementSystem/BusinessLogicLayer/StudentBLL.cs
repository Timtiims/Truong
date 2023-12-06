using HolmesglenStudentManagementSystem.DataAccessLayer;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                 // this is a second one. 
namespace HolmesglenStudentManagementSystem.BusinessLogicLayer
{
    public class StudentBLL
    {
        AppDAL appDAL;
        public StudentBLL()
        {
            appDAL = new AppDAL();
        }
        public List<Student> GetAll()
        {
            return appDAL.StudentDALInstance.ReadAll();
        }

        public Student GetOne(string id)
        {
            return appDAL.StudentDALInstance.Read(id);
        }

        public bool Create(Student student)
        {
            if(GetOne(student.Id) != null)
            {
                // if student id exists, return false
                return false;
            }
            else
            {
                // if student id does not exist, create it
                appDAL.StudentDALInstance.Create(student);
            }

            return true;
        }

        public bool Update(Student student)
        {
            if (GetOne(student.Id) == null)
            {
                // if student id does not exist, return false
                return false;
            }
            else
            {
                // if student id exists, update it
                appDAL.StudentDALInstance.Update(student);
            }

            return true;
        }

        public bool Delete(string id)
        {
            if (GetOne(id) == null)
            {
                // if student id does not exist, return false
                return false;
            }
            else
            {
                // if student id exists, delete it
                appDAL.StudentDALInstance.Delete(id);
            }

            return true;
        }
        ///////////////////////////////////////////
        public class StudentBLL
        {
            private AppDBContext db;
            public StudentBLL (AppDBContext appDBContext)
            {
                this.db = AppDBContext;
            }
            //reading all student
            public List<Student> ReadAll() 
            {
                var students = db.Students.ToList();
                return students;
            }

            // read studnet by id 
            public Student Read( string id)
            {
                Student student = db.Student.Find(id);
                return student;
            }

            // create new student 

            public bool Create(Student student)
            {
                if (db.Students.Find(student.Id) == null)
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }

            //update
            public bool Update(Student student) 
            {
                var studentToUpdate = db.Students.Find(student.Id);
                if(studentToUpdate == null) 
                {
                    return false;
                }

                studentToUpdate.FirstName = student.FirstName;
                db.SaveChanges();
                return true;
            }

            // delete by id

            public bool Delete(Student student) 
            {
                var student = db.Students.Find(id);
                if (student == null)
                {
                    return false;
                }
                db.Students.Remove(student);
                db.SaveChanges();
                return true; 
            }
        }
    }
}
