using GalaSoft.MvvmLight.Ioc;

using StartWars.Services.Navigation;
using StartWars.Services.Navigation.Base;
using StartWars.Startup;
using StartWars.View.Menu;
using StartWars.View.Pagets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace StartWars
{
    public partial class App : Application
    {
        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }
        public static ViewNavigationService navigationService { get; private set; }
        public App()
        {
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
