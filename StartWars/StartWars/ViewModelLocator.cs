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
        public const string PlanetsPageDetail = "PlanetsPageDetail";
        public const string FilmsPage = "FilmsPage";

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
           
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<RootPageViewModel>();
            SimpleIoc.Default.Register<MenuPageViewModel>();
            SimpleIoc.Default.Register<SecondPageViewModel>();
            SimpleIoc.Default.Register<PlanetsDetailsViewModel>();
            SimpleIoc.Default.Register<FilmsPageViewModel>();
        }

        public MainPageViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainPageViewModel>();
        public RootPageViewModel RootPageViewModel => ServiceLocator.Current.GetInstance<RootPageViewModel>();
        public MenuPageViewModel MenuPageViewModel => ServiceLocator.Current.GetInstance<MenuPageViewModel>();
        public SecondPageViewModel SecondPageViewModel => ServiceLocator.Current.GetInstance<SecondPageViewModel>();
        public PlanetsDetailsViewModel PlanetsDetailsViewModel=> ServiceLocator.Current.GetInstance <PlanetsDetailsViewModel>();
        public FilmsPageViewModel FilmsPageViewModel => ServiceLocator.Current.GetInstance<FilmsPageViewModel>();
    }
}
