using IdMusic.Domain.Entities;
using System.Threading.Tasks;

namespace IdMusic.Domain.Interfaces
{
  public interface ILikeRepository
  {
    Task<int> InsertAsync(Like like);
    Task DeleteAsync(int id);
    Task<int> GetQuantityOfLikeByPostageIdAsync(int postageId);
    Task<Like> GetByClientIdAndPostageIdAsync(int clientId, int postageId);
  }
}
