using Microsoft.AspNetCore.Components;

namespace Components.Toast
{
    public class ToastNotificationCardBase : ComponentBase
    {
        [Inject]
        public NavigationManager Navigate { get; set; }

        [Parameter]
        public IToastNotification Notification { get; set; }

        [Parameter]
        public EventCallback OnMessageAcknowledged { get; set; }

        protected void OnNavigateToPage(string NavigateToPage) => Navigate.NavigateTo(NavigateToPage);
    }
}
