using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Components.Toast
{
    public class Notifications : IToastNotificationHandler, INotifyPropertyChanged
    {
        private readonly IDictionary<string, IToastNotification> notifications = new Dictionary<string, IToastNotification>();

        public Notifications()
        { }        

        public string Message { get; }
        public string NavigateTo { get; }
        public bool IsActive { get; }
        public DateTime Raised { get; private set; }

        public IEnumerable<IToastNotification> ToastNotifications { get => notifications.Values; }
        public void AddNotification(IToastNotification n)
        {
            if (!ToastNotifications.Contains(n))
            {
                if (!string.IsNullOrEmpty(n.UserId))
                    notifications.TryAdd(n.Id, n);

                OnPropertyChanged();

                ToastChanged(n);
            }
        }
        public void RemoveNotification(string Id)
        {
            var n = ToastNotifications.FirstOrDefault(e => e.Id.Equals(Id));

            if (n != null)
            {
                notifications.Remove(Id);
                ToastChanged();
                OnPropertyChanged();
            }
        }
        public void ClearNotifications()
        {
            notifications.Clear();

            OnPropertyChanged();
            ToastChanged();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        protected virtual void ToastChanged(IToastNotification n = null)
        {
            if (n != null)
                OnToastReceived?.Invoke(this, new ToastChangedEventArgs(n));

            OnToastChanged?.Invoke(this, new ToastChangedEventArgs());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event ToastChangedEventHandler OnToastChanged;
        public event ToastChangedEventHandler OnToastReceived;
    }
}
