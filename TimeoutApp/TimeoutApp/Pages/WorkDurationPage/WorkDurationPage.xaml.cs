using TimeoutApp.Pages.WorkDurationPage;
using Tizen.Wearable.CircularUI.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeoutApp.Pages.WorkDurationPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkDurationPage : CirclePage
    {
        public WorkDurationPage()
        {
            InitializeComponent();

            // var appState = DependencyService.Get<ApplicationState>();
            // StartedAtLabel.Text = $"Started at {appState.WorkStart:HH:mm}";
            
            // WorkedLabel.BindingContext = new WorkDurationViewModel();
            // WorkedLabel.SetBinding(Label.TextProperty, "Worked");
        }
    }
}