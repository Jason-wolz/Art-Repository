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
            if (connType == Program.simpleExhib)
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                list.AddRange(connection.Query<Exhibition>("mydb.GetExhibitionByArt(@ID)", new { ID = id }).ToList());
                return list;
            }
            else if (connType == Program.photos)
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                list.AddRange(connection.Query<Photos>("mydb.GetPhotosByArt(@ID)", new { ID = id }).ToList());
                return list;
            }
            else if (connType == Program.simpleArt)
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                list.AddRange(connection.Query<Artwork>("mydb.GetArtByExhibition(@ID)", new { ID = id }).ToList());
                return list;
            }
            else
            {
                return list;
            }
        }

        public static List<Table> ConnectToData(string connType)
        {
            var list = new List<Table>();
            if (connType == Program.allExhib)
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                list.AddRange(connection.Query<Exhibition>("mydb.GetFullExhibition").ToList());
                return list;
            }
            else if (connType == Program.allArt)
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                list.AddRange(connection.Query<Artwork>("mydb.GetAllArtwork").ToList());
                return list;
            }
            else
            {
                return list;
            }
        }

        public static List<Table> ConnectToData(DateTime lastYear)
        {
            using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
            var list = new List<Table>();
            list.AddRange(connection.Query<Artwork>("mydb.GetArtworkLastYear(@BeginDate)", new { BeginDate = lastYear }).ToList());
            return list;
        }

        public static List<Artwork> Search(DateTime date)
        {
            using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
            List<Artwork> list = connection.Query<Artwork>("mydb.GetArtByYear(@Year)", new { Year = date }).ToList();
            return list;
        }

        public static List<Artwork> Search(string type, string searchTerm)
        {
            List<Artwork> list = new List<Artwork>();
            if (type == Program.name)
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                list.AddRange(connection.Query<Artwork>("mydb.GetArtByName(@Name)", new { Name = searchTerm }).ToList());
                return list;
            }
            else if (type == Program.medium)
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                list.AddRange(connection.Query<Artwork>("mydb.GetArtByMedium(@Med)", new { Med = searchTerm }).ToList());
                return list;
            }
            else
            {
                return list;
            }
        }

        public static void UpdateTable(bool isNew, Artwork art)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Title", art.title);
            param.Add("@Medium", art.medium);
            param.Add("@Length", art.length);
            param.Add("@Width", art.width);
            param.Add("@Create_Date", art.createDate);
            param.Add("@Framed", art.isFramed);
            param.Add("@Edition", art.editionDetails);
            param.Add("@Sale", art.saleDetails);
            param.Add("@Notes", art.notes);
            if (isNew)
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                connection.Execute("mydb.AddNewArt", param, commandType: System.Data.CommandType.StoredProcedure);
            }
            else
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                param.Add("@Art_ID", art.artworkID);
                connection.Execute("mydb.UpdateArtwork", param, commandType: System.Data.CommandType.StoredProcedure);
            }            
        }

        public static void UpdateTable(bool isNew, Exhibition exhib)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Name", exhib.name);
            param.Add("@Address", exhib.address);
            param.Add("@City", exhib.city);
            param.Add("@State", exhib.state);
            param.Add("@Zip", exhib.zipCode);
            param.Add("@Country", exhib.country);
            param.Add("@Fee", exhib.applicationFee);
            param.Add("@Start", exhib.startDate);
            param.Add("@End", exhib.endDate);
            param.Add("@Juror", exhib.juror);
            if (isNew)
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                connection.Execute("mydb.AddNewExhibition", param, commandType: System.Data.CommandType.StoredProcedure);
            }
            else
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                param.Add("@Exhib_ID", exhib.exhibitionId);
                connection.Execute("mydb.UpdateExhibition", param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public static void UpdateTable(bool isNew, Interface inter)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Exhib_ID", inter.exhibitionId);
            param.Add("@Art_ID", inter.artworkId);
            if (isNew)
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                connection.Execute("mydb.AddNewInterface", param, commandType: System.Data.CommandType.StoredProcedure);
            }
            else
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                param.Add("@Inter_ID", inter.interfaceId);
                connection.Execute("mydb.UpdateInterface", param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public static void UpdateTable(bool isNew, Photos photos)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Art_ID", photos.artworkID);
            param.Add("@Url", photos.url);
            if (isNew)
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                connection.Execute("mydb.AddNewPhoto", param, commandType: System.Data.CommandType.StoredProcedure);
            }
            else
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                param.Add("@Photo_ID", photos.photoID);
                connection.Execute("mydb.UpdatePhoto", param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public static void DeleteRecord(string conntype, int id)
        {
            if (conntype == Program.simpleArt)
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                connection.Execute("mydb.DeleteArt(@Art_ID)", new { Art_ID = id });
            }
            else if (conntype == Program.simpleExhib)
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                connection.Execute("mydb.DeleteExhibition(@Exhib_ID)", new { Exhib_ID = id });
            }
            else if (conntype == Program.photos)
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                connection.Execute("mydb.DeletePhoto(@Pic_ID)", new { Pic_ID = id });
            }
            else if (conntype == Program.inter)
            {
                using DbConnection connection = new MySqlConnection(Helper.connString("MyDB"));
                connection.Execute("mydb.DeleteInterface(@Inter_ID)", new { Inter_ID = id });
            }
        }
    }
}
