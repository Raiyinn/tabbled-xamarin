using Firebase.Database;
using Projekat_133_100.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_133_100.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekat_133_100.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CaffeDetail : ContentPage
    {
        Table reservedTable;
        public string userUsername;
        public CaffeDetail(Caffee caffe, string username)
        {
            InitializeComponent();
            BindingContext = this;
            reservedTable = new Table { Id = 1, Caffee = caffe.Name, Reserved = false };
            getUserMain(username);
            userUsername = username;
            CaffeName.Text = caffe.Name;
            CaffeImage.Source = caffe.Image;
            CaffeDesc.Text = caffe.Description;
        }

        public async void getUserMain(string username)
        {
            var user = await FirebaseHelper.GetUser(username);
            user.ReservedTable = reservedTable.Caffee;
        }

        public async void Reserved(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainScreen(userUsername));
        }
    }
}