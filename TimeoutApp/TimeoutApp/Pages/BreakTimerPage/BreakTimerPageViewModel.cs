using System;
using System.ComponentModel;
using System.Timers;
using TimeoutApp.Model;
using TimeoutApp.Pages.BreakTimerPage;
using Tizen.System;
using Xamarin.Forms;

[assembly: Dependency(typeof(BreakTimerPageViewModel))]
namespace TimeoutApp.Pages.BreakTimerPage
{
    public class BreakTimerPageViewModel : INotifyPropertyChanged
    {
        public static bool FEEDBACK_PLAYING = false;

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
            _applicationState.Feedback.Stop();
        }

        private TimeSpan _restOfBreak;

        public string RestOfBreakFormatted
        {
            get
            {
                var sign = _restOfBreak.Seconds < 0 ? "-" : "";
                return $"{sign}{Math.Abs(_restOfBreak.Minutes):00}:{Math.Abs(_restOfBreak.Seconds):00}";
            }
        }

        public float RestOfBreakNormalized
        {
            get
            {

                return ((float)_restOfBreak.TotalSeconds)/((float)_applicationState.BreakDuration.TotalSeconds);
            }
        }

        private void TimeElapsed(object sender, ElapsedEventArgs e)
        {
            TimeElapsed();
        }

        private void TimeElapsed()
        {
            var secondsLeft = _applicationState.BreakDuration.TotalSeconds - (DateTime.Now - _applicationState.BreakStart).TotalSeconds;

            _restOfBreak = _applicationState.BreakDuration - (DateTime.Now - _applicationState.BreakStart);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RestOfBreakFormatted"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RestOfBreakNormalized"));

            if (secondsLeft == 0) {
                _applicationState.Feedback.Play(FeedbackType.Vibration, "Timer");
            }
        }
    }
}