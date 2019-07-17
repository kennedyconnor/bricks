using System;
using System.Collections.Generic;
using bricks.Repositories;
using bricks.Models;
using Microsoft.AspNetCore.Mvc;

namespace bricks.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GenresController : ControllerBase
  {
    private readonly GenreRepository _gr;
    public GenresController(GenreRepository gr)
    {
      _gr = gr;
    }
    //GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Genre>> Get()
    {
      try
      {
        return Ok(_gr.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }


    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Genre> Get(int id)
    {
      try
      {
        return Ok(_gr.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // POST api/values
    [HttpPost]
    public ActionResult<IEnumerable<Genre>> Post([FromBody] Genre data)
    {
      try
      {
        return Ok(_gr.Create(data));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Genre> Put(int id, [FromBody] Genre data)
    {
      try
      {
        data.Id = id;
        return Ok(_gr.Update(data));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<Genre> Delete(int id)
    {
      try
      {
        return Ok(_gr.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}
