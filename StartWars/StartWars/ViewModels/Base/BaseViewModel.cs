using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using StartWars.Services.Navigation;
using System.Collections.ObjectModel;

namespace StartWars.ViewModels.Base
{
    public abstract class BaseViewModel : ViewModelBase
    {
        protected readonly IViewNavigationService _navigationService;

        private bool _isLoading;
        private bool _isEnabled;
        private string _title;
        private ObservableCollection<string> _errors;
        public IViewNavigationService NavigationService => _navigationService;
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


        public BaseViewModel(IViewNavigationService navigationService)
        {
            _navigationService = navigationService;

            IsEnabled = true;
            IsLoading = false;
        }
        private IMessenger _messengerInstance;
        public new IMessenger MessengerInstance
        {
            get
            
               => this._messengerInstance ?? Messenger.Default;
            
            set=>
            
                this._messengerInstance = value;
            
        }

        public override void Cleanup()
        {
            base.Cleanup();
            Errors = null;
        }
    }
}