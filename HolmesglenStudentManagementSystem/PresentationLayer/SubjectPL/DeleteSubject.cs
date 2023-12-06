using System;
using HolmesglenStudentManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.BusinessLogicLayer;

namespace HolmesglenStudentManagementSystem.PresentationLayer.SubjectPL
{
    public class DeleteSubject : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Deleting a subject");
            Console.Write("Subject ID: ");
            var id = Console.ReadLine();

            var subjectBLL = new SubjectBLL();
            var result = subjectBLL.Delete(id);
            if (result == false)
            {
                Console.WriteLine($"Delete student unsuccessful");
            }
            else
            {
                Console.WriteLine($"Delete student successful");
            }
        }
    }
}
