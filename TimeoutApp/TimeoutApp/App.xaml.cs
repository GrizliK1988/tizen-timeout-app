using TimeoutApp.Model;
using TimeoutApp.Pages.MainPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeoutApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // var appState = DependencyService.Get<ApplicationState>();
            // appState.Timer?.Stop();
        }

        protected override void OnResume()
        {
            // var appState = DependencyService.Get<ApplicationState>();
            // appState.Timer?.Start();
        }
    }
}

