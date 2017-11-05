using GalaSoft.MvvmLight.Ioc;

using StartWars.Services.Navigation;

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
        private static ViewModelLocator _viewModelLocator;
        public static ViewModelLocator ViewModelLocator
        {
            get
            {
                return _viewModelLocator ?? (_viewModelLocator = new ViewModelLocator());
            }
        }
        public static IViewNavigationService navigationService { get; private set; }

        public App()
        {
            NavigationPage NavigationPage;
            InitializeComponent();



            if (!SimpleIoc.Default.IsRegistered<IViewNavigationService>())
            {
                navigationService = new ViewNavigationService();
                navigationService.Configure(ViewModelLocator.MainPage, typeof(MainPage));
                navigationService.Configure(ViewModelLocator.DetailsPage, typeof(DetailsPage));
                navigationService.Configure(ViewModelLocator.RootPage, typeof(RootPage));
                navigationService.Configure(ViewModelLocator.MenuPage, typeof(MenuPage));
                navigationService.Configure(ViewModelLocator.SecondPage, typeof(SecondPage));

                SimpleIoc.Default.Register<IViewNavigationService>(() => navigationService);
            }
            else
                navigationService = SimpleIoc.Default.GetInstance<IViewNavigationService>();



            NavigationPage = new NavigationPage(new MainPage());
            navigationService.Initialize(NavigationPage);
            RootPage rootPage = new RootPage();
            MenuPage menuPage = new MenuPage();

            rootPage.Master = menuPage;
            rootPage.Detail = NavigationPage;
            MainPage = rootPage;
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
