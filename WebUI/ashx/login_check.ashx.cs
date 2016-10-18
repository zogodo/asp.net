using System.Web;
using System.Web.SessionState;

namespace NewWebUI.ashx
{
    /// <summary>
    /// login_check 的摘要说明
    /// </summary>
    public class login_check : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            object user = context.Session["admin"];
            if (user == null)
            {
                context.Response.Write("NO");
                return;
            }
            context.Response.Write(user.ToString());
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