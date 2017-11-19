using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StartWars.View.Pagets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilmsPage : ContentPage
    {
        public FilmsPage()
        {
            InitializeComponent();
            this.BindingContext = App.ViewModelLocator.FilmsPageViewModel;
        }
    }
}