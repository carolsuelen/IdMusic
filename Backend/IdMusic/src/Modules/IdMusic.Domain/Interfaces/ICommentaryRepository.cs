using IdMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdMusic.Domain.Interfaces
{
  public interface ICommentaryRepository
  {
    Task<int> InsertAsync(Commentary commentary);
    Task<List<Commentary>> GetByPostageIdAsync(int postageId);
    Task DeleteAsync(int id);
    Task<Commentary> GetCommentaryIdAsync(int id);
  }
}
