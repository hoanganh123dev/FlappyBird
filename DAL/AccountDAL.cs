using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDAL : DatabaseService

    {
        AccountDTO account= new AccountDTO();
        // kiểm tra user có trong database
        public bool CheckAccount(string user,string pass)//kiem tra co username voi password trong database khong
        {
            bool kq = false;
            try
            {
                string sql = "Select * From Account Where UserName=@UserName and UserPassWord=@UserPassWord";
                SqlParameter parUser = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
                parUser.Value = user;
                SqlParameter parPass = new SqlParameter("@UserPassWord", System.Data.SqlDbType.VarChar);
                parPass.Value = pass;               
                SqlDataReader reader = ReadDataPars(sql, new[] { parUser,parPass }) ;
                if (reader.Read())
                {
                    kq = true;//kiem tra thanh cong
                }

            }
            finally
            {
                CloseConnection();
            }
            return kq;
        }
        
        public AccountDTO GetDetailAccount(string user, string pwd)//lay du lieu trong database
        {
            try
            {
                string sql = "Select * From Account Where UserName=@UserName and UserPassWord=@UserPassWord";
                SqlParameter parUser = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);//sua dung tham so truy van
                parUser.Value = user;
                SqlParameter parPass = new SqlParameter("@UserPassWord", System.Data.SqlDbType.VarChar);
                parPass.Value = pwd;               
                SqlDataReader reader = ReadDataPars(sql, new[] { parUser, parPass });
                if(reader.Read())//truyen doi tuong vao de doc
                {
                    account.AccoutID = reader.GetInt32(0);
                    account.UserName = reader.GetString(1);
                    account.UserPassWord = reader.GetString(2);                 
                    
                }
            }
            finally
            {
                CloseConnection();
            }
            return account; 
        }
        public bool CheckAccountDK(string user) // kiem tra username co trong database hay ko 
        {
            bool kq = false;
            try
            {
                string sql = "select UserName , Email from Account where UserName=@UserName";
                SqlParameter parUser = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar); 
                parUser.Value = user;                               
                SqlDataReader reader = ReadDataPars(sql, new[] { parUser });
                if (reader.Read())
                {
                    kq = true;//kiem tra thanh cong
                }
            }
            finally
            {
                CloseConnection();
            }
            return kq;
        }
        public bool WriteAccoutDK(string user, string pwd, string em)//them tai khoan vao database
        {
            bool kq = false;
            try
            {
                string sql = "Insert into Account (UserName,UserPassWord,Email ) values (@UserName,@UserPassWord,@Email)";
                SqlParameter parUser = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
                parUser.Value = user;
                SqlParameter parPass = new SqlParameter("@UserPassWord", System.Data.SqlDbType.VarChar);
                parPass.Value = pwd;
                SqlParameter parEm = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                parEm.Value = em;
                bool write = WriteData(sql, new[] { parUser, parPass, parEm });
                if (write == true)
                {
                    kq = true;   // them tai khoan thanh thanh cong
                }
            }
            finally
            {
                CloseConnection();
            }
            return kq;
        }
        public bool CheckAccoutemail(string em)//kiem trong email co trong database hay khong
        {
            bool kq = false;
            try
            {
                string sql = "Select * From Account Where Email=@Email";
                SqlParameter parEmail = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                parEmail.Value = em;
                SqlDataReader reader = ReadDataPars(sql, new[] { parEmail });
                if (reader.Read())
                {
                    kq = true;
                }
            }
            finally
            {
                CloseConnection();
            }
            return kq;
        }
        public AccountDTO GetDetailAccountEmail(string em)//lay du lieu cua email
        {
            try
            {
                string sql = "Select * From Account Where Email=@Email";
                SqlParameter parEm = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                parEm.Value = em;
                SqlDataReader reader = ReadDataPars(sql, new[] { parEm });
                if (reader.Read())
                {
                    account.AccoutID = reader.GetInt32(0);               
                    account.UserPassWord = reader.GetString(1);//truyen doi tuong vao de goi                    
                }
            }
            finally
            {
                CloseConnection();
            }
            return account;
        }       
        public bool UpdateScore(string user,int score)//ham cap nhat lai database
        {
            bool kq = false;
            try
            {
                string sql = "Update Account Set Score=@Score where UserName=@UserName";
                SqlParameter parUser = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
                parUser.Value = user;
                SqlParameter parScore = new SqlParameter("@Score", System.Data.SqlDbType.Int);
                parScore.Value = score;
                bool write = WriteData(sql, new[] { parUser, parScore });//thuc thi cau truy van
                if (write == true)
                {
                    kq = true;//update thanh cong
                }
            }
            finally
            {
                CloseConnection();
            }
            return kq;
        }     
        public List<AccountDTO> Getlistusers()
        {
            List<AccountDTO> list = new List<AccountDTO>();
            try
            {
                string sql = "SELECT * FROM Account";
                SqlDataReader reader = ReadData(sql);
                while(reader.Read())
                {
                    AccountDTO account = new AccountDTO();
                    account.AccoutID = reader.GetInt32(0);
                    account.UserName = reader.GetString(1);
                    account.UserPassWord = reader.GetString(2);
                    account.Email = reader.GetString(3);
                    account.Score = reader.GetInt32(4);
                    
                    list.Add(account);
                }

            }
            finally
            {
                CloseConnection();
            }
            return list;
        }
    }
}
