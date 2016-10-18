using System;
using System.Data;
using System.Data.SqlClient;

namespace WebUI.MyClass
{
    public class User
    {
        public  string UserName {get; set;}
        public  string Password {get; set;}
        public  int RoleID {get; set;}
        public  DateTime LastActivityDate {get; set;}

        public User(string username) //构造函数
        {
            DataTable all_info = SqlHelper.ExecuteDataTable(
                "select * from v_Users where UserName=@UserName",
                new SqlParameter("@UserName", username)
                );
            if (all_info.Rows.Count == 0)
            {
                return;
            }
            this.UserName = all_info.Rows[0]["UserName"].ToString();
            this.Password = all_info.Rows[0]["Password"].ToString();
            this.RoleID = int.Parse(all_info.Rows[0]["RoleID"].ToString());
        }

        public int Login(string password) //登陆
        {
            if (this == null)
            {
                return 1;
            }
            if (password == this.Password)
            {
                this.LastActivityDate = DateTime.Now;
                SqlHelper.ExecuteNonQuery("update Users set LastActivityDate = GETDATE() where UserName=@UserName",
                    new SqlParameter("@UserName", this.UserName)
                    );
                return 0;
            }
            return 2;
        }

        public string GetVerifyCode(int id)
        {
            return VerifyCode.GetCodeByID(id);
        }


        public int UpdatePassword(string UserName, string Password)
        {
            return 0;
        }

    }
}
