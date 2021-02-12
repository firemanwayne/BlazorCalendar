using Components.Toast;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Components.Abstract
{
    [Authorize]
    public abstract class AuthorizedComponentBase : ComponentBase, IDisposable
    {
        [Inject] public IHttpClientFactory Factory { get; set; }
        [Inject] protected ToastState ToastState { get; set; }
        [Inject] protected NavigationManager Navigate { get; set; }
        [Parameter] public Func<string> BackHref { get; set; }

        protected ClaimsPrincipal CurrentUser { get; private set; }
        protected string CurrentUserId { get; private set; }

        protected bool IsFaulted { get; set; }
        protected string FaultedContent { get; set; }
        protected IList<string> ErrorMessages { get; } = new List<string>();

        protected Task GetAuthenticatedUser()
        {
            try
            {
                               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                AddErrorMessage(ex.Message);
            }

            return Task.CompletedTask;
        }
        protected virtual void AddErrorMessage(string Message)
        {
            ErrorMessages.Add(Message);
            StateHasChanged();
        }
        protected virtual void DeleteMessage(object Message)
        {
            ErrorMessages.Remove((string)Message);
            StateHasChanged();
        }
        protected virtual void AddToast(IToastNotification Toast) => ToastState.AddNotification(Toast);
        
        
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public abstract class AuthorizedComponentBase<T> : AuthorizedComponentBase where T : INotifyPropertyChanged
    {
        [Parameter]
        public virtual T Model { get; set; }
    }
}
