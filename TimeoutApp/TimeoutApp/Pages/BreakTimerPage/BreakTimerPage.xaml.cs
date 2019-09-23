using System;
using TimeoutApp.Model;
using Tizen.Wearable.CircularUI.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeoutApp.Pages.BreakTimerPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BreakTimerPage : CirclePage
    {
        public BreakTimerPage()
        {
            InitializeComponent();
        }

        async private void OnBreakClicked(object sender, EventArgs e)
        {
            var appState = DependencyService.Get<ApplicationState>();        
            appState.EndBreak();
            appState.WorkStart = DateTime.Now;

            await Navigation.PopAsync();
        }
    }
}