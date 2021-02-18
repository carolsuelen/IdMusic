using IdMusic.Domain.Entities;
using System.Threading.Tasks;

namespace IdMusic.Domain.Interfaces
{
  public interface IClientRepository
  {
    Task<int> InsertAsync(Client client);
    Task<Client> GetByLoginAsync(string login);
    Task<Client> GetByIdAsync(int id);
    Task UpdateAsync(int id, Client client);
    Task DeleteAsync(int id);
  }
}
