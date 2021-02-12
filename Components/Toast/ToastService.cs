using System.Threading.Tasks;

namespace Components.Toast
{
    public class ToastService : IToastService
    {
        private readonly ToastState State;

        public ToastService(ToastState State)
        {
            this.State = State;
        }

        public Task<ToastState> GetToastStateAsync()
        {
            return Task.FromResult(State);
        }
    }
}
