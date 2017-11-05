using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using StartWars.ViewModels.Menu;
using StartWars.ViewModels.Pages;

namespace StartWars
{
    public class ViewModelLocator
    {
        public const string MasterPage = "MasterPage";
        public const string MainPage = "MainPage";
        public const string DetailsPage = "DetailsPage";
        public const string RootPage = "RootPage";
        public const string MenuPage = "MenuPage";
        public const string SecondPage = "SecondPage";

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
           
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<RootPageViewModel>();
            SimpleIoc.Default.Register<MenuPageViewModel>();
            SimpleIoc.Default.Register<SecondPageViewModel>();
        }

        public MainPageViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainPageViewModel>();
        public SecondPageViewModel DetailsViewModel => ServiceLocator.Current.GetInstance<SecondPageViewModel>();
        public RootPageViewModel RootPageViewModel => ServiceLocator.Current.GetInstance<RootPageViewModel>();
        public MenuPageViewModel MenuPageViewModel => ServiceLocator.Current.GetInstance<MenuPageViewModel>();
    }
}
