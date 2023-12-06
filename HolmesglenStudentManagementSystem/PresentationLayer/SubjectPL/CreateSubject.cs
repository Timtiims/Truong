using System;
using HolmesglenStudentManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.BusinessLogicLayer;
namespace HolmesglenStudentManagementSystem.PresentationLayer.SubjectPL
{
    public class CreateSubject : PLBase
    {
        public override void Run()
        {
            var subject = new Subject();
            Console.WriteLine("Creating a new subject");
            Console.Write("Enter Subject ID: ");
            subject.SubjectId = Console.ReadLine();
            Console.Write("Enter Title: ");
            subject.Title = Console.ReadLine();

            var subjectBLL = new SubjectBLL();
            var result = subjectBLL.Create(subject);

            if (result == false)
            {
                Console.WriteLine($"Create new subject unsuccessful");
            }
            else
            {
                Console.WriteLine($"Create new subject successful");
            }
        }
    }
}
