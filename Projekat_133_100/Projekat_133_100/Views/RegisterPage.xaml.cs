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
    public partial class RegisterPage : ContentPage
    {
        //Table table;
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = this;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public async void SignIn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EntryUsername.Text) || string.IsNullOrEmpty(EntryPassword.Text) || string.IsNullOrEmpty(EntryEmail.Text) || string.IsNullOrEmpty(EntryConfirmPassword.Text))
                await DisplayAlert("Empty Values", "Please enter all of the values", "OK");
            else
            {
                if (EntryPassword.Text == EntryConfirmPassword.Text)
                {

                    var users = await FirebaseHelper.AddUser(EntryUsername.Text, EntryEmail.Text, EntryPassword.Text, EntryConfirmPassword.Text);

                    if (users)
                    {
                        await DisplayAlert("SignUp Success", "", "Ok");
                            
                        await Navigation.PushModalAsync(new LoginPage());
                    }

                    else
                    {
                        await DisplayAlert("Error", "SignUp Fail", "OK");
                    }
                }
                

                else
                {
                    await DisplayAlert("Error", "Passwords do not match!", "Continue");
                }

            }

        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}