using HolmesglenStudentManagementSystem.PresentationLayer;
using HolmesglenStudentManagementSystem.DataAccessLayer;
using System;
using HolmesglenStudentManagementSystem.PresentationLayer.StudentPL;
using HolmesglenStudentManagementSystem.PresentationLayer.SubjectPL;
using HolmesglenStudentManagementSystem.PresentationLayer.EnrollmentPL;
using HolmesglenStudentManagementSystem.Models;
using System.IO;
using Microsoft.Data.Sqlite;
using CsvHelper;
using System.ComponentModel.DataAnnotations;

namespace HolmesglenStudentManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string csvFilePath = @"C:\Users\banhb\Downloads\data-driven-at2-code\student.csv";

            string connectionString = @"Data Source=C:\Users\banhb\Desktop\HolmesglenInstitude.db";
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var reader = new StreamReader(csvFilePath))
                using ( var csv = new CsvReader(reader, CultureInfo.InvarianCulture))
                {
                    var records = csv.GetRecord<Student>();
                    foreach ( var record in records)
                    {
                        var insertCommand = connection.CreateCommand();
                        insertCommand.CommandText = @"INSERT INTO student (Id, FirstName, LastName, Email)
                          VALUE($StudentID, $FirstName, $LastName, $Email";

                        insertCommand.Parameters.AddWithValue("$StudentID", record.Id);
                        insertCommand.Parameters.AddWithValue("$FirstName", record.FirstName);
                        insertCommand.Parameters.AddWithValue("$LastName", record.LastName);
                        insertCommand.Parameters.AddWithValue("$Email", record.Email); 

                        insertCommand.ExecuteNonQuery();



                    }

                }
                connection.Close();

            }

            Console.WriteLine("data have loaded from csv file to databased");

            // saving into csv file

            string csvFilePath2 = @"C:\Users\banhb\Downloads\CSV2.csv";
            using ( var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var selectCommand = connection.CreateCommand();
                selectCommand.CommandText = " SELECT * FROM Student ";
                using ( var reader = selectCommand.ExecuteReader())
                using ( var csvWriter = new CsvWriter(new StreamWriter(csvFilePath2), CultureInfo.InvarianCulture)) 
                {
                    // write csv header 
                    csvWriter.WriteHeader<Student>();
                    csvWriter.NextRecord();

                    // write data to csv 
                    while (reader.Read())
                    {
                        var record = new Student();
                        {
                            StudentID = reader["StudentID"].ToString();
                            FirstName = reader["FirstName"].ToString();
                            LastName = reader["LastName"].ToString();
                            Email = reader["Email"].ToString();
                        };
                        csvWriter.WriteRecord(record);
                        csvWriter.NextRecord();
                    }
                }
                connection.Close();
            }

            Console.WriteLine("data saved from SQLite to csv file. ");


            //exportcsv
            //var connection = new SqliteConnection(connectionString);
            //connection.Open();
            //StudentDAL studentDAL = new StudentDAL(connection);
            //string csvFilePath = @"C:\Users\banhb\Downloads\data-driven-at2-code\student.csv";
            //studentDAL.ExportCSV(csvFilePath);
            //connection.Close();


            ////importcsv
            //studentDAL.ImportToCSV(csvFilePath);

            //var dalDisconnected = new DALDisconnected(connectionString);
            //dalDisconnected.StudentDelete("St001");


            // delete using disconnected mode
            //Console.WriteLine("Before deletion");
            //foreach ( var student in dalDisconnected.StudentReadAll () )
            //{
            //    Console.WriteLine($"{student.Id}- {student.FirstName)");
            //}
            //Console.WriteLine("\ndeleting student -St001");
            //dalDisconnected.StudentDelete("St001");
            //Console.WriteLine("After delete");
            //foreach ( var student in dalDisconnected .StudentReadAll () ) 
            //{
            //    Console.WriteLine($"{student.Id} - {student.FirstName}");
            //}


            //create new  student using disconneted
            //var s = new Student("St009", "random");
            //dalDisconnected.StudentCreate(s);
            //Console.WriteLine("Reading all studnets using disconnected mode");
            //foreach  (var student in dalDisconnected.StudentReadAll()) 
            //{
            //    Console.WriteLine($"{student.Id} = {student.FirstName}");
            //}

            //Console.WriteLine("reading all students using disconnected mode");
            //foreach (var student in dalDisconnected.StudentReadAll())
            //{
            //    Console.WriteLine($"{student.Id} - {student.FirstName}");
            //}









            //(new GetAllStudents()).Run();
            //(new GetOneStudent()).Run();
            //(new CreateStudent()).Run();
            //(new UpdateStudent()).Run();
            //(new DeleteStudent()).Run();


            //(new GetAllSubject()).Run();
            //// uncomment the code below for testing
            //(new GetOneSubject()).Run();
            //(new CreateSubject()).Run();
            //(new UpdateSubject()).Run();
            //(new DeleteSubject()).Run();

            //(new GetAllEnrollment()).Run();
            //(new GetOneEnrollment()).Run();
            //(new CreateEnrollment()).Run();
            //(new UpdateEnrollment()).Run();
            //(new DeleteEnrollment()).Run();

            // export csv
            //string csvFilePath = @"C:\Users\banhb\Downloads\data-driven-at2-code\student_export.csv";


            //StudentDAL studentDAL = new StudentDAL(/* your SQLite connection */);
            //studentDAL.ExportStudentsToCSV(csvFilePath);


        }
    }

}
