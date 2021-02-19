using IdMusic.Application.AppClient.input;
using IdMusic.Application.AppClient.interfaces;
using Microsoft.AspNetCore.Authorization;
using IdMusic.Domain.Entities;
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

    [AllowAnonymous]
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
      var client = await _clientAppService
                          .GetByIdAsync(id)
                          .ConfigureAwait(false);

      if (client is null)
        return NotFound();

      return Ok(client);
    }
    [Authorize]
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody]  ClientInput clientInput)
    {
      try
      {

        var client = await _clientAppService
                               .UpdateAsync(id, clientInput)
                               .ConfigureAwait(false);

        return Accepted(client);
      }
      catch (ArgumentException arg)
      {
        return BadRequest(arg.Message);
      }
      catch (Exception ex)
      {
        return NotFound(ex.Message);
      }
    }
    [Authorize]
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      try
      {
        await _clientAppService
                         .DeleteAsync(id)
                         .ConfigureAwait(false);
        return Ok();
      }
      catch (Exception ex)
      {
        return NotFound(ex.Message);
      }
      
    }

  }
}
