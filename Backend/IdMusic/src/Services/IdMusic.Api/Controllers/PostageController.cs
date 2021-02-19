using IdMusic.Application.AppPostage;
using IdMusic.Application.AppPostage.Input;
using IdMusic.Application.AppPostage.Interfaces;
using IdMusic.Domain.Entities;
using IdMusic.Domain.Entities.ValueObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdMusic.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PostageController : ControllerBase
  {
    private readonly IPostageAppService _postageAppService;
    //private readonly ICommentaryAppService _commentaryAppService;
    //private readonly ILikesAppService _likesAppService;
    public PostageController(IPostageAppService postageAppService)
    //ICommentaryAppService commentaryAppService,
    //ILikesAppService likesAppService)
    {
      _postageAppService = postageAppService;
      //_commentaryAppService = commentaryAppService;
      //_likesAppService = likesAppService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostageInput postageInput)
    {
      try
      {
        var postage = await _postageAppService
                            .InsertAsync(postageInput)
                            .ConfigureAwait(false);

        return Created("", postage);
      }
      catch (ArgumentException arg)
      {
        return BadRequest(arg.Message);
      }
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var postages = await _postageAppService
                              .GetPostageByClientIdAsync()
                              .ConfigureAwait(false);

      if (postages is null)
        return NoContent();

      return Ok(postages);
    }

    //[Authorize]
    //[HttpPost]
    //[Route("{id}/Comments")]
    //public async Task<IActionResult> PostCommets([FromRoute] int id, [FromBody] CommentaryInput commentaryInput)
    //{
    //  try
    //  {
    //    var client = await _commentaryAppService
    //                        .InsertAsync(id, commentaryInput)
    //                        .ConfigureAwait(false);

    //    return Created("", client);
    //  }
    //  catch (ArgumentException arg)
    //  {
    //    return BadRequest(arg.Message);
    //  }
    //}

    //[Authorize]
    //[HttpGet]
    //[Route("{id}/Comments")]
    //public async Task<IActionResult> GetCommentaries([FromRoute] int id)
    //{
    //  var commentaries = await _commentaryAppService
    //                          .GetByPostageIdAsync(id)
    //                          .ConfigureAwait(false);

    //  if (commentaries is null)
    //    return NoContent();

    //  return Ok(commentaries);
    //}

    //[Authorize]
    //[HttpPost]
    //[Route("{id}/Likes")]
    //  public async Task<IActionResult> PostLike([FromRoute] int id)
    //  {
    //    try
    //    {
    //      await _likesAppService
    //                  .InsertAsync(id)
    //                  .ConfigureAwait(false);

    //      return Created("", "");
    //    }
    //    catch (ArgumentException arg)
    //    {
    //      return BadRequest(arg.Message);
    //    }
    //  }

    //  [Authorize]
    //  [HttpGet]
    //  [Route("{id}/Likes/Quantity")]
    //  public async Task<IActionResult> GetLike([FromRoute] int id)
    //  {
    //    try
    //    {
    //      var quantity = await _likeAppService
    //                              .GetQuantityOfLikesByPostageIdAsync(id)
    //                              .ConfigureAwait(false);

    //      return Ok(quantity);
    //    }
    //    catch (ArgumentException arg)
    //    {
    //      return BadRequest(arg.Message);
    //    }
    //  }

    [Authorize]
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] PostageInput postageInput)
    {
      try
      {

        await _postageAppService
                               .UpdateAsync(id, postageInput)
                               .ConfigureAwait(false);

        return Accepted(postageInput);
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
        await _postageAppService
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

