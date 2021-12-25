using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;


using TravelApp.Models;
using TravelApp.Helpers;

namespace TravelApp.Logic
{
    public class VenueLogic
    {
        //async static method to return a list of venus from the foursquare API
        public async static Task<List<Venue>> GetVenues( double latitude, double longitude)
        {
            List<Venue> venues = new List<Venue>();

            var url = Venue.GenerateURL(latitude, longitude);
            //svar authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(Constants.API_KEY));


            // client request to get nearby locations from foursquare
            
            using (HttpClient client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", Constants.API_KEY);
                //client.DefaultRequestHeaders.Add("Authorization", Constants.API_KEY);// add auth url header
                var response = await client.GetAsync(url);// make request
                var json = await response.Content.ReadAsStringAsync();// read response as string 
            }

            return venues;
        } 

    }
}
