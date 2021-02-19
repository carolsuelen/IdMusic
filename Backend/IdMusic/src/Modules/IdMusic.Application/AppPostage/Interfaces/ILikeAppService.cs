using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdMusic.Application.AppPostage.Interfaces
{
  public interface ILikeAppService
  {
    Task InsertAsync(int postageId);
    Task<int> GetQuantityOfLikeByPostageIdAsync(int postageId);
  }
}
