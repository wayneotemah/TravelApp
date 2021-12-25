using Plugin.Geolocator;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TravelApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();
		}
        

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;

            locator.PositionChanged += Locator_PositionChanged;
            await locator.StartListeningAsync(TimeSpan.FromSeconds(0),50);
              
            var position = await locator.GetPositionAsync();
            var center = new Position(position.Latitude,position.Longitude);
            var span = new MapSpan(center, 1, 1);
            locationMap.MoveToRegion(span);
            

            using (SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation))
            {
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();
                DisplayinMap(posts);
            }
        }

        private void DisplayinMap(List<Post> posts)
        {
            foreach(var post in posts)
            {
                try
                {
                    var position = new Position(Convert.ToDouble(post.Latitude), Convert.ToDouble(post.Longitude));

                    var pin = new Pin()
                    {
                        Type = PinType.SavedPin,
                        Position = position,
                        Label = post.VenueName,

                    };
                    locationMap.Pins.Add(pin);

                }
                catch (NullReferenceException nre) { }
                catch (Exception ex)
                {
                    DisplayAlert("Failure", ex.ToString(), "Okay");
                }
            }
            
            

        }


        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            var locator = CrossGeolocator.Current;
            locator.PositionChanged -= Locator_PositionChanged;

            await locator.StopListeningAsync();
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            Map map = new Map();

            var center = new Position(e.Position.Latitude, e.Position.Longitude);
            var span = new MapSpan(center, 2, 2);

            locationMap.MoveToRegion(span);

            
        }


    }
}