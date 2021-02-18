using IdMusic.Application.AppClient.input;
using IdMusic.Application.AppClient.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdMusic.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClientController : ControllerBase
  {

    private readonly IClientAppService _clientAppService;

    public ClientController(IClientAppService clientAppService)
    {
      _clientAppService = clientAppService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClientInput clientInput)
      {
      try
      { 
       var client = await _clientAppService
                              .InsertAsync(clientInput)
                              .ConfigureAwait(false);

      return Created("", client);
      }     
      catch(ArgumentException arg)
      {
        return BadRequest(arg.Message);
      }
      }
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
      var user = await _clientAppService
                          .GetByIdAsync(id)
                          .ConfigureAwait(false);

      if (user is null)
        return NotFound();

      return Ok(user);
    }
  }
}
