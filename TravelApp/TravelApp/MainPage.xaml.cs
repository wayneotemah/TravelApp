using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);
            iconImage.Source = ImageSource.FromResource("TravelApp.Assets.Images.pic1.png", assembly);
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(emailEntry.Text) || string.IsNullOrEmpty(passwordEntry.Text))
            // check if login inputes are empty
            //if not, check passwords
            {
                infoLable.Text = "Fill all the fields";
                passwordEntry.Text = "";
            }
            else
            {

                if (emailEntry.Text == "123@test.com" && passwordEntry.Text == "qwerty")
                //check the password and email
                //route to homepage if true
                {
                    Navigation.PushAsync(new HomePage());
                }
                else
                {
                    infoLable.Text = "Wrong cridentals try again";
                    passwordEntry.Text = "";
                    emailEntry.Text = "";
                }
            }
        }
    }
}
