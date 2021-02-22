using IdMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdMusic.Domain.Interfaces
{
  public interface IGenreRepository
  {

    Task<Genre> GetByIdAsync(int Id);
  }
}
