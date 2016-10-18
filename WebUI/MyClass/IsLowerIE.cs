using System.Web;

namespace WebUI.MyClass
{
    public class IsLowerIE
    {
        public static bool IsLowerIE10()
        {
            string curBrowser = HttpContext.Current.Request.Browser.Type.ToLower();

            if (curBrowser.IndexOf("ie") == 0)
            {
                if (curBrowser.IndexOf("ie10") == 0)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}