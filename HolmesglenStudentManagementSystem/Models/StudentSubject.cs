using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.Models
{
    public class StudentSubject
    {
        public string StudentID;
        public string StudentName;
        public string SubjectID;
        public string SubjectTitle;

        public StudentSubject()
        {
            StudentID = "";
            StudentName = "";
            SubjectID = "";
            SubjectTitle = "";

        }

        public StudentSubject ( string studentID, string studentName,string subjectID, string subjectTitle)
        {
            StudentID =studentID;
            StudentName =studentName;
            SubjectID =subjectID;
            SubjectTitle =subjectTitle;
        }
    }

    
}
