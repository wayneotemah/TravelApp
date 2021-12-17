using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Map map = new Map() { IsShowingUser = true }; 

            var locator = CrossGeolocator.Current;

            locator.PositionChanged += Locator_PositionChanged;
            await locator.StartListeningAsync(TimeSpan.FromSeconds(0),50);
              
            var position = await locator.GetPositionAsync();
            var center = new Position(position.Latitude,position.Longitude);
            var span = new MapSpan(center, 2, 2);
            map.MoveToRegion(span);
            map.Pins.Add(new Pin
            {
                Label = "You are here",
                Position = center
            });

            Content = map;

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

            map.MoveToRegion(span);

            map.Pins.Add(new Pin
            {
                Label = "You are here",
                Position = center
            });


            Content = map;
        }


    }
}