using System;
using System.Collections.Generic;
using bricks.Repositories;
using bricks.Models;
using Microsoft.AspNetCore.Mvc;

namespace bricks.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BricksController : ControllerBase
  {
    private readonly BrickRepository _br;
    public BricksController(BrickRepository br)
    {
      _br = br;
    }
    //GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Brick>> Get()
    {
      try
      {
        return Ok(_br.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }


    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Brick> Get(int id)
    {
      try
      {
        return Ok(_br.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // POST api/values
    [HttpPost]
    public ActionResult<IEnumerable<Brick>> Post([FromBody] Brick data)
    {
      try
      {
        return Ok(_br.Create(data));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Brick> Put(int id, [FromBody] Brick data)
    {
      try
      {
        data.Id = id;
        return Ok(_br.Update(data));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<Brick> Delete(int id)
    {
      try
      {
        return Ok(_br.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}
