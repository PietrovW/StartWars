using StartWars.ViewModels.Base;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using StartWars.Models.Menu;
using Xamarin.Forms;
using StartWars.Services.Navigation;

namespace StartWars.ViewModels.Menu
{
    public class MenuPageViewModel : BaseViewModel
    {
        private ObservableCollection<NavigationMenuItem> _Items = new ObservableCollection<NavigationMenuItem>();
        public ObservableCollection<NavigationMenuItem> Items
        {
            get { return _Items; }
            set { Set(() => Items, ref _Items, value); }
        }
        private NavigationMenuItem _SelectedItem;
        public NavigationMenuItem SelectedItem
        {
            get { return _SelectedItem; }
            set { Set(() => SelectedItem, ref _SelectedItem, value); }
        }
        public ICommand ItemSelectedCommand { get; set; }
        private RootPageViewModel rootPageViewModel;
       
        public MenuPageViewModel(IViewNavigationService navigationService) :base(navigationService)//RootPageViewModel rootPageViewModel)
        {
          this.rootPageViewModel = App.ViewModelLocator.RootPageViewModel;
            ItemSelectedCommand = new RelayCommand(ItemSelectedMethod);
           
             foreach(var item in _navigationService.GetDictionary())
            {
              Items.Add(new NavigationMenuItem(item.Key, ImageSource.FromResource("StartWars.Home.png")));
            }
        }

        private  void ItemSelectedMethod()
        {
            NavigationService.InsertPageBefore(SelectedItem.Title);
            rootPageViewModel.IsPresented = false;
        }
    }

}
