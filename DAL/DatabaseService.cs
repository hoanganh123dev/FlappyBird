using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseService
    {
        public string connectionString = "Data Source=DESKTOP-0OLBBM5\\SQLEXPRESS;Initial Catalog=Brid;Integrated Security=True";
        public SqlConnection connection;
        public SqlCommand command;

        public DatabaseService()
        {
            connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if(connection !=null && connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void CloseConnection()
        {
            if(connection!=null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public SqlDataReader ReadData(string sql)
        {
            command = new SqlCommand();
            command.CommandType= System.Data.CommandType.Text;
            command.CommandText= sql;
            command.Connection = connection;
            OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public SqlDataReader ReadDataPars(string sql, SqlParameter[] pars)
        {

            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sql;
            command.Connection = connection;
            OpenConnection();
            command.Parameters.AddRange(pars);
            SqlDataReader reader = command.ExecuteReader();//dung de thuc thi cac truy van select thong thuong
            return reader;
        }
        public bool WriteData(string sql, SqlParameter[] pars)
        {
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sql;
            command.Connection = connection;
            OpenConnection();
            command.Parameters.AddRange(pars);
            int kq = command.ExecuteNonQuery();//dung de thuc thi cac truy van khong tra ve du lieu (insert,update,delete)
            return kq > 0;

        }
    }

   
}
