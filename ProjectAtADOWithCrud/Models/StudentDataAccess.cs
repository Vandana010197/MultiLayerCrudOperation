using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ProjectAtADOWithCrud.Models
{
    public class StudentDataAccess
    {
        DbConnection DBConnection;
        public StudentDataAccess()
        {
            DBConnection = new DbConnection();
        }
        public List<StudentCourse> GetStudentCourse()
        {
            string Sp = "Sp_StudentCourses";
            SqlCommand sql = new SqlCommand(Sp, DBConnection.Connection);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@action", "SELECT_JOIN");
            if (DBConnection.Connection.State == ConnectionState.Closed)
            {
                DBConnection.Connection.Open();
            }
            SqlDataReader dr = sql.ExecuteReader();
            List<StudentCourse> studs = new List<StudentCourse>();
            while (dr.Read())
            {
                StudentCourse Studs = new StudentCourse();
                Studs.Id = (int)dr["Id"];
                Studs.StudName = dr["StudName"].ToString();
                Studs.Email = dr["Email"].ToString();
                Studs.Contact = dr["Contact"].ToString();
                Studs.Course = dr["Course"].ToString();
                studs.Add(Studs);

            }
            DBConnection.Connection.Close();
            return studs;
        }

    }
}
