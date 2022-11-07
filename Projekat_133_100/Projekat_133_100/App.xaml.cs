using Projekat_133_100.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekat_133_100
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            MainPage = new NavigationPage(new SplashScreen())
            {
                BarBackgroundColor = Color.Transparent
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
