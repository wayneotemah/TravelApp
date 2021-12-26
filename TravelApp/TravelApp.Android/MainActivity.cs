using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

namespace TravelApp.Droid
{
    [Activity(Label = "TravelApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.setFlags("FastRenderers_Experimental");
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);



            string dbName = "travell_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullpath = Path.Combine(folderPath, dbName);

            LoadApplication(new App(fullpath));
        }
    }
}