using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class AppDAL
    {
        public SqliteConnection Connection;
        public StudentDAL StudentDALInstance;
        public SubjectDAL SubjectDALInstance;
        public EnrollmentDAL EnrollmentDALInstance;
        public DALDisconnected DALDisconnectedInstance;

        // private constructor
        public AppDAL() {
            // create the ADO.net sqlite connection
            Connection = new SqliteConnection(HolmesglenDB.ConnectionString);

            // create all DAL instances
            StudentDALInstance = new StudentDAL(Connection);
            SubjectDALInstance = new SubjectDAL(Connection);
            EnrollmentDALInstance = new EnrollmentDAL(Connection);
            DALDisconnectedInstance = new DALDisconnected(Connection);
            // student todo:
            // implement the EnrollmentDAL class and create a instance here 
            // finalise the connection mode for all tables. 
        }
    }
    // sigular pattern
//    sealed public class appdal
//    {
//        private static appdal dalinstance = null;

//        public sqliteconnection connection;
//        public studentdal studentdalinstance;
//        public subjectdal subjectdalinstance;
//        public enrollmentdal enrollmentdalinstance;

//        // private constructor
//        private appdal() { }
//        public static appdal instance()
//        {
//            if (dalinstance == null)
//            {
//                dalinstance = new appdal();
//                dalinstance.init();
//            }
//            return dalinstance;
//        }

//        private void init()
//        {
//            // create the ado.net sqlite connection
//            connection = new sqliteconnection(holmesglendb.connectionstring);

//            // create all dal instances
//            studentdalinstance = new studentdal(connection);
//            subjectdalinstance = new subjectdal(connection);
//            enrollmentdalinstance = new enrollmentdal(connection);
//        }
//    }

}
