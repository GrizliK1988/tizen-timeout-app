using System;
using System.ComponentModel;
using TimeoutApp.Model;
using TimeoutApp.Pages.MainPage;
using Xamarin.Forms;

[assembly: Dependency(typeof(MainPageViewModel))]
namespace TimeoutApp.Pages.MainPage
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ApplicationState _applicationState;

        public MainPageViewModel()
        {
            _applicationState = DependencyService.Get<ApplicationState>();
            _applicationState.WorkStartChanged += UpdateButtonText;
        }

        public string ButtonText 
        {
            get => _applicationState.WorkStart > DateTime.MinValue ? "Continue Work" : "Start Work";
        }

        public void UpdateButtonText(object sender, EventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ButtonText"));
        }
    }
}