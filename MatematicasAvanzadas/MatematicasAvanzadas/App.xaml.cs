using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MatematicasAvanzadas.Services;
using MatematicasAvanzadas.Views;

namespace MatematicasAvanzadas
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new TabAppPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
