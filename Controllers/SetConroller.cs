using System;
using System.Collections.Generic;
using bricks.Repositories;
using bricks.Models;
using Microsoft.AspNetCore.Mvc;

namespace bricks.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SetsController : ControllerBase
  {
    private readonly SetRepository _sr;
    public SetsController(SetRepository sr)
    {
      _sr = sr;
    }
    //GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Set>> Get()
    {
      try
      {
        return Ok(_sr.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }


    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Set> Get(int id)
    {
      try
      {
        return Ok(_sr.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    //GET api/sets/:id/bricks
    [HttpGet("{id}/bricks")]
    public ActionResult<IEnumerable<Brick>> GetBricksBySet(int id)
    {
      try
      {
        return Ok(_sr.GetBricks(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    //POST api/sets/:id/bricks
    [HttpPost("{id}/bricks")]
    public ActionResult<String> AddBrickToSet(int id, [FromBody] BrickSet brickSet)
    {
      try
      {
        brickSet.SetId = id;
        return Ok(_sr.AddBrickToSet(brickSet));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // POST api/values
    [HttpPost]
    public ActionResult<IEnumerable<Set>> Post([FromBody] Set data)
    {
      try
      {
        return Ok(_sr.Create(data));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Set> Put(int id, [FromBody] Set data)
    {
      try
      {
        data.Id = id;
        return Ok(_sr.Update(data));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<Set> Delete(int id)
    {
      try
      {
        return Ok(_sr.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}
