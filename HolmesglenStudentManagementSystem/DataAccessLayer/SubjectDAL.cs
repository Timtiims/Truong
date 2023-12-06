using Microsoft.Data.Sqlite;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class SubjectDAL
    {        
        private SqliteConnection Connection;

        public SubjectDAL(SqliteConnection connection)
        {
            // connect to the target database
            Connection = connection;
        }
        // create
        public void Create(Subject subject)
        {
            Connection.Open();
            var command1 = Connection.CreateCommand();
            command1.CommandText = @"
                 INSERT INTO Subject
                 (SubjectID,Title) 
                   VALUE(@a, @b)";

            command1.Parameters.AddWithValue("a", subject.SubjectId);
            command1.Parameters.AddWithValue("b", subject.Title);

            // excute the query
            command1.ExecuteReader();

            Connection.Close();
        }

        public Subject Read(string id)
        {
            Subject subject = null;

            Connection.Open();
            // build the query command 
            var command1 = Connection.CreateCommand();
            command1.CommandText = @"
              SELECT SubjectID,Title FROM Subject WHERE SubjectID = @a";

            command1.Parameters.AddWithValue("a", id);

            // excute the query

            var reader1 = command1.ExecuteReader();
            if (reader1.Read())
            {
                var subjectId = reader1.GetString(0);
                var title = reader1.GetString(1);
                subject = new Subject(subjectId, title);
            }
            else subject = null;


            Connection.Close();

            return subject;
        }

        // read all
        public List<Subject> ReadAll()
        {
            var subjects = new List<Subject>();

            Connection.Open();

            // build the query

            var command1 = Connection.CreateCommand();
            command1.CommandText = @"SELECT SubjectID, Title FROM Subject";

            //excute the query 
            var reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                var subjectId = reader1.GetString(0);
                var title = reader1.GetString(1);
                subjects.Add(new Subject(subjectId, title));
            }
            Connection.Close();


            return subjects;
        }

        public void Update(Subject subject)
        {
            Connection.Open();

            var command1 = Connection.CreateCommand();
            command1.CommandText = @"UPDATE Subject SET Title = @a WHERE SubjectID = @b";
            command1.Parameters.AddWithValue("a", subject.Title);
            command1.Parameters.AddWithValue("b", subject.SubjectId);

            // excute the reader
            command1.ExecuteReader();
            Connection.Close();
        }

        public void Delete(string id)
        {
            Connection.Open();
            var command1 = Connection.CreateCommand();
            command1.CommandText = @"DELETE FROM Subject WHERE SubjectID = @a";
            command1.Parameters.AddWithValue("a", id);

            //excute the query 
            command1.ExecuteReader();

            Connection.Close();
        }
    }
}
