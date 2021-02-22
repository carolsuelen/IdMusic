using IdMusic.Application.AppClient.output;
using System.Threading.Tasks;

namespace IdMusic.Application.AppClient.interfaces
{
    public interface ILoginAppService
    {
        Task<ClientViewModel> LoginAsync(string login, string password);
    }
}
