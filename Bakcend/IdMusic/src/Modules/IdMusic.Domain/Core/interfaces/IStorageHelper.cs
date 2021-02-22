using IdMusic.Domain.Entities.ValueObject;
using System.IO;
using System.Threading.Tasks;

namespace IdMusic.Domain.Core.interfaces
{
  public interface IStorageHelper
  {
    Task<ImageBlob> Upload(Stream stream, string nameFile);
    bool IsImage(string nameFile);
  }
}
