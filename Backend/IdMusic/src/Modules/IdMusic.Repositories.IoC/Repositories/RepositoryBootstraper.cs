using IdMusic.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IdMusic.Repositories.IoC.Repositories
{
  internal class RepositoryBootstraper
  {
    internal void ChildServiceRegister(IServiceCollection services)
    {
      services.AddSingleton<IClientRepository, ClientRepository>();
      services.AddSingleton<IGenreRepository, GenreRepository>();
    }
  }
}
