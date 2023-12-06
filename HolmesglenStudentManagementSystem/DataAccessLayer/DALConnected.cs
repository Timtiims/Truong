using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class DALConnected
    {
        private SQLiteConnection Connection;
        public DALConnected(string connectionString)
        {
            Connection = new SQLiteConnection(connectionString);
        }

        public List<Student> StudentReadAll()
        {
            var students = new List<Student>();
            Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Student";

            var reader = command.ExecuteReader();

            while (reader.Read()) 
            {
                var studentId = reader.GetString(0);
                var studentName = reader.GetString(1);
                students.Add(new Student(studentId, studentName));
            }
            Connection.Close();

            return students;
        }

    }

}


