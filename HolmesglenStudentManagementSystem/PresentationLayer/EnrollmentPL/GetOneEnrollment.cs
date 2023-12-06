using System;
using HolmesglenStudentManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.BusinessLogicLayer;

namespace HolmesglenStudentManagementSystem.PresentationLayer.EnrollmentPL
{
    public class GetOneEnrollment : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Getting an enrollment");
            Console.Write("Enrollment ID: ");
            var id = Console.ReadLine();

            var enrollmentBLL = new EnrollmentBLL();
            var enrollment = enrollmentBLL.GetOne(id);
            if (enrollment == null)
            {
                Console.WriteLine($"Enrollment({id}) does not exist");
            }
            else
            {
                Console.WriteLine($"{enrollment.EnrollmentID}\t{enrollment.StudentID_FK}\t{enrollment.SubjectID_FK}");
            }

        }
    }
}
