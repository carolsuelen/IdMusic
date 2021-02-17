using IdMusic.Application.AppClient;
using IdMusic.Application.AppClient.interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdMusic.Repositories.IoC.Application
{
  internal class ApplicationBootstraper
  {
    internal void ChildServiceRegister(IServiceCollection services)
    {
      services.AddSingleton<IClientAppService, ClientAppService>();
      services.AddScoped<ILoginAppService, LoginAppService>();
    }
    }
}
