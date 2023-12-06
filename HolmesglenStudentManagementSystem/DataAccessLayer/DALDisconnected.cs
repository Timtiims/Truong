    using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
// step 1
// create a class bll named it " StudentBLLdisconnect"
// create a class in  PL called it " studentPLDisconnect"
// call one method to run from the disconnectedmode such as readall(). 

//step2
// create entity framework for student table only
//step3
// finalise import and export for csv
//step 4
// make the project user friendly ( have cli instruction for user) 
namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class DALDisconnected
    {
        private SQLiteConnection Connection;
        private SQLiteDataAdapter DataAdapter;
        private DataSet DBDataSet;
        private string DBQueryString = @"SELECT StudentID, FirstName FROM Student;  
                                        SELECT SubjectId, Title FROM Subject; 
                                        SELECT EnrollmentID, StudentID_FK, SubjectID_FK FROM Enrollment;";
        string connectionString = @"Data Source=C:\Users\banhb\Desktop\HolmesglenInstitude.db";
        public DALDisconnected(string connectionString)
        {
            Connection = new SQLiteConnection(connectionString);

            // create the data adapter
            DataAdapter = new SQLiteDataAdapter(DBQueryString, Connection);

            // populate the dataset
            DBDataSet = new DataSet();
            DataAdapter.Fill(DBDataSet);

            // give names to tables
            DBDataSet.Tables[0].TableName = "Student";
            DBDataSet.Tables[1].TableName = "Subject";
            DBDataSet.Tables[2].TableName = "Enrollment";
        }

        public List<Student> StudentReadAll()
        {
            var students = new List<Student>();
            foreach (DataRow row in DBDataSet.Tables["Student"].Rows)
            {
                var id = row["StudentID"].ToString();
                var name = row["FirstName"].ToString();
                students.Add(new Student(id, name));
            }
            return students;
        }

        public void StudentCreate(Student student)
        {
            var studentTable = DBDataSet.Tables["Student"];
            DataRow row = studentTable.NewRow();
            row["StudentID"] = student.Id;
            row["FirstName"] = student.FirstName;
            studentTable.Rows.Add(row);
            new SQLiteCommandBuilder(DataAdapter);
            DataAdapter.Update(studentTable);
            DBDataSet.AcceptChanges();
        }

        public void StudentDelete(string id)
        {
            var studentTable = DBDataSet.Tables["Student"];
            foreach (DataRow row in studentTable.Rows)
            {
                if (String.Equals(row["StudentID"].ToString(), id))
                {
                    row.Delete();
                    new SQLiteCommandBuilder(DataAdapter);
                    DataAdapter.Update(studentTable);
                    DBDataSet.AcceptChanges();
                    break;
                }
            }
        }

        public void StudentUpdate(Student student)
        {
            var studentTable = DBDataSet.Tables["Student"];
            foreach (DataRow row in studentTable.Rows)
            {
                if (String.Equals(row["StudentID"].ToString(), student.Id))
                {
                    // update
                    row["FirstName"] = student.FirstName + " " + student.LastName;
                    new SQLiteCommandBuilder(DataAdapter);
                    DataAdapter.Update(studentTable);
                    DBDataSet.AcceptChanges();
                    break;


                }


            }

        }
        //public void StudentBatchOperation()
        //{
        //    var studentTable = DBDataSet.Tables["Student"];

        //    Console.WriteLine("Add a student - St007");
        //    // create a row object
        //    DataRow row1 = studentTable.NewRow();
        //    // set the values for the new row
        //    row1["StudentID"] = "St007";
        //    row1["FirstName"] = "Batch 1";
        //    // add the new row in student table
        //    studentTable.Rows.Add(row1);

        //    Console.WriteLine("Add another student - St1000");
        //    DataRow row2 = studentTable.NewRow();
        //    // set the values for the new row
        //    row2["StudentID"] = "St008";
        //    row2["Name"] = "Batch 2";
        //    // add thow e new rin student table
        //    studentTable.Rows.Add(row2);

        //    Console.WriteLine("Update a student - St006");
        //    foreach (DataRow row in studentTable.Rows)
        //    {
        //        if (String.Equals(row["StudentID"].ToString(), "St006"))
        //        {
        //            // update the row
        //            row["FirstName"] = "name updated";
        //            break;
        //        }
        //    }

        //    Console.WriteLine("Delete a student - St4000");
        //    foreach (DataRow row in studentTable.Rows)
        //    {
        //        if (String.Equals(row["StudentID"].ToString(), "St0010"))
        //        {
        //            // update the row
        //            row.Delete();
        //            break;
        //        }
        //    }
        }

    }
}
