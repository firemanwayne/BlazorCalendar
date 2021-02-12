using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Components.Toast
{
    public class ToastNotification : IToastNotification, INotifyPropertyChanged
    {
        private bool isActive;
        private string showToast;
        private string mutedTextValue;

        public ToastNotification(string UserId = null)
        {
            isActive = true;
            showToast = isActive ? "show" : "";
            this.UserId = UserId;
        }
        
        public ToastNotification(ClaimsPrincipal User = null)
        {
            if (User != null && User.Identity.IsAuthenticated)
                UserId = User.FindFirst(a => a.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            isActive = true;
            showToast = isActive ? "show" : "";
        }       

        public string Id { get; } = Guid.NewGuid().ToString();
        public string UserId { get; }
        public DateTime Raised { get; } = DateTime.UtcNow;
        public string Message { get; set; }
        public string NavigateTo { get; set; }

        public ToastNotificationType NotificationType { get; set; }
        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;
                OnPropertyChanged();
            }
        }
        public string NotificationColor
        {
            get => NotificationType.ToCss();
        }
        public string TextColorValue
        {
            get
            {
                return NotificationType switch
                {
                    ToastNotificationType.Error => ToastTextColor.Red.ToCss(),
                    ToastNotificationType.Info => ToastTextColor.Blue.ToCss(),
                    ToastNotificationType.Success => ToastTextColor.Green.ToCss(),
                    ToastNotificationType.Warning => ToastTextColor.Orange.ToCss(),
                    _ => ToastTextColor.Black.ToCss(),
                };
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
        public string MutedTextValue
        {
            get => mutedTextValue;
            private set
            {
                mutedTextValue = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public enum ToastTextColor
    {
        Red,        //Danger
        Blue,       //Primary
        Green,      //Success
        Orange,     //Warning
        Black,      //Dark
        White,      //White      
        LightBlue,  //Info
        Muted,      //Muted
        Dark        //Text = White, Background = Dark
    }
}
