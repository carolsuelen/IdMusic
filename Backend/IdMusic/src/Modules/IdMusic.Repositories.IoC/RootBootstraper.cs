using IdMusic.Repositories.IoC.Application;
using IdMusic.Repositories.IoC.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace IdMusic.Repositories.IoC
{
    public class RootBootstraper
    {
    public void RootRegisterServices(IServiceCollection services)
    {
      new ApplicationBootstraper().ChildServiceRegister(services);
      new RepositoryBootstraper().ChildServiceRegister(services);
    }
  }
}
