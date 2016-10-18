using System;
using System.Web;
using WebUI.MyClass;

namespace WebUI.web
{
    public partial class message : System.Web.UI.Page
    {
        public string brow = "IE";
        protected void Page_Load(object sender, EventArgs e)
        {
            brow = HttpContext.Current.Request.Browser.Type.ToLower();

            if (!IsLowerIE.IsLowerIE10())
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}