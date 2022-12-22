using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace data4sales_exam.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StarshipController : ControllerBase
{
    private readonly IStarshipLogic starshipLogic;

    public StarshipController(IStarshipLogic starshipLogic)
    {
        this.starshipLogic = starshipLogic;
    }

    // GET: api/<StarshipController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var data = await starshipLogic.Get();
        return Ok(data);
    }

    // GET api/<StarshipController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var data = await starshipLogic.Get(id);
        return Ok(data);
    }

    // POST api/<StarshipController>
    [HttpPost]
    public async Task Post([FromBody] Starship starship)
    {
        starship.Created = DateTime.Now;
        await starshipLogic.Add(starship);
    }

    // PUT api/<StarshipController>/5
    [HttpPut("{id}")]
    public async Task Put(int id, [FromBody] Starship starship)
    {
        await starshipLogic.Update(id, starship);
    }

    // DELETE api/<StarshipController>/5
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await starshipLogic.Delete(id);
    }
}