using System;
using HolmesglenStudentManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.BusinessLogicLayer;

namespace HolmesglenStudentManagementSystem.PresentationLayer.SubjectPL
{
    public class UpdateSubject : PLBase
    {
        public override void Run()
        {
            var subject = new Subject();
            Console.WriteLine("Updating a subject");
            Console.Write("Enter Subject ID: ");
            subject.SubjectId = Console.ReadLine();
            Console.Write("Enter Title: ");
            subject.Title = Console.ReadLine();

            var subjectBLL = new SubjectBLL();
            var result = subjectBLL.Update(subject);

            if (result == false)
            {
                Console.WriteLine($"Update subject unsuccessful");
            }
            else
            {
                Console.WriteLine($"Update subject successful");
            }
        }
    }
}
