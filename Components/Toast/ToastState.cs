using System;
using System.Collections.Generic;
using System.Linq;

namespace Components.Toast
{
    public class ToastState
    {
        private readonly IList<IToastNotificationHandler> notification = new List<IToastNotificationHandler>();

        public ToastState()
        {
            NotificationHandler = new Notifications();
        }

        public event EventHandler<ToastChangedEventArgs> OnToastChanged;
        public event EventHandler<ToastChangedEventArgs> OnToastReceived;
        public event EventHandler<ToastChangedEventArgs> OnToastListCleared;
        public event EventHandler<ToastNotificationAcknowledged> OnToastAcknowledged;

        public IToastNotificationHandler NotificationHandler { get; }
        public IEnumerable<IToastNotification> TenantNotifications { get; private set; }

        public void AddNotification(IToastNotification notification)
        {
            if (!NotificationHandler.ToastNotifications.Contains(notification))
            {
                NotificationHandler.AddNotification(notification);
                OnToastReceived?.Invoke(this, new ToastChangedEventArgs(notification));

                OnToastChanged?.Invoke(this, new ToastChangedEventArgs());
            }
        }

        public void ClearNotifications()
        {
            NotificationHandler.ClearNotifications();
            OnToastListCleared?.Invoke(this, new ToastChangedEventArgs());
            OnToastChanged?.Invoke(this, new ToastChangedEventArgs());
        }

        public void AcknowledgeMessage(string Id)
        {
            NotificationHandler.RemoveNotification(Id);
            OnToastAcknowledged?.Invoke(this, new ToastNotificationAcknowledged(Id));
            OnToastChanged?.Invoke(this, new ToastChangedEventArgs());
        }        
    }
}
