using IdMusic.Application.AppClient.input;
using IdMusic.Application.AppClient.output;
using IdMusic.Domain.Entities;
using System.Threading.Tasks;

namespace IdMusic.Application.AppClient.interfaces
{
  public interface IClientAppService
  {
    Task<ClientViewModel> InsertAsync(ClientInput input);

    Task<ClientViewModel> GetByIdAsync(int Id);
    Task<ClientViewModel> UpdateAsync(ClientInput input);
    Task DeleteAsync(int id);
  }
}
