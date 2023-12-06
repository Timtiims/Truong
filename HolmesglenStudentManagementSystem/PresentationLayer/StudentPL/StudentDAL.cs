using Microsoft.Data.Sqlite;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Data.Entity.Core.Common;
using System.Security.Cryptography.X509Certificates;
using System.CodeDom.Compiler;


namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class StudentDAL
    {
        private SqliteConnection Connection;

        public StudentDAL(SqliteConnection connection)
        {
            // connect to the target database
            Connection = connection;
        }
        // create
        public void Create(Student student)
        {
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Student
                (StudentID, FirstName, LastName, Email)
                VALUES(@a, @b, @c, @d)
            ";

            command.Parameters.AddWithValue("a", student.Id);
            command.Parameters.AddWithValue("b", student.FirstName);
            command.Parameters.AddWithValue("c", student.LastName);
            command.Parameters.AddWithValue("d", student.Email);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }

        public Student Read(string id)
        {
            Student student = null;
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT StudentID, FirstName, LastName, Email
                FROM Student
                WHERE StudentId = @a
            ";
            command.Parameters.AddWithValue("a", id);


            // execute the query
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var studentId = reader.GetString(0);
                var studentFName = reader.GetString(1);
                var studentLName = reader.GetString(2);
                var studentEmail = reader.GetString(3);
                student = new Student(studentId, studentFName, studentLName, studentEmail);
            } // else student = null

            Connection.Close();

            return student;
        }

        // read all
        public List<Student> ReadAll()
        {
            var students = new List<Student>();

            Connection.Open();

            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT StudentID, FirstName, LastName, Email
                FROM Student
            ";

            // execute the query
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var studentId = reader.GetString(0);
                var studentFName = reader.GetString(1);
                var studentLName = reader.GetString(2);
                var studentEmail = reader.GetString(3);
                students.Add(new Student(studentId, studentFName, studentLName, studentEmail));
            }
            Connection.Close();
            return students;
        }

        public void Update(Student student)
        {
            // challenge yourself
            Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = @"
                UPDATE Student
                SET FirstName = @a,
                    LastName = @b,
                    Email = @c
                WHERE StudentID = @d
            ";
            command.Parameters.AddWithValue("a", student.FirstName);
            command.Parameters.AddWithValue("b", student.LastName);
            command.Parameters.AddWithValue("c", student.Email);
            command.Parameters.AddWithValue("d", student.Id);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }

        public void Delete(string id)
        {
            // challenge yourself
            Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = @"
                DELETE FROM Student
                WHERE StudentID = @a
            ";
            command.Parameters.AddWithValue("a", id);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }

        

       

        public void ExportCSV(string csvFilePath)
        {
            
            List<Student> students = ReadAll();

            
            using (var writer = new StreamWriter(csvFilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                
                csv.WriteRecords(students);
            }

            Console.WriteLine("Export successful");
        }


        public void ImportToCSV(string filePath)
        {
            Connection.Open();

            
            var students = ReadAll();

            
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                
                csv.WriteField("StudentID");
                csv.WriteField("First Name");
                csv.WriteField("Last Name");
                csv.NextRecord();

                
                foreach (var student in students)
                {
                    csv.WriteField(student.Id);
                    csv.WriteField(student.FirstName);
                    csv.WriteField(student.LastName);
                    csv.NextRecord();
                }

                
                
            }

            Connection.Close();
        }

        //public List<StudentSubject>();
        //{
        //    var result = new List<StudentSubject>();
        //    Connection.Open();

        //    var command = Connection.CreateCommand();
        //    command.CommandText = @"SELECT StudentID, FirstName, SubjectID, Title 
        //     FROM Enrollment
        //     INNER JOIN Student ON Student.StudentID = Enrollment.StudentID_FK
        //     INNER JOIN Subject ON Subject.SubjectID = Enrollment.SubjectID_FK";

        //    var reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //    var studentId = reader.GetString(0);
        //    var studentName = reader.GetString(1);
        //    var subjectId = reader.GetString(2);
        //    var subjectTitle = reader.GetString(3);
        //    result.Add( NewsStyleUriParser StudentSubject(studentId.studentName, subjectId, subjectTitle));
        //    }
        //    Connection.Close();
        //    return results;





    }


}  
    

