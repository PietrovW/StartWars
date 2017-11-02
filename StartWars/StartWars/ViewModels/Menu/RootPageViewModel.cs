using GalaSoft.MvvmLight;
using StartWars.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartWars.ViewModels.Menu
{
    public class RootPageViewModel: ViewModelBase
    {
        private bool _IsPresented;
        public bool IsPresented
        {
            get { return _IsPresented; }
            set { Set(() => IsPresented, ref _IsPresented, value); }
        }
    }
}
