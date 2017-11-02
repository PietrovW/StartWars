using StartWars.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartWars.Services.Navigation.Base;

namespace StartWars.ViewModels.Pages
{
    public class SecondPageViewModel : BaseViewModel
    {
        public SecondPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
