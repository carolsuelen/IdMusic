using IdMusic.Application.AppPostage.Input;
using IdMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdMusic.Application.AppPostage.Interfaces
{
  public interface ICommentaryAppService
  {
    Task<Commentary> InsertAsync(int postageId, CommentaryInput input);
    Task<List<Commentary>> GetByPostageIdAsync(int postageId);
    Task DeleteAsync(int id);

  }
}
