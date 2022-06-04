using System.Configuration;

namespace Capstone_Project
{
    public static class Helper
    {
        public static string ConnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
