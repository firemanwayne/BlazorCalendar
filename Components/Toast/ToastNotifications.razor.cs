using Components.Abstract;
using System;
using System.ComponentModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Components.Toast
{
    public class ToastNotificationsBase : AuthorizedComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (CurrentUser == null)
                    await GetAuthenticatedUser();

                ToastState.OnToastReceived += State_OnNotificationReceived;
                ToastState.OnToastListCleared += State_OnNotificationListCleared;
                ToastState.OnToastAcknowledged += State_OnToastAcknowledged;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void OnMessageAcknowledged(string MessageId)
        {
            ToastState.AcknowledgeMessage(MessageId);
        }

        private async void Model_PropertyChanged(object sender, PropertyChangedEventArgs e) => await StateChanged();
        private async void State_OnToastAcknowledged(object sender, ToastNotificationAcknowledged e)
        {
            await StateChanged();
        }
        private async void State_OnNotificationListCleared(object sender, ToastChangedEventArgs e)
        {
            await StateChanged();
        }
        private async void State_OnNotificationReceived(object sender, ToastChangedEventArgs e)
        {
            if (e.Notification != null || !string.IsNullOrEmpty(e.Notification.UserId))
            {
                var UserId = CurrentUser.FindFirstValue(ClaimTypes.NameIdentifier);

                if (!string.IsNullOrEmpty(e.Notification.UserId) && e.Notification.UserId.Equals(UserId))
                    await StateChanged();
            }
        }
        private async Task StateChanged() => await InvokeAsync(() => StateHasChanged());
    }
}