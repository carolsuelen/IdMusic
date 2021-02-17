using IdMusic.Api.Comum;
using IdMusic.Application.AppClient.input;
using IdMusic.Application.AppClient.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdMusic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginAppService _loginAppService;
        private readonly IConfiguration _configuration;
        public LoginController(ILoginAppService loginAppService,
                                IConfiguration configuration)
        {
            _loginAppService = loginAppService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<object> Post([FromBody] LoginInput input)
        {
            try
            {
                var logged = await _loginAppService
                                    .LoginAsync(input.Login, input.Password)
                                    .ConfigureAwait(false);

                if (logged != null)
                {
                    var token = TokenService.GenerateToken(logged, _configuration.GetSection("Secrets").Value);

                    return new
                    {
                        authenticated = true,
                        accessToken = token,
                        message = "OK"
                    };
                }

                return Unauthorized("Sem permissão");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message + " " + ex.InnerException);
            }
        }
    }
}
