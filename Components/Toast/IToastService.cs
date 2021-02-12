using System.Threading.Tasks;

namespace Components.Toast
{
    public interface IToastService
    {
        Task<ToastState> GetToastStateAsync();
    }
}
