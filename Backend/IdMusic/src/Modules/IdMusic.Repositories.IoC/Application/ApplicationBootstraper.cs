using IdMusic.Application.AppClient;
using IdMusic.Application.AppClient.interfaces;
using IdMusic.Application.AppPostage;
using IdMusic.Application.AppPostage.Interfaces;
using IdMusic.Domain.Core;
using IdMusic.Domain.Core.interfaces;
using Microsoft.AspNetCore.Http;
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
      services.AddScoped<ILogged, Logged>();
      services.AddScoped<IStorageHelper, StorageHelper>();
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

      services.AddScoped<IClientAppService, ClientAppService>();
      services.AddScoped<ILoginAppService, LoginAppService>();
      services.AddScoped<IPostageAppService, PostageAppService>();
      services.AddScoped<IFriendAppService, FriendAppService>();
      services.AddScoped<ILikeAppService, LikeAppService>();
      services.AddScoped<ICommentaryAppService, CommentaryAppService>();

    }
    }
}
