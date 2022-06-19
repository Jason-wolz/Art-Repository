using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using MySql.Data.MySqlClient;
using Dapper;
using System.Windows.Forms;

namespace Capstone_Project
{
    internal static class DataSetClass
    {
        //method for connecting to database from Youtuber IAmTimCorey  
        public static List<Table> ConnectToData(string connType, int id)
        {
            var list = new List<Table>();
            if (connType == Program.simpleExhib)
            {
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
                list.AddRange(connection.Query<Exhibition>("mydb.GetExhibitionByArt(@ID)", new { ID = id }).ToList());
                return list;
            }
            else if (connType == Program.photos)
            {
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
                list.AddRange(connection.Query<Photos>("mydb.GetPhotosByArt(@ID)", new { ID = id }).ToList());
                return list;
            }
            else if (connType == Program.simpleArt)
            {
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
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
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
                list.AddRange(connection.Query<Exhibition>("mydb.GetFullExhibition").ToList());
                return list;
            }
            else if (connType == Program.allArt)
            {
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
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
            using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
            var list = new List<Table>();
            list.AddRange(connection.Query<Artwork>("mydb.GetArtworkLastYear(@BeginDate)", new { BeginDate = lastYear }).ToList());
            return list;
        }

        public static List<Artwork> Search(DateTime date)
        {
            using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
            List<Artwork> list = connection.Query<Artwork>("mydb.GetArtByYear(@Year)", new { Year = date }).ToList();
            return list;
        }

        public static List<Artwork> Search(string type, string searchTerm)
        {
            List<Artwork> list = new List<Artwork>();
            if (type == Program.name)
            {
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
                list.AddRange(connection.Query<Artwork>("mydb.GetArtByName(@Name)", new { Name = searchTerm }).ToList());
                return list;
            }
            else if (type == Program.medium)
            {
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
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
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
                connection.Execute("mydb.AddNewArt", param, commandType: System.Data.CommandType.StoredProcedure);
            }
            else
            {
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
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
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
                connection.Execute("mydb.AddNewExhibition", param, commandType: System.Data.CommandType.StoredProcedure);
            }
            else
            {
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
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
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
                connection.Execute("mydb.AddNewInterface", param, commandType: System.Data.CommandType.StoredProcedure);
            }
            else
            {
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
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
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
                connection.Execute("mydb.AddNewPhoto", param, commandType: System.Data.CommandType.StoredProcedure);
            }
            else
            {
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
                param.Add("@Photo_ID", photos.photoID);
                connection.Execute("mydb.UpdatePhoto", param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public static void DeleteRecord(string conntype, int id)
        {
            if (conntype == Program.simpleArt)
            {
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
                connection.Execute("mydb.DeleteArt(@Art_ID)", new { Art_ID = id });
            }
            else if (conntype == Program.simpleExhib)
            {
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
                connection.Execute("mydb.DeleteExhibition(@Exhib_ID)", new { Exhib_ID = id });
            }
            else if (conntype == Program.photos)
            {
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
                connection.Execute("mydb.DeletePhoto(@Pic_ID)", new { Pic_ID = id });
            }
            else if (conntype == Program.inter)
            {
                using DbConnection connection = new MySqlConnection(Helper.ConnString("MyDB"));
                connection.Execute("mydb.DeleteInterface(@Inter_ID)", new { Inter_ID = id });
            }
        }
        public static void CreateDatabase()
        {
            string dataCmd = "CREATE DATABASE IF NOT EXISTS `mydb` /*!40100 DEFAULT CHARACTER SET latin1 */;";
            string artCmd = "CREATE TABLE IF NOT EXISTS`artwork` ( `Artwork_ID` int(11) NOT NULL AUTO_INCREMENT, `Title` varchar(45) NOT NULL, `Medium` varchar(45) NOT NULL, " +
                "`Length` varchar(10) NOT NULL, `Width` varchar(10) NOT NULL, `Create_Date` date NOT NULL, `Is_Framed` tinyint(4) NOT NULL, `Edition_Details` varchar(45) DEFAULT NULL," +
                " `Sale_Details` varchar(100) DEFAULT NULL, `Notes` varchar(200) DEFAULT NULL,PRIMARY KEY(`Artwork_ID`)) ENGINE = InnoDB AUTO_INCREMENT = 6 DEFAULT CHARSET = latin1;";
            string picCmd = "CREATE TABLE IF NOT EXISTS `photos` (`Photo_ID` int(11) NOT NULL AUTO_INCREMENT, `Artwork_ID` int(11) NOT NULL, `URL` varchar(125) NOT NULL," +
                " PRIMARY KEY(`Photo_ID`), KEY `Artwork ID_idx` (`Artwork_ID`), KEY `Artwork_idx` (`Artwork_ID`), CONSTRAINT `Photo Art ID` FOREIGN KEY(`Artwork_ID`)" +
                " REFERENCES `artwork` (`Artwork_ID`) ON DELETE CASCADE ON UPDATE CASCADE) ENGINE = InnoDB AUTO_INCREMENT = 30 DEFAULT CHARSET = latin1;";
            string exhibCmd = "CREATE TABLE IF NOT EXISTS `exhibition` ( `Exhibition_ID` int(11) NOT NULL AUTO_INCREMENT, `Name` varchar(45) NOT NULL, `Address` varchar(45) NOT NULL," +
                " `City` varchar(45) NOT NULL, `State` varchar(45) NOT NULL, `Zip_Code` varchar(10) NOT NULL, `Country` varchar(45) NOT NULL, `Application_Fee` int(11) NOT NULL," +
                " `Start_Date` date NOT NULL, `End_Date` date NOT NULL, `Juror` varchar(45) DEFAULT NULL, PRIMARY KEY(`Exhibition_ID`)) ENGINE = InnoDB AUTO_INCREMENT = 4 DEFAULT CHARSET = latin1;";
            string interCmd = "CREATE TABLE IF NOT EXISTS `interface` (`Interface_ID` int (11) NOT NULL AUTO_INCREMENT, `Exhibition_ID` int (11) NOT NULL, `Artwork_ID` int (11) NOT NULL," +
                " PRIMARY KEY(`Interface_ID`), KEY `Artwork ID_idx` (`Artwork_ID`), KEY `Exhib ID` (`Exhibition_ID`), CONSTRAINT `Art ID` FOREIGN KEY(`Artwork_ID`) REFERENCES" +
                " `artwork` (`Artwork_ID`) ON DELETE CASCADE ON UPDATE CASCADE, CONSTRAINT `Exhib ID` FOREIGN KEY(`Exhibition_ID`) REFERENCES `exhibition` (`Exhibition_ID`)" +
                " ON DELETE CASCADE ON UPDATE CASCADE) ENGINE=InnoDB AUTO_INCREMENT = 9 DEFAULT CHARSET = latin1;";
            string addCmd = @"
CREATE PROCEDURE `AddNewArt`(in title varchar(45), in medium varchar(45), in length varchar(10), in width varchar(10), 
in create_date date, in framed tinyint, in edition varchar(45), in sale varchar(100), in notes varchar(200))
BEGIN
INSERT INTO `mydb`.`artwork` (`Title`, `Medium`, `Length`, `Width`, `Create_Date`, `Is_Framed`, `Edition_Details`, `Sale_Details`, `Notes`) 
VALUES (title, medium, length, width, create_date, framed, edition, sale, notes);
END;
CREATE PROCEDURE `AddNewExhibition`(in name varchar(45), in address varchar(45), in city varchar(45), in state varchar(45), 
in zip varchar(10), in country varchar(45), in fee int, in start date, in end date, in juror varchar(45))
BEGIN
INSERT INTO `mydb`.`exhibition` (`Name`, `Address`, `City`, `State`, `Zip_Code`, `Country`, `Application_Fee`, `Start_Date`, `End_Date`, `Juror`) 
VALUES (name, address, city, state, zip, country, fee, start, end, juror);
END;
CREATE PROCEDURE `AddNewInterface`(in exhib_ID int, in art_ID int)
BEGIN
INSERT INTO `mydb`.`interface` (`Exhibition_ID`, `Artwork_ID`) 
VALUES (exhib_ID, art_ID);
END;
CREATE PROCEDURE `AddNewPhoto`(in art_ID int, in url varchar(125))
BEGIN
INSERT INTO `mydb`.`photos` (`Artwork_ID`, `URL`) 
VALUES (art_ID, url);
END;";
            string deleteCmd = @"
CREATE PROCEDURE `DeleteArt`(in art_ID int)
BEGIN
delete from mydb.artwork 
where Artwork_ID = art_ID;
END;
CREATE PROCEDURE `DeleteExhibition`(in exhib_ID int)
BEGIN
delete from mydb.exhibition
where Exhibition_ID = exhib_ID;
END;
CREATE PROCEDURE `DeleteInterface`(in inter_ID int)
BEGIN
delete from mydb.interface
where Interface_ID = inter_ID;
END;
CREATE PROCEDURE `DeletePhoto`(in pic_ID int)
BEGIN
delete from mydb.photos
where Photo_ID = pic_ID;
END;";
            string getCmd = @"
CREATE PROCEDURE `GetAllArtwork`()
BEGIN
select * from artwork;
END;
CREATE PROCEDURE `GetArtByExhibition`(in ID int)
BEGIN
select * 
from artwork inner join interface
on artwork.Artwork_ID = interface.Artwork_ID
where interface.Exhibition_ID = ID;
END;
CREATE PROCEDURE `GetArtByMedium`(in med varchar(45))
BEGIN
SELECT * FROM artwork 
where locate(med, Medium);
END;
CREATE PROCEDURE `GetArtByName`(in name varchar(45))
BEGIN
SELECT * FROM artwork 
where locate(name, Title);
END;
CREATE PROCEDURE `GetArtByYear`(in year date)
BEGIN
declare endYear date;
set endYear=adddate(year, interval 1 YEAR);
select * from artwork where Create_Date between year and endYear;
END;
CREATE PROCEDURE `GetArtworkLastYear`(in BeginDate date)
BEGIN
select * from artwork 
where Create_Date > BeginDate;
END;
CREATE PROCEDURE `GetExhibitionByArt`(in ID int)
BEGIN
Select *
from exhibition inner join interface
on exhibition.Exhibition_ID = interface.Exhibition_ID
where interface.Artwork_ID = ID;
END;
CREATE PROCEDURE `GetFullExhibition`()
BEGIN
select * from exhibition;
END;
CREATE PROCEDURE `GetPhotos`(in ArtID int)
BEGIN
select url from photos where Artwork_ID = ArtID;
END;
CREATE PROCEDURE `GetPhotosByArt`(in ID int)
BEGIN
select * from photos where Artwork_ID = ID;
END;";
            string updateCmd = @"
CREATE PROCEDURE `UpdateArtwork`(in art_ID int, in title varchar(45), in medium varchar(45), in length varchar(10), in width varchar(10), 
in create_date date, in framed tinyint, in edition varchar(45), in sale varchar(100), in notes varchar(200))
BEGIN
Update mydb.artwork
set Title = title, Medium = medium, Length = length, Width = width, Create_Date = create_date, 
Is_Framed = framed, Edition_Details = edition, Sale_Details = sale, Notes = notes 
where Artwork_ID = art_ID;
END;
CREATE PROCEDURE `UpdateExhibition`(in exhib_ID int, in name varchar(45), in address varchar(45), in city varchar(45), 
in state varchar(45), in zip varchar(10), in country varchar(45), in fee int, in start date, in end date, in juror varchar(45))
BEGIN
Update mydb.exhibition
set Name = name, Address = address, City = city, State = state, Zip_Code = zip, Country = country, 
Application_Fee = fee, Start_Date = start, End_Date = end, Juror = Juror
where Exhibition_ID = exhib_ID;
END;
CREATE PROCEDURE `UpdateInterface`(in inter_ID int, in exhib_ID int, in art_ID int)
BEGIN
update mydb.interface
set Exhibition_ID = exhib_ID, Artwork_ID = art_ID
where Interface_ID = inter_ID;
END;
CREATE PROCEDURE `UpdatePhoto`(in photo_ID int, in art_ID int, in url varchar(125))
BEGIN
update mydb.photos
set Artwork_ID = art_ID, URL = url
where Photo_ID = photo_ID;
END;";
            try
            {
                using DbConnection connection = new MySqlConnection(Helper.ConnString("NewDB"));
                connection.Execute(dataCmd);
                using DbConnection connection1 = new MySqlConnection(Helper.ConnString("MyDB"));
                connection1.Query(artCmd);
                connection1.Query(picCmd);
                connection1.Query(exhibCmd);
                connection1.Query(interCmd);
                connection1.Query(addCmd);
                connection1.Query(deleteCmd);
                connection1.Query(getCmd);
                connection1.Query(updateCmd);
            }
            catch (MySqlException ex)
            {
                if (ex.Message != "PROCEDURE AddNewArt already exists")
                {
                    MessageBox.Show(ex.Message);
                }
            }
            SampleData();
        }
        public static void SampleData()
        {
            List<Table> temp = new List<Table>();
            temp.AddRange(ConnectToData(Program.allArt));
            List<Artwork> arts = temp.Cast<Artwork>().ToList();
            if (arts.Count == 0)
            {
                Artwork art = new Artwork
                {
                    title = "Somewhere in Time",
                    medium = "Paper",
                    length = "10 inches",
                    width = "10 inches",
                    createDate = DateTime.Parse("07/19/2021"),
                    isFramed = false,
                    editionDetails = "",
                    saleDetails = "",
                    notes = ""
                };
                UpdateTable(true, art);
                temp = ConnectToData(Program.allArt);
                arts = temp.Cast<Artwork>().ToList();
            }            
            foreach (Artwork a in arts)
            {
                temp = ConnectToData(Program.photos, a.artworkID);
                if (temp.Count > 0)
                {
                    break;
                }
            }
            if (temp.Count == 0)
            {
                Photos pic = new Photos
                {
                    artworkID = arts[0].artworkID,
                    url = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "Capstone\\Photos\\sample1.jpg"
                };
                UpdateTable(true, pic);
            }
            temp = ConnectToData(Program.allExhib);
            if (temp.Count == 0)
            {
                Exhibition exhib = new Exhibition
                {
                    name = "Exhibition",
                    address = "123 Sample Rd.",
                    city = "Somewhere",
                    state = "A State",
                    zipCode = "12345",
                    country = "US",
                    applicationFee = 30,
                    startDate = DateTime.Parse("05/10/2022"),
                    endDate = DateTime.Parse("11/23/2022"),
                    juror = ""
                };
                UpdateTable(true, exhib);
                temp = ConnectToData(Program.allExhib);
            }
            List<Exhibition> exhibs = temp.Cast<Exhibition>().ToList();
            foreach (Exhibition ex in exhibs)
            {
                temp = ConnectToData(Program.simpleArt, ex.exhibitionId);
                if (temp.Count > 0)
                {
                    break;
                }
            }
            if (temp.Count == 0)
            {
                Interface inter = new Interface
                {
                    artworkId = arts[0].artworkID,
                    exhibitionId = exhibs[0].exhibitionId
                };
                UpdateTable(true, inter);
            }
        }
    }
}
