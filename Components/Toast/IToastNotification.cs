using System;

namespace Components.Toast
{
    public delegate void ToastChangedEventHandler(object o, ToastChangedEventArgs args);

    public interface IToastNotification
    {
        string Id { get; }
        string UserId { get; }
        string Message { get; }
        string NavigateTo { get; }
        bool IsActive { get; }
        DateTime Raised { get; }
        string NotificationColor { get; }
        string TextColorValue { get; }
        string ShowToast { get; }
        string MutedTextValue { get; }
        ToastNotificationType NotificationType { get; set; }
    }
}
