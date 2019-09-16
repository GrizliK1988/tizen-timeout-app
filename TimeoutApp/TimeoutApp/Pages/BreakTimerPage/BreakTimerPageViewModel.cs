using System;
using System.ComponentModel;
using System.Timers;
using TimeoutApp.Model;
using Xamarin.Forms;

namespace TimeoutApp.Pages.BreakTimerPage
{
    public class BreakTimerPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ApplicationState _applicationState;

        public BreakTimerPageViewModel()
        {
            _applicationState = DependencyService.Get<ApplicationState>();
            _applicationState.Timer.Elapsed += TimeElapsed;

            TimeElapsed();
        }

        ~BreakTimerPageViewModel()
        {
            _applicationState.Timer.Elapsed -= TimeElapsed;
        }

        private TimeSpan _restOfBreak;

        public string RestOfBreakFormatted
        {
            get
            {
                return $"{_restOfBreak.Minutes:00}:{_restOfBreak.Seconds:00}";
            }
        }

        public float RestOfBreakNormalized
        {
            get
            {
                return ((float)_restOfBreak.Seconds)/((float)_applicationState.BreakDuration.Seconds);
            }
        }

        private void TimeElapsed(object sender, ElapsedEventArgs e)
        {
            TimeElapsed();
        }

        private void TimeElapsed()
        {
            if (_applicationState.BreakDuration >= DateTime.Now - _applicationState.BreakStart) {
                _restOfBreak = _applicationState.BreakDuration - (DateTime.Now - _applicationState.BreakStart);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RestOfBreakFormatted"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RestOfBreakNormalized"));
            }
        }
    }
}