using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BAL
{
    public class AccountBAL
    {
        AccountDAL dal = new AccountDAL();
        // kiem tra user co dung format ko 
        public bool CheckAcount(string user, string pwd)
        {

            bool kq = false;

             if(dal.CheckAccount(user,pwd))
            {
                kq = true;             
            }
            return kq;            
        }       
        public AccountDTO GetDetailAccount(string user, string pwd)
        {
            //kiem tra su ton tai cua acc truoc khi GetDetail
            //CheckAcount(user, pwd);
            AccountDTO account = dal.GetDetailAccount(user,pwd);
            return account;
        }
        public bool CheckAcountDK(string user)
        {

            bool kq = false;

            if (dal.CheckAccountDK(user))
            {
                kq = true;
            }
            return kq;
        }
        public bool WriteAccoutDK(string user, string pwd, string em)
        {
            bool kq = false;
            if (dal.WriteAccoutDK(user, pwd, em))
            {
                kq = true;
            }
            return kq;
        }
        public bool CheckAccoutEmail(string em)
        {
            bool kq = false;

            if (dal.CheckAccoutemail(em))
            {
                kq = true;
            }
            return kq;
        }
        public AccountDTO GetdetaiAccoutEmail(string em)
        {
            AccountDTO account = dal.GetDetailAccountEmail(em);
            return account;

        }        
        public bool UpdateScore(string user,int score)
        {
            bool kq = false;
            if (dal.UpdateScore(user,score))
            {
                kq = true;
            }
            return kq;
        }
        public List<AccountDTO> listuser()
        {
            List<AccountDTO> list = dal.Getlistusers();
            return list;
        }

    }
}
