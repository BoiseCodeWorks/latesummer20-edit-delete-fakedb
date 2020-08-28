using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catsAPI.Models;
using catsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace catsAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CatsController : ControllerBase
  {
    private readonly CatsService _catService;
    public CatsController(CatsService catsService)
    {
      _catService = catsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Cat>> Get()
    {
      try
      {
        IEnumerable<Cat> cats = _catService.GetCats();
        return Ok(cats);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Cat> GetById(string id)
    {
      try
      {
        Cat cat = _catService.GetById(id);
        return Ok(cat);
      }
      catch (Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Cat> Create([FromBody] Cat newCat)
    {
      try
      {
        return Ok(_catService.Create(newCat));
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Cat> Edit([FromBody] Cat editCat, string id)
    {
      try
      {
        editCat.Id = id;
        return Ok(_catService.Edit(editCat));
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<String> Delete(string id)
    {
      try
      {
        return Ok(_catService.Delete(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}
