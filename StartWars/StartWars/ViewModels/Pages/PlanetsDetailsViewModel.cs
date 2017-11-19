using StartWars.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartWars.Services.Navigation;

namespace StartWars.ViewModels.Pages
{
    public class PlanetsDetailsViewModel : BaseViewModel
    {
        public PlanetsDetailsViewModel(IViewNavigationService navigationService) : base(navigationService)
        {
        }
    }
}
