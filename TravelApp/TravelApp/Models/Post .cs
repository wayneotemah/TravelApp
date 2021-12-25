using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TravelApp.Models
{
    public class Post
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }

        [MaxLength(250)]
        public string Experience { get; set; }

        public string VenueName { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }


    }
}
