using System;
using HolmesglenStudentManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.BusinessLogicLayer;

namespace HolmesglenStudentManagementSystem.PresentationLayer.EnrollmentPL
{
    public class CreateEnrollment : PLBase
    {
        public override void Run()
        {
            var enrollment = new Enrollment();
            Console.WriteLine("Creating a new enrollment");
            Console.Write("Enter ID: ");
            enrollment.EnrollmentID = Console.ReadLine();
            Console.Write("Enter the Student ID: ");
            enrollment.StudentID_FK = Console.ReadLine();
            Console.Write("Enter the Subject id Name: ");
            enrollment.SubjectID_FK = Console.ReadLine();


            var enrollmentBLL = new EnrollmentBLL();
            var result = enrollmentBLL.Create(enrollment);

            if (result == false)
            {
                Console.WriteLine($"Create new enrollment unsuccessful");
            }
            else
            {
                Console.WriteLine($"Create new enrollment successful");
            }
        }
    }
}
