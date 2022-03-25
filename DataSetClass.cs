//using System.Data;
//using System.Data.SqlClient;
//using System.Text;
//using MySql.Data.MySqlClient;

//namespace Capstone_Project
//{
//    class DataSetClass
//    {
//        static void DataSetClass()
//        {
//            string connString = "server=localhost;user id=root;database=mydb;persistsecurityinfo=True";
//            ConnectToData(connString);
//        }
//        private static void ConnectToData(string connString)
//        {
//            using MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
//            MySqlDataAdapter artAdapt = new MySqlDataAdapter();
//            MySqlDataAdapter photoAdapt = new MySqlDataAdapter();
//            MySqlDataAdapter exhibitionAdapt = new MySqlDataAdapter();
//            MySqlDataAdapter interfaceAdapt = new MySqlDataAdapter();
//            artAdapt.TableMappings.Add("Table", "artwork");
//            photoAdapt.TableMappings.Add("Table", "photos");
//            exhibitionAdapt.TableMappings.Add("Table", "ehibition");
//            interfaceAdapt.TableMappings.Add("Table", "exhibition interface");

//            conn.Open();

//        }
//    }
//}
