using System;

namespace TimeoutApp.Model.Event
{
    public class WorkStartChangeEventArgs : EventArgs
    {
        public DateTime WorkStart { get; set; }
    }
}
