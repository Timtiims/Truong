using System;
using HolmesglenStudentManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.BusinessLogicLayer;

namespace HolmesglenStudentManagementSystem.PresentationLayer.EnrollmentPL
{
    public class GetAllEnrollment : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Getting all enrollments");

            var enrollmentBLL = new EnrollmentBLL();
            var result = enrollmentBLL.GetAll();
            if (result.Count == 0)
            {
                Console.WriteLine("Table is empty");
            }
            else
            {
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.EnrollmentID}\t{item.StudentID_FK}\t{item.SubjectID_FK}");
                }
            }
        }
    }
}
