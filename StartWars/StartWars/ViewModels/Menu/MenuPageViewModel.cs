using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartWars.ViewModels.Base;
using System.Windows.Input;
using StartWars.Services.Navigation.Base;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using StartWars.Models.Menu;
using Xamarin.Forms;

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
       
        public MenuPageViewModel(INavigationService navigationService) :base(navigationService)//RootPageViewModel rootPageViewModel)
        {
           
          //  this.rootPageViewModel = App.Locator.RootPageViewModel;
            ItemSelectedCommand = new RelayCommand(ItemSelectedMethod);

            // NavigationService.
            // foreach(var test in _NavigationService.GetDictionary())
            //{
            //  Items.Add(new MenusItem(test.Key, ImageSource.FromResource("FirstXamarinApp.Home.png")));
            //}
            Items.Add(new NavigationMenuItem("Home", ImageSource.FromResource("FirstXamarinApp.Home.png")));
            Items.Add(new NavigationMenuItem("Page2", ImageSource.FromResource("FirstXamarinApp.Home.png")));
        }

        private async void ItemSelectedMethod()
        {
            if (SelectedItem == Items[0])
            {
             await NavigationService.InsertPageBeforeAsync("MainPage");
                // _NavigationService.NavigateTo(AppPages.MainPage);
                ///var root = App.NavigationPage.Navigation.NavigationStack[0];
                //  App.NavigationPage.Navigation.InsertPageBefore(new MainPage(), root);
                //    await App.NavigationPage.PopToRootAsync(false);
            }
            if (SelectedItem == Items[1])
            {
                await NavigationService.InsertPageBeforeAsync("SecondPage");
                //var root = App.NavigationPage.Navigation.NavigationStack[0];
                // App.NavigationPage.Navigation.InsertPageBefore(new SecondPage(), root);
                // await App.NavigationPage.PopToRootAsync(false);
            }
            rootPageViewModel.IsPresented = false;
        }
    }

}
