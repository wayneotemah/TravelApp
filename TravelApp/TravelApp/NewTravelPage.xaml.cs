using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using TravelApp.Models;
using TravelApp.Logic;
using Plugin.Geolocator;

namespace TravelApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTravelPage : ContentPage
	{
		public NewTravelPage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            DisplayLocation.Text = "Looking up your location";
            try
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();
                DisplayLocation.Text = $"Found You at (Lat,Long): ";
                //public long = position.Longitude;
                LatLable.Text = $"{position.Latitude}";
                LonLable.Text = $"{position.Longitude}";

            }
            catch (Exception ex)
            {
                await DisplayAlert("Failure", ex.ToString(), "Okay");
            }
        }

        private  void Savebutton_Clicked(object sender, EventArgs e)
        {
            //on newTravelpage saveutton opeation
           

            if (string.IsNullOrEmpty(expirenceEntry.Text)||string.IsNullOrEmpty(DisplayLocation.Text))
            {
                DisplayAlert("Failure", "Fill in the blanks", "Okay");
            }
            else
            {
      
                Post post = new Post()
                {
                    // create new post instance from the Post model and pass in the experience attribute
                    Experience = expirenceEntry.Text,
                    VenueName = LocationNameEntry.Text,
                    Longitude = LonLable.Text,
                    Latitude = LatLable.Text
                };
                //creaating local sql connction to store information in database
                using (SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation))
                {
                    conn.CreateTable<Post>();// if not such table as post, create it
                    int rows = conn.Insert(post);// insert in the taple the post instance and return number of added row 
                    conn.Close();// close connection

                    // check if it was successful
                    if (rows > 0)
                        DisplayAlert("Success", "Experience was  added ", "Okay");
                    else
                        DisplayAlert("Failure", "Experience was not added", "Okay");

                    expirenceEntry.Text = "";
                    LocationNameEntry.Text = "";

                }
            }
        }

        /*private async void CurrentlocationButton_Clicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            Co_ordinate.Text = position.Latitude + "," + position.Longitude;

        }

        private async void PickLocationButton_Clicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            var venues = await VenueLogic.GetVenues(position.Latitude, position.Longitude);

        }*/


    }
}