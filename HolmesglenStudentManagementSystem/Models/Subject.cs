using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.Models
{
    public class Subject
    {
        public string SubjectId { get; set; }
        public string Title { get; set; }



        public Subject()
        {
            SubjectId = "";
            Title = "";





        }

        public Subject(string subjectID, string title)
        {
            SubjectId = subjectID;
            Title = title;



        }
    }
}
