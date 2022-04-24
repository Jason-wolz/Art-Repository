﻿using System;

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
    }
     
    public class Artwork : Table
    {
        public int id { get; set; }
        public string title { get; set; }
        public string medium { get; set; }
        public string length { get; set; }
        public string width { get; set; }
        public DateTime date { get; set; }
        public bool isFramed { get; set; }
        public string editionDetails { get; set; }
        public string saleDetails { get; set; }
        public string notes { get; set; }
    }

    public class Photos : Table
    {
        public int id { get; set; }
        public int artworkId { get; set; }
        public string url { get; set; }
    }

    public class Interface : Table
    {
        public int id { get; set; }
        public int exhibitionId { get; set; }
        public int artworkId { get; set; }
    }
}