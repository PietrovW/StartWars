using GalaSoft.MvvmLight.Messaging;
using StartWars.Services.Navigation;
using StartWars.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StartWars.ViewModels.Pages
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand NavigateCommand { get; private set; }
        public ICommand NavigateCommand2 { get; private set; }

        public MainPageViewModel(IViewNavigationService navigationService):base(navigationService)
        {
            NavigateCommand = new Command(() => Navigate());
            NavigateCommand2 = new Command(() => Navigate2());
        }

        private void Navigate()
        {
          //  var person = new Person() { Name = "Daniel" };
        //    Messenger.Default.Send(person);
           // _navigationService.NavigateTo("DetailsPage", person);
        }
        private void Navigate2()
        {
           // var person = new Person() { Name = "Daniel" };
           // Messenger.Default.Send(person);
           // _navigationService.NavigateTo("DetailsPage", person);
        }
    }
}
