using System.Web;
using System.Web.SessionState;

namespace NewWebUI.ashx
{
    /// <summary>
    /// logout 的摘要说明
    /// </summary>
    public class logout : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            context.Session["admin"] = null;
            context.Response.Redirect("../web/login.aspx");
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