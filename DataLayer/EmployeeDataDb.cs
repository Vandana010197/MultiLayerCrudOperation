using CommonAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataLayer
{
     public class EmployeeDataDb
    {
        private DbConnection db = new DbConnection();
        public List<Employees> GetEmployees()
        {
            string query = "select* from Employees";
            SqlCommand command = new SqlCommand();
            command.Connection = db.Cnn;
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            if (db.Cnn.State == System.Data.ConnectionState.Closed)
            {
                db.Cnn.Open();

            }
                SqlDataReader reader = command.ExecuteReader();
                List<Employees> employees = new List<Employees>();
                while (reader.Read())
                {
                    Employees emp = new Employees();
                    emp.Id = (int)reader["Id"];
                    emp.Name = reader["Name"].ToString();
                    emp.Email = reader["Email"].ToString();
                    emp.Contact = reader["Contact"].ToString();
                    emp.Address = reader["Address"].ToString();

                    employees.Add(emp);
                }
                db.Cnn.Close();
                
            
            return employees;
        }

        public Employees GetEmployeeById(int id)
        {
            string query = "select* from Employees where Id="+id+"";
            SqlCommand command = new SqlCommand();
            
            command.CommandText = query;
            command.Connection = db.Cnn;

            if (db.Cnn.State == System.Data.ConnectionState.Closed)
            
                db.Cnn.Open();
            
            SqlDataReader reader = command.ExecuteReader();

            reader.Read();
            
                Employees emp = new Employees();
                emp.Id = (int)reader["Id"];
                emp.Name = reader["Name"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.Contact = reader["Contact"].ToString();
                emp.Address = reader["Address"].ToString();

            db.Cnn.Close();
            return emp;
        }


        public bool CreateEmployee(Employees employee)
        {
            string query = "insert into Employees values('" + employee.Name + "','" + employee.Email + "','" +
                employee.Contact + "','" + employee.Address + "')";
            SqlCommand cmd = new SqlCommand(query, db.Cnn);
            db.Cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.Cnn.Close();
            return Convert.ToBoolean(i);
        }

        public bool DeleteEmployee(int id)
        {
            string query = "delete from Employees where id="+id+"";
            SqlCommand cmd = new SqlCommand(query, db.Cnn);
            if(db.Cnn.State==System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.Cnn.Close();
            return Convert.ToBoolean(i);
        }

        public bool UpdateEmployee(Employees employee)
        {
            string query = "update Employees set Name="+employee.Name+ ",Email="+employee.Email+
                ",Contact="+employee.Contact+",Address="+employee.Address+"where Id="+employee.Id+"";
            SqlCommand cmd = new SqlCommand(query, db.Cnn);
            if(db.Cnn.State==System.Data.ConnectionState.Closed)
            db.Cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.Cnn.Close();
            return Convert.ToBoolean(i);
        }

    }
}
