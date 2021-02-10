using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Route("api/{controller}")]
  [ApiController]
  public class ActivitiesController : BaseApiController
  {
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> List()
    {
      return await Mediator.Send(new List.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> Details(Guid id)
    {
      return await Mediator.Send(new Details.Query { Id = id });
    }

    [HttpPost]
    public async Task<IActionResult> Create(Activity activity)
    {
      return Ok(await Mediator.Send(new Create.Command { Activity = activity }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(Guid Id, Activity activity)
    {
      activity.Id = Id;
      return Ok(await Mediator.Send(new Edit.Command { Activity = activity }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
      return Ok(await Mediator.Send(new Delete.Command { Id = id }));
    }
  }
}