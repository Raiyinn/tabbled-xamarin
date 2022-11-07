using Firebase.Database;
using Projekat_133_100.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Projekat_133_100
{
    public partial class MainPage : ContentPage
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://xamarindatabaseproject-6453f-default-rtdb.europe-west1.firebasedatabase.app/");

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
