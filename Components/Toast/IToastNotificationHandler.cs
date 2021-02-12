using System.Collections.Generic;
using System.ComponentModel;

namespace Components.Toast
{
    public interface IToastNotificationHandler
    {        
        IEnumerable<IToastNotification> ToastNotifications { get; }

        void ClearNotifications();
        void AddNotification(IToastNotification n);
        void RemoveNotification(string Id);
        event PropertyChangedEventHandler PropertyChanged;
        event ToastChangedEventHandler OnToastChanged;
        event ToastChangedEventHandler OnToastReceived;
    }
}
