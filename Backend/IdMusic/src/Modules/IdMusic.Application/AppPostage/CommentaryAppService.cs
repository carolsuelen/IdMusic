using IdMusic.Application.AppPostage.Input;
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
  public class CommentaryAppService : ICommentaryAppService
  {
    private readonly ICommentaryRepository _commentaryRepository;
    private readonly ILogged _logged;
    public CommentaryAppService(ICommentaryRepository commentaryRepository,
                              ILogged logged)
    {
      _commentaryRepository = commentaryRepository;
      _logged = logged;
    }
    public async Task<List<Commentary>> GetByPostageIdAsync(int postageId)
    {
      var comments = await _commentaryRepository
                              .GetByPostageIdAsync(postageId)
                              .ConfigureAwait(false);

      return comments;
    }

    public async Task<Commentary> InsertAsync(int postageId, CommentaryInput input)
    {
      var userId = _logged.GetClientLoggedId();

      var comment = new Commentary(postageId, userId, input.Text);

      //Validar os dados obrigatorios

      var id = await _commentaryRepository
                        .InsertAsync(comment)
                        .ConfigureAwait(false);

      comment.SetId(id);

      return comment;
    }
    public async Task DeleteAsync(int id)
    {

      var user = await _commentaryRepository
                         .GetCommentaryIdAsync(id)
                         .ConfigureAwait(false);
      if (user is null)
      {
        throw new Exception("Comentário não encontrada");
      }

      await _commentaryRepository
        .DeleteAsync(id)
        .ConfigureAwait(false);
    }
  }
}
