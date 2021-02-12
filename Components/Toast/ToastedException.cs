using System;

namespace Components.Toast
{
    public abstract class ToastedException<T> : Exception
    {
        protected ToastedException() : base()
        {
            ModelType = typeof(T);
        }

        protected ToastedException(string Message = null, string NavigateToPage = null) : base()
        {
            ModelType = typeof(T);

            if (!string.IsNullOrEmpty(Message))
                this.Message = Message;

            if (!string.IsNullOrEmpty(NavigateToPage))
                HelpLink = NavigateToPage;
        }

        public override string Message { get; }
        public virtual Type ModelType { get; }
        public virtual DateTime OccuredOn { get => DateTime.UtcNow; }
    }
}
