using System;
using TimeoutApp.Model;
using Tizen.Wearable.CircularUI.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeoutApp.Pages.MainPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : CirclePage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}
		
		async private void OnWorkClicked(object sender, EventArgs e)
		{
			var appState = DependencyService.Get<ApplicationState>();
			appState.WorkStart = appState.WorkStart > DateTime.MinValue ? appState.WorkStart : DateTime.Now;

			await Navigation.PushAsync(new WorkDurationPage.WorkDurationPage());
		}
	}
}
