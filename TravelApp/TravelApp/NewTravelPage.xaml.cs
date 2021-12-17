using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using TravelApp.Models;

namespace TravelApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTravelPage : ContentPage
	{
		public NewTravelPage ()
		{
			InitializeComponent ();
		}

        private void Savebutton_Clicked(object sender, EventArgs e)
        {
            Post post = new Post()
            {
                Experience = expirenceEntry.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Insert(post);
                conn.Close();

                if (rows > 0)
                    DisplayAlert("Success", "Experience was  added ", "Okay");
                else
                    DisplayAlert("Failure", "Experience was not added", "Okay");

                expirenceEntry.Text = "";
            }
               

        }
    }
}