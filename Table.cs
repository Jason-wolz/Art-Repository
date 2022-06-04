using System;

namespace Capstone_Project
{
    public abstract class Table
    {

    }
    public class Exhibition : Table
    {
        public int exhibitionId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string city  { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public string country { get; set; }
        public int applicationFee { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string juror { get; set; }

        public override string ToString()
        {
            string toString = "Name: " + name;
            toString += "\nAddress: " + address;
            toString += "\nCity: " + city;
            toString += "\nState: " + state;
            toString += "\nZip Code: " + zipCode;
            toString += "\nCountry: " + country;
            toString += "\nStart Date: " + startDate.ToString("d");
            toString += "\nEnd Date: " + endDate.ToString("d");
            toString += "\nApplication Fee: " + applicationFee.ToString();
            toString += "\nJuror: ";
            toString += !string.IsNullOrEmpty(juror) ? juror : "None";
            return toString;
        }
    }
     
    public class Artwork : Table
    {
        public int artworkID { get; set; }
        public string title { get; set; }
        public string medium { get; set; }
        public string length { get; set; }
        public string width { get; set; }
        public DateTime createDate { get; set; }
        public bool isFramed { get; set; }
        public string editionDetails { get; set; }
        public string saleDetails { get; set; }
        public string notes { get; set; }

        public override string ToString()//for use in the download report
        {
            string toString = "Title: " + title;
            toString += "\nMedium: " + medium;
            toString += "\nDimensions: " + length + " by " + width;
            toString += "\nCreated: " + createDate.ToString("Y");
            toString += "\nSale details: " +saleDetails;
            toString += "\nEdition Details: " + editionDetails;
            toString += "\nFramed: ";
            if (isFramed)
            {
                toString += "Yes";
            }
            else
            {
                toString += "No";
            }
            toString += "\nNotes: " + notes;
            return toString;
        }
    }

    public class Photos : Table
    {
        public int photoID { get; set; }
        public int artworkID { get; set; }
        public string url { get; set; }
    }

    public class Interface : Table
    {
        public int interfaceId { get; set; }
        public int exhibitionId { get; set; }
        public int artworkId { get; set; }
    }
}
