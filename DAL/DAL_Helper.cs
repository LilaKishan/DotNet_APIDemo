    namespace APIDemo.DAL
{
    public class DAL_Helper
    {
        #region Connection_String
        public static string connstr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("myConnectionString");
        #endregion
    }
}
