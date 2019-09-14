using System;
using System.ComponentModel;
using System.Timers;
using TimeoutApp.Model;
using Xamarin.Forms;

namespace TimeoutApp.Pages.WorkDurationPage
{
    public class WorkDurationPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private TimeSpan _worked;

        private readonly ApplicationState _applicationState;

        public WorkDurationPageViewModel()
        {
            _applicationState = DependencyService.Get<ApplicationState>();
            _applicationState.Timer.Elapsed += TimeElapsed;

            TimeElapsed();
        }

        ~WorkDurationPageViewModel()
        {
            _applicationState.Timer.Elapsed -= TimeElapsed;
        }

        public TimeSpan Worked
        {
            set
            {
                if (_worked != value)
                {
                    _worked = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Worked"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WorkedFormatted"));
                }
            }
            get => _worked;
        }

        public string WorkedFormatted
        {
            get {
                return $"Worked {Worked.Hours:00}:{Worked.Minutes:00}:{Worked.Seconds:00}";
            }
        }

        private void TimeElapsed(object sender, ElapsedEventArgs e)
        {
            TimeElapsed();
        }

        private void TimeElapsed()
        {
            Worked = DateTime.Now - _applicationState.WorkStart;
        }
    }
}