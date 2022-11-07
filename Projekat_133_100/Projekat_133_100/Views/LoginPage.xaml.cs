using Firebase.Database;
using Projekat_133_100.Models;
using Projekat_133_100.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekat_133_100.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
        }

        public async void MainScreen_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(LoginUsername.Text) || string.IsNullOrEmpty(LoginPassword.Text))
                await DisplayAlert("Empty Values", "Please enter Username and Password", "OK");
            else
            {
                //call GetUser function which we define in Firebase helper class
                var user = await FirebaseHelper.GetUser(LoginUsername.Text);
                //firebase return null valuse if user data not found in database
                if (user != null)
                    if (LoginUsername.Text == user.Username && LoginPassword.Text == user.Password)
                    {
                        await DisplayAlert("Login Success", "", "Ok");

                        await Navigation.PushModalAsync(new MainScreen(LoginUsername.Text));
                    }
                    else
                        await DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
                else
                    await DisplayAlert("Login Fail", "User not found", "OK");
            }

        }
    }
}
