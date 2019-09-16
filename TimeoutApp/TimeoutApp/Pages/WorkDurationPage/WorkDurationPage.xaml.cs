using System;
using TimeoutApp.Model;
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
        }

        async private void OnBreakClicked(object sender, EventArgs e)
        {
            var appState = DependencyService.Get<ApplicationState>();        
            appState.StartBreak();

            await Navigation.PushAsync(new BreakTimerPage.BreakTimerPage());
        }
    }
}