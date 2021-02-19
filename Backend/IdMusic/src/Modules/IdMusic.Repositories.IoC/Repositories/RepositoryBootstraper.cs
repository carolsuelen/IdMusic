using IdMusic.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IdMusic.Repositories.IoC.Repositories
{
  internal class RepositoryBootstraper
  {
    internal void ChildServiceRegister(IServiceCollection services)
    {
      services.AddScoped<IClientRepository, ClientRepository>();
      services.AddScoped<IGenreRepository, GenreRepository>();
      services.AddScoped<IPostageRepository, PostageRepository>();
    }
  }
}
