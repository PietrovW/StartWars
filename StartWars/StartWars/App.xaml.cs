using GalaSoft.MvvmLight.Ioc;

using StartWars.Services.Navigation;
using StartWars.Services.Rest;
using StartWars.View.Menu;
using StartWars.View.Pagets;
using System;
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
                navigationService.Configure(ViewModelLocator.PlanetsPageDetail, typeof(PlanetsPageDetail));
                navigationService.Configure(ViewModelLocator.FilmsPage, typeof(FilmsPage));
                navigationService.Configure(ViewModelLocator.SecondPage, typeof(SecondPage));

                SimpleIoc.Default.Register<IViewNavigationService>(() => navigationService);
                SimpleIoc.Default.Register<IRestService>(() => new RestService());
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
            Application.Current.Properties["SleepDate"] = DateTime.Now.ToString("O");
           // Application.Current.Properties["FirstName"] = _backgroundPage.FirstName;
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
