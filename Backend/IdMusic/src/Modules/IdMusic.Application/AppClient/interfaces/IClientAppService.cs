using IdMusic.Application.AppClient.input;
using IdMusic.Application.AppClient.output;
using System.Threading.Tasks;

namespace IdMusic.Application.AppClient.interfaces
{
  public interface IClientAppService
  {
    Task<ClientViewModel> InsertAsync(ClientInput input);

    Task<ClientViewModel> GetByIdAsync(int Id);
  }
}
