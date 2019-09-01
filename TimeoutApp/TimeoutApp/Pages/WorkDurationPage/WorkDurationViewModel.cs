using System;
using System.ComponentModel;
using System.Timers;
using TimeoutApp.Model;
using Xamarin.Forms;

namespace TimeoutApp.Pages.WorkDurationPage
{
    public class WorkDurationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _worked;

        public WorkDurationViewModel()
        {
            var appState = DependencyService.Get<ApplicationState>();
            
            var timer = new Timer
            {
                Interval = 1000
            };
            timer.Start();
            
            timer.Elapsed += (sender, args) =>
            {
                var worked = DateTime.Now - appState.WorkStart;
                Worked = $"Worked {worked.Hours:00}:{worked.Minutes:00}:{worked.Seconds:00}";
            };
        }

        public string Worked
        {
            set
            {
                if (_worked != value)
                {
                    _worked = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Worked"));
                }
            }
            get => _worked ?? "Worked 00:00:00";
        }
    }
}