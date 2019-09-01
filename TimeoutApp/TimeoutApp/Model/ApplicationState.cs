using System;
using System.Timers;
using Xamarin.Forms;
using TimeoutApp.Model;
using TimeoutApp.Model.Event;

[assembly: Dependency(typeof(ApplicationState))]
namespace TimeoutApp.Model
{
    public class ApplicationState
    {
        public event EventHandler WorkStartChanged;

        private DateTime _workStart;

        public DateTime WorkStart
        {
            get => _workStart;
            set
            {
                _workStart = value;
                WorkStartChanged?.Invoke(this, new WorkStartChangeEventArgs { WorkStart = value });
            }
        }

        public Timer Timer { get; set; }

        public TimeSpan GetBreakDuration()
        {
            var worked = DateTime.Now - WorkStart;

            var breakDuration = 5;
            if (TimeSpan.FromMinutes(30) < worked && worked < TimeSpan.FromMinutes(40))
            {
                breakDuration = 7;
            }
            if (TimeSpan.FromMinutes(40) < worked && worked < TimeSpan.FromMinutes(60))
            {
                breakDuration = 10;
            }
            if (TimeSpan.FromMinutes(60) < worked && worked < TimeSpan.FromMinutes(90))
            {
                breakDuration = 12;
            }
            if (TimeSpan.FromMinutes(90) < worked)
            {
                breakDuration = 15;
            }
            
            return TimeSpan.FromSeconds(breakDuration);
        }
    }
}