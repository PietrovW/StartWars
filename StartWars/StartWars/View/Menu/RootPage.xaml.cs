using Xamarin.Forms;


namespace StartWars.View.Menu
{
   // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            InitializeComponent();
            //this.BindingContext = App.ViewModelLocator.RootPageViewModel;
            MasterBehavior = MasterBehavior.Popover;
        }
    }
}