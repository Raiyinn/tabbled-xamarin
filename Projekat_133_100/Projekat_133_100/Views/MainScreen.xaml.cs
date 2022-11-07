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
    public partial class MainScreen : TabbedPage
    {
        public IList<Caffee> CaffeList { get; set;}
        public string userUsername;

        public MainScreen(string username)
        {
            InitializeComponent();

            getUserMain(username);
            userUsername = username;

            CaffeList = new List<Caffee>();

            CaffeList.Add(new Caffee { Id = 1, Capacity = 150, Name = "Carpe Diem", Description = "The title, Seize the Day, describes an endless possibility of relaxing the entire day.", Image = "carpediem.jpg" });
            CaffeList.Add(new Caffee { Id = 2, Capacity = 100, Name = "Cooltura", Description = "A terrific location (City Arena), an excellent location for the whole family.", Image = "cooltura.jpg" });
            CaffeList.Add(new Caffee { Id = 3, Capacity = 80, Name = "Da Vinci's Pub", Description = "A place where the youth goes to have an amazing time.", Image = "davincipub.jpg" });
            CaffeList.Add(new Caffee { Id = 4, Capacity = 110, Name = "Libertas Pub", Description = "As a part of a hotel, the Libertas Pub is a frequent place of marvelous joy.", Image = "libertas.jpg" });

            
            Caffes.ItemsSource = CaffeList;
        }

        public async void getUserMain(string username)
        {
            var user = await FirebaseHelper.GetUser(username);
            CurrentUsername.Text = user.Username;
            UserUsername.Text = user.Username;
            UserPassword.Text = user.Password;
        }

        public async void DetailPage_Clicked(object sender, EventArgs e)
        {
            Caffee selectedCaffe = new Caffee();
            var stack = sender as StackLayout;
            var caffe = stack.BindingContext as Caffee;

            selectedCaffe = CaffeList.Where(x => x.Id == caffe.Id).FirstOrDefault();

            await Navigation.PushModalAsync(new CaffeDetail(selectedCaffe, userUsername));
        }
    }
}