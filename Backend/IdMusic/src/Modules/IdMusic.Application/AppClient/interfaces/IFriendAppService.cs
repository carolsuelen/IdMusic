using IdMusic.Application.AppClient.input;
using IdMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdMusic.Application.AppClient.interfaces
{
  public interface IFriendAppService
  {
    Task<Friends> InsertAsync(int friendId, FriendInput input);
    Task<List<Friends>> GetByFriendIdAsync(int friendId);
    Task<int> GetQuantityOfFriendByIdAsync(int friendId);
    Task DeleteAsync(int id);

  }
}
