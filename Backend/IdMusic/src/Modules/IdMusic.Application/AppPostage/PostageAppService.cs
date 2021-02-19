using IdMusic.Application.AppPostage.Interfaces;
using IdMusic.Domain.Core;
using IdMusic.Domain.Entities;
using IdMusic.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IdMusic.Application.AppPostage.Input;
using IdMusic.Domain.Core.interfaces;
using IdMusic.Domain.Entities.ValueObject;

namespace IdMusic.Application.AppPostage
{
  public class PostageAppService : IPostageAppService
  {
    private readonly IPostageRepository _postageRepository;
    private readonly ILogged _logged;
    public PostageAppService(IPostageRepository postageRepository,
                              ILogged logged)
    {
      _postageRepository = postageRepository;
      _logged = logged;
    }

    public async Task<List<Postage>> GetPostageByClientIdAsync()
    {
      var clientId = _logged.GetClientLoggedId();

      var postages = await _postageRepository
                              .GetPostageByClientIdAsync(clientId)
                              .ConfigureAwait(false);
      return postages;
    }

    public async Task<Postage> InsertAsync(PostageInput input)
    {
      var clientId = _logged.GetClientLoggedId();

      var postage = new Postage(input.Text, clientId);

      //Validar classe com dados obrigatorios..

      var id = await _postageRepository
                       .InsertAsync(postage)
                       .ConfigureAwait(false);

      postage.SetId(id);

      return postage;
    }

    public async Task<Postage> UpdateAsync(int id, PostageInput postageInput)
    {
      var postage = await _postageRepository
                               .GetPostageByIdAsync(id)
                               .ConfigureAwait(false);
      if (postage is null)
      {
        throw new Exception("Postagem não encontrada");
      }

      postage.UpdateInfo(postageInput.Text,
                         postageInput.Photo,
                         postageInput.Video);

      await _postageRepository
        .UpdateAsync(id, postage)
        .ConfigureAwait(false);

      return new Postage(postage.Text, postage.ClientId);
    }

    public async Task DeleteAsync(int id)
    {

      var user = await _postageRepository
                         .GetPostageByClientIdAsync(id)
                         .ConfigureAwait(false);
      if (user is null)
      {
        throw new Exception("Postagem não encontrada");
      }

      await _postageRepository
        .DeleteAsync(id)
        .ConfigureAwait(false);
    }





  }
}
