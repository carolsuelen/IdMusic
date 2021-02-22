using IdMusic.Domain.Entities;
using IdMusic.Domain.Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdMusic.Domain.Interfaces
{
  public interface IPostageRepository
  {
    Task<int> InsertAsync(Postage postage);
    Task<List<Postage>> GetPostageByClientIdAsync(int clientId);
    Task UpdateAsync(int id, Postage postage);
    Task<Postage> GetPostageByIdAsync(int postageId);
    Task DeleteAsync(int id);

  }
}
