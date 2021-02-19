using IdMusic.Domain.Core.interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace IdMusic.Domain.Core
{
  public class Logged : ILogged
  {
    private readonly IHttpContextAccessor _accessor;

    public Logged(IHttpContextAccessor accessor)
    {
      _accessor = accessor;
    }

    public int GetClientLoggedId()
    {
      var id = _accessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "jti").Value;

      return int.Parse(id);
    }
  }
}
