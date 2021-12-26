using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DataBaseLocation))
            {
                conn.CreateTable<Post>();
                var postTable = conn.Table<Post>().ToList();

                var categories = (from p in postTable
                                  orderby p.Category
                                  select p.Category).Distinct().ToList();

                Dictionary<string, int> CategoryCount = new Dictionary<string, int>();
                foreach(var category in categories)
                {
                    var count = (from post in postTable
                                 where post.Category == category
                                 select post).ToList().Count;
                    CategoryCount.Add(category, count);
                }
                CategoriesListView.ItemsSource = CategoryCount;


                postCountLabel.Text = postTable.Count().ToString();
            }
        }
    }
}