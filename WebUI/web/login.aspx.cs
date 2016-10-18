using System;
using System.Web;
using WebUI.MyClass;

namespace WebUI.web
{
    public partial class login : System.Web.UI.Page
    {
        public string bro = "A";

        protected void Page_Load(object sender, EventArgs e)
        {
            bro = HttpContext.Current.Request.Browser.Type.ToLower();

            if (IsLowerIE.IsLowerIE10())
            {
                Response.Redirect("message.aspx");
            }
        }
    }
}