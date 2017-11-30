using StartWars.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartWars.Services.Navigation;
using System.Collections.ObjectModel;
using StartWars.Models.Menu;
using StartWars.Data;
using StartWars.Services.Rest;
using StartWars.Pages;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace StartWars.ViewModels.Pages
{
    public class FilmsPageViewModel : BaseViewModel
    {
        protected readonly IRestService _restService;
        private ObservableCollection<FilmMenuItem> _Items = new ObservableCollection<FilmMenuItem>();
        public ObservableCollection<FilmMenuItem> Items
        {
            get { return _Items; }
            set { Set(() => Items, ref _Items, value); }
        }
        private FilmMenuItem _SelectedItem;
        public FilmMenuItem SelectedItem
        {
            get { return _SelectedItem; }
            set { Set(() => SelectedItem, ref _SelectedItem, value); }
        }
        public ICommand ItemSelectedCommand { get; set; }
        public FilmsPageViewModel(IViewNavigationService navigationService, IRestService restService) : base(navigationService)
        {
            _restService = restService;
            this.Title = "Films";
            Loaute();
            ItemSelectedCommand = new RelayCommand(ItemSelectedMethod);

        }
        private  void Loaute()
        {
          
          var results= _restService.RefreshDataByFilmAsync().Result;

            foreach (var item in results.results)
            {
                Items.Add(new FilmMenuItem(item.episode_id, item.title, item.episode_id.ToString()));
            }
        }

        private void ItemSelectedMethod()
        {
            var test = SelectedItem;
             _navigationService.NavigateTo(ViewModelLocator.DetailsPage);
        }
    }
}
