using System.Web;
using System.Web.SessionState;
using WebUI.MyClass;

namespace NewWebUI.ashx
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            string username = context.Request["username"];
            string password = context.Request["password"];
            string verify_code = context.Request["code"];

            User user = new User(username);

            //验证码
            object code_id = context.Session["code_id"];
            if (code_id == null || verify_code.ToLower() != user.GetVerifyCode(int.Parse(code_id.ToString())).ToLower())
            {
                context.Session["code_id"] = null;
                context.Response.Write("no_verify");
                return;
            }


            if (user.Login(password) == 0)
            {
                context.Session["admin"] = user.UserName;
                context.Response.Write("OK");
            }
            else
            {
                context.Session["code_id"] = null;
                context.Response.Write("NO");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}