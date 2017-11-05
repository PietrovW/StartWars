using Xamarin.Forms;

namespace StartWars.View.Menu
{
   // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            this.BindingContext = App.ViewModelLocator.MenuPageViewModel;
        }
    }
}