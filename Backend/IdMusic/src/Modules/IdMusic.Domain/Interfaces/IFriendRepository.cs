using IdMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdMusic.Domain.Interfaces
{
  public interface IFriendRepository
  {
    Task<int> InsertAsync(Friends friends);
    Task<List<Friends>> GetByFriendIdAsync(int friendId);
    Task DeleteAsync(int id);
    Task<int> GetQuantityOfFriendByIdAsync(int friendId);
    Task<Friends> GetFriendIdAsync(int id);
  }
}
