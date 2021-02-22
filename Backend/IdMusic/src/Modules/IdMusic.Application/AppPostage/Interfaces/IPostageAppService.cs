using IdMusic.Application.AppPostage.Input;
using IdMusic.Domain.Entities;
using IdMusic.Domain.Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdMusic.Application.AppPostage.Interfaces
{
  public interface IPostageAppService
  {
    Task<Postage> InsertAsync(PostageInput input);
    Task<List<Postage>> GetPostageByClientIdAsync(int id);
    Task<Postage> UpdateAsync(int id, PostageInput postageInput);
    Task DeleteAsync(int id);
  }
}
