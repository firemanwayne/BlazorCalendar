namespace Components.Toast
{
    public class ToastChangedEventArgs
    {
        public IToastNotification Notification { get; }

        public ToastChangedEventArgs(IToastNotification Notification = null)
        {
            if (Notification != null)
                this.Notification = Notification;
        }
    }
}
