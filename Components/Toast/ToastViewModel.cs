using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Components.Toast
{
    public class ToastViewModels : INotifyPropertyChanged
    {
        public ToastViewModels() { }

        public event PropertyChangedEventHandler PropertyChanged;
        public IList<ToastViewModel> ViewModels { get; } = new List<ToastViewModel>();

        public void Clear()
        {
            ViewModels.Clear();
            OnPropertyChanged();
        }
        public void AcknowledgeMessage(string MessageId)
        {
            var Notification = ViewModels.FirstOrDefault(e => e.MessageId.Equals(MessageId));
            Notification.AcknowledgeMessage();

            if (ViewModels.Contains(Notification))
                ViewModels.Remove(Notification);

            OnPropertyChanged();
        }
        public void UpdateNotification(ToastNotification Model)
        {
            var model = ViewModels.FirstOrDefault(e => e.MessageId.Equals(Model.Id));

            if (model != null)
                model = new ToastViewModel(Model);

            OnPropertyChanged();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }

    public class ToastViewModel : INotifyPropertyChanged
    {
        private bool isActive;
        private string showToast;
        private string mutedTextValue;

        public event PropertyChangedEventHandler PropertyChanged;

        public ToastViewModel() { }
        public ToastViewModel(ToastNotification Model)
        {
            isActive = Model.IsActive;

            Message = Model.Message;
            MessageId = Model.Id;
            NavigateToPage = Model.NavigateTo;
            NotificationType = Model.NotificationType;
            ShowToast = Model.IsActive ? "show" : "";

            NotificationColor = Model.NotificationColor;
        }

        public bool IsActive
        {
            get => isActive;
            private set
            {
                isActive = value;
                OnPropertyChanged();
            }
        }
        public string MutedTextValue
        {
            get => mutedTextValue;
            private set
            {
                mutedTextValue = value;
                OnPropertyChanged();
            }
        }
        public string ShowToast
        {
            get => showToast;
            private set
            {
                showToast = value;
                OnPropertyChanged();
            }
        }
        public string Message { get; }
        public string MessageId { get; }
        public string NavigateToPage { get; }
        public ToastNotificationType NotificationType { get; }
        public string NotificationColor { get; }
        public void AcknowledgeMessage()
        {
            IsActive = false;
            MutedTextValue = "text-muted";
            ShowToast = "";
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
