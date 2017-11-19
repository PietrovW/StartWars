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
        private Film _SelectedItem;
        public Film SelectedItem
        {
            get { return _SelectedItem; }
            set { Set(() => SelectedItem, ref _SelectedItem, value); }
        }

        public FilmsPageViewModel(IViewNavigationService navigationService, IRestService restService) : base(navigationService)
        {
            _restService = restService;
            this.Title = "Films";
            Loaute();


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
        }
    }
}
