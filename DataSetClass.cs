using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using MySql.Data.MySqlClient;
using Dapper;

namespace Capstone_Project
{
    class DataSetClass
    {
        //method for connecting to database from Youtuber IAmTimCorey  
        public static List<Table> ConnectToData(string connType, int id)
        {
            var list = new List<Table>();
            if (connType == "Simple Exhibition")
            {
                using (DbConnection connection = new MySqlConnection(Helper.connString("MyDB")))
                {
                    list.AddRange(connection.Query<Exhibition>("mydb.GetSimpleExhibition(@ID)", new { ID = id}).ToList());
                    return list;
                }
            }
            else
            {
                return list;
            }
        }

        public static List<Table> ConnectToData(string connType)
        {
            var list = new List<Table>();
            if (connType == "Full Exhibition")
            {
                using (DbConnection connection = new MySqlConnection(Helper.connString("MyDB")))
                {
                    list.AddRange(connection.Query<Exhibition>("mydb.GetFullExhibition").ToList());
                    return list;
                }
            }
            else if (connType == "All Artwork")
            {
                using (DbConnection connection = new MySqlConnection(Helper.connString("MyDB")))
                {
                    list.AddRange(connection.Query<Artwork>("mydb.GetAllArtwork").ToList());
                    return list;
                }
            }
            else
            {
                return list;
            }
        }

        public static void UpdateTable()
        {
            throw new NotImplementedException();
        }

        public static void DeleteRecord()
        {
            throw new NotImplementedException();
        }
    }
}
