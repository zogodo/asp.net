using System.Data.SqlClient;

namespace WebUI.MyClass
{
    public static class VerifyCode
    {
        public static int InsertCode(string code)
        {
            object id = SqlHelper.ExecuteScalar(
                "insert into verify_code (code) values(@code) select @@identity",
                new SqlParameter("@code", code)
                );
            return int.Parse(id.ToString());
        }

        public static string GetCodeByID(int id)
        {
            object code = SqlHelper.ExecuteScalar(
                "select code from verify_code where id=@id",
                new SqlParameter("@id", id)
                );
            return code.ToString();
        }
    }
}
