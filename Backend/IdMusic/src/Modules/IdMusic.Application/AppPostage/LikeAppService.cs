using IdMusic.Application.AppPostage.Interfaces;
using IdMusic.Domain.Core.interfaces;
using IdMusic.Domain.Entities;
using IdMusic.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdMusic.Application.AppPostage
{
  public class LikeAppService : ILikeAppService
  {
    private readonly ILikeRepository _likeRepository;
    private readonly ILogged _logged;

    public LikeAppService(ILikeRepository likeRepository,
                            ILogged logged)
    {
      _likeRepository = likeRepository;
      _logged = logged;
    }

    public async Task<int> GetQuantityOfLikeByPostageIdAsync(int postageId)
    {
      return await _likeRepository
                      .GetQuantityOfLikeByPostageIdAsync(postageId)
                      .ConfigureAwait(false);
    }

    public async Task InsertAsync(int postageId)
    {
      var clientId = _logged.GetClientLoggedId();

      var likeExistForPostage = await _likeRepository
                                          .GetByClientIdAndPostageIdAsync(clientId, postageId)
                                          .ConfigureAwait(false);
      if (likeExistForPostage != null)
      {
        await _likeRepository
                 .DeleteAsync(likeExistForPostage.Id)
                 .ConfigureAwait(false);
      }

      var like = new Like(postageId, clientId);
      //Validar os dados obriatorios..

      await _likeRepository
              .InsertAsync(like)
              .ConfigureAwait(false);
    }
  }
}
