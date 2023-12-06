using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.SubjectPL
{
    public class GetAllSubject : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Getting all subjects");

            var subjectBLL = new SubjectBLL();
            var result = subjectBLL.GetAll();
            if (result.Count == 0)
            {
                Console.WriteLine("Table is empty");
            }
            else
            {
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.SubjectId}\t{item.Title}");
                }
            }
        }
    }
}
