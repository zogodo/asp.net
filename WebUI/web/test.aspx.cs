using System;

namespace WebUI.web
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usr = Request["usr"];
            if (usr != null)
            {
                Session["admin"] = usr;
            }
        }
    }
}