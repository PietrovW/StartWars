using GalaSoft.MvvmLight;
using StartWars.Services.Navigation.Base;
using System.Collections.ObjectModel;

namespace StartWars.ViewModels.Base
{
    public abstract class BaseViewModel : ViewModelBase
    {
        protected readonly INavigationService _navigationService;

        private bool _isLoading;
        private bool _isEnabled;
        private string _title;
        private ObservableCollection<string> _errors;
        public INavigationService NavigationService => _navigationService;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                Set(() => IsLoading, ref _isLoading, value);
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                Set(() => IsEnabled, ref _isEnabled, value);
            }
        }

        public ObservableCollection<string> Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                Set(() => Errors, ref _errors, value);
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                Set(() => Title, ref _title, value);
            }
        }


        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            IsEnabled = true;
            IsLoading = false;
        }

        public override void Cleanup()
        {
            base.Cleanup();
            Errors = null;
        }
    }
}