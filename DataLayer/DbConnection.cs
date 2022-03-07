using System;
using CommonAccessLayer.Model;
using Microsoft.Data.SqlClient;

namespace DataLayer
{
    public class DbConnection
    {
        public SqlConnection Cnn;
        public DbConnection()
        {
            Cnn = new SqlConnection(Connection.ConnectionStr);
        }
    }
}
