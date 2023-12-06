using Microsoft.Data.Sqlite;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class EnrollmentDAL
    {
        private SqliteConnection Connection;

        public EnrollmentDAL(SqliteConnection connection)
        {
            // connect to the target database
            Connection = connection;
        }

        // Create
        public void Create(Enrollment enrollment)
        {
            Connection.Open();
            var command = Connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Enrollment
                ( StudentID_FK, SubjectID_FK)
                VALUES(@b, @c)
            ";

           // command.Parameters.AddWithValue("a", enrollment.EnrollmentID);
            command.Parameters.AddWithValue("b", enrollment.StudentID_FK);
            command.Parameters.AddWithValue("c", enrollment.SubjectID_FK);

            // execute the query
            command.ExecuteNonQuery();

            Connection.Close();
        }

        // Read
        public Enrollment Read(string id)
        {
            Enrollment enrollment = null;

            Connection.Open();
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT EnrollmentID, StudentID_FK, SubjectID_FK
                FROM Enrollment
                WHERE EnrollmentID = @a
            ";
            command.Parameters.AddWithValue("a", id);

            // execute the query
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var enrollmentID = reader.GetString(0);
                var studentID_FK = reader.GetString(1);
                var subjectID_FK = reader.GetString(2);
                enrollment = new Enrollment(enrollmentID, studentID_FK, subjectID_FK);
            }

            Connection.Close();

            return enrollment;
        }

        // Read All
        public List<Enrollment> ReadAll()
        {
            var enrollments = new List<Enrollment>();

            Connection.Open();
            var command = Connection.CreateCommand();
            command.CommandText = @"SELECT EnrollmentID, StudentID_FK, SubjectID_FK FROM Enrollment";

            // execute the query
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var enrollmentID = reader.GetString(0);
                var studentID_FK = reader.GetString(1);
                var subjectID_FK = reader.GetString(2);
                enrollments.Add(new Enrollment(enrollmentID, studentID_FK, subjectID_FK));
            }

            Connection.Close();

            return enrollments;
        }

        // Update
        public void Update(Enrollment enrollment)
        {
            Connection.Open();
            var command = Connection.CreateCommand();
            command.CommandText = @"
                UPDATE Enrollment
                SET StudentID_FK = @a,
                    SubjectID_FK = @b
                WHERE EnrollmentID = @c
            ";
            command.Parameters.AddWithValue("a", enrollment.StudentID_FK);
            command.Parameters.AddWithValue("b", enrollment.SubjectID_FK);
            command.Parameters.AddWithValue("c", enrollment.EnrollmentID);

            // execute the query
            command.ExecuteNonQuery();

            Connection.Close();
        }

        // Delete
        public void Delete(string id)
        {
            Connection.Open();
            var command = Connection.CreateCommand();
            command.CommandText = @"
                DELETE FROM Enrollment
                WHERE EnrollmentID = @a
            ";
            command.Parameters.AddWithValue("a", id);

            // execute the query
            command.ExecuteNonQuery();

            Connection.Close();
        }
    }
}