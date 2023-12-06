using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.Models
{
    public class Enrollment
    {
        public string EnrollmentID { get; set; }
        public string StudentID_FK {  get; set; }
        public string SubjectID_FK { get; set; }

        public Enrollment()
        {
            EnrollmentID = "";
            StudentID_FK = "";
            SubjectID_FK = "";
        }

        public Enrollment(string enrollmentID, string studentID_FK, string subjectID_FK)
        {
            EnrollmentID = enrollmentID;
            StudentID_FK = studentID_FK;
            SubjectID_FK = subjectID_FK;
        }
    }  

}
