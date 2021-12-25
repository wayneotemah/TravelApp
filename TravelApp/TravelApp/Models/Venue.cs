using System;
using System.Collections.Generic;
using System.Text;
using TravelApp.Helpers;

namespace TravelApp.Models
{
    public class Venue
    {
        // class to generate url passing in lat and longitude
        public static string GenerateURL(double latitude, double longitude)
        {
           return string.Format(Constants.VENUE_SEARCH,latitude,longitude,Constants.API_KEY);
        }
    }
}
