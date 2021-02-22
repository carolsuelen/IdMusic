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
    private readonly IFriendAppService _friendAppService;
    private readonly ILoginAppService _loginAppService;

    public ClientController(IClientAppService clientAppService,
                            IFriendAppService friendAppService,
                            ILoginAppService loginAppService)
    {
      _clientAppService = clientAppService;
      _friendAppService = friendAppService;
      _loginAppService = loginAppService;
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
    public async Task<IActionResult> Put([FromBody]  ClientInput clientInput)
    {
      try
      {


        var client = await _clientAppService
                                .UpdateAsync(clientInput)
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

    [Authorize]
    [HttpPost]
    [Route("{id}/friends")]
    public async Task<IActionResult> PostFriends([FromRoute] int id, [FromBody] FriendInput friendInput)
    {
      try
      {
        var friend = await _friendAppService
                            .InsertAsync(id, friendInput)
                            .ConfigureAwait(false);

        return Created("", friend);
      }
      catch (ArgumentException arg)
      {
        return BadRequest(arg.Message);
      }
    }

    [Authorize]
    [HttpGet]
    [Route("{id}/friends")]
    public async Task<IActionResult> GetFriends([FromRoute] int id)
    {
      var friends = await _friendAppService
                              .GetByFriendIdAsync(id)
                              .ConfigureAwait(false);

      if (friends is null)
        return NoContent();

      return Ok(friends);
    }
    [Authorize]
    [HttpDelete]
    [Route("{id}/friends")]
    public async Task<IActionResult> Deletefriend([FromRoute] int id)
    {
      try
      {
        await _friendAppService
                         .DeleteAsync(id)
                         .ConfigureAwait(false);
        return Ok();
      }
      catch (Exception ex)
      {
        return NotFound(ex.Message);
      }

    }
    [Authorize]
    [HttpGet]
    [Route("{id}/friends/Quantity")]
    public async Task<IActionResult> GetLike([FromRoute] int id)
    {
      try
      {
        var quantity = await _friendAppService
                                .GetQuantityOfFriendByIdAsync(id)
                                .ConfigureAwait(false);

        return Ok(quantity);
      }
      catch (ArgumentException arg)
      {
        return BadRequest(arg.Message);
      }
    }



  }
}
