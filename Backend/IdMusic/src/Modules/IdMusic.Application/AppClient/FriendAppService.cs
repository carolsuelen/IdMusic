using IdMusic.Application.AppClient.input;
using IdMusic.Application.AppClient.interfaces;
using IdMusic.Domain.Core.interfaces;
using IdMusic.Domain.Entities;
using IdMusic.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdMusic.Application.AppClient
{
  public class FriendAppService : IFriendAppService
  {
    private readonly IFriendRepository _friendRepository;
    private readonly ILogged _logged;
    public FriendAppService(IFriendRepository friendRepository,
                              ILogged logged)
    {
      _friendRepository = friendRepository;
      _logged = logged;
    }
    public async Task<List<Friends>> GetByFriendIdAsync(int friendId)
    {
      var friends = await _friendRepository
                              .GetByFriendIdAsync(friendId)
                              .ConfigureAwait(false);

      return friends;
    }

    public async Task<Friends> InsertAsync(int friendId, FriendInput input)
    {
      var clientId = _logged.GetClientLoggedId();

      var friend = new Friends(clientId, friendId);

      //Validar os dados obrigatorios

      var id = await _friendRepository
                        .InsertAsync(friend)
                        .ConfigureAwait(false);

      friend.SetId(id);

      return friend;
    }
    public async Task<int> GetQuantityOfFriendByIdAsync(int clientId)
    {
      return await _friendRepository
                      .GetQuantityOfFriendByIdAsync(clientId)
                      .ConfigureAwait(false);
    }
    public async Task DeleteAsync(int id)
    {

      var user = await _friendRepository
                         .GetFriendIdAsync(id)
                         .ConfigureAwait(false);
      if (user is null)
      {
        throw new Exception("Amigo não encontrado");
      }

      await _friendRepository
        .DeleteAsync(id)
        .ConfigureAwait(false);
    }
  }
}
