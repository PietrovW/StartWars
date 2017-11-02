using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using StartWars.ViewModels.Menu;
using StartWars.ViewModels.Pages;

namespace StartWars.Startup
{
    public class IoCConfig
    {
        public IoCConfig()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
        }

        public void RegisterSettings()
        {
           
        }

        public void RegisterRepositories()
        {
           
        }

        public void RegisterServices()
        {
          
        }

        /// <summary>
        /// Registers the view models.
        /// </summary>
        public void RegisterViewModels()
        {
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<RootPageViewModel>();
            SimpleIoc.Default.Register<MenuPageViewModel>();
            SimpleIoc.Default.Register<SecondPageViewModel>();

        }

        /// <summary>
        /// Handles navigation wire up
        /// </summary>
        public void RegisterNavigation()
        {
            
        }
    }
}