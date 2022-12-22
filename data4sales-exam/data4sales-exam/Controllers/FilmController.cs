using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace data4sales_exam.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmController : ControllerBase
{
    private readonly IFilmLogic filmLogic;

    public FilmController(IFilmLogic filmLogic)
    {
        this.filmLogic = filmLogic;
    }

    // GET: api/<FilmController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var data = await filmLogic.Get();
        return Ok(data);
    }

    // GET api/<FilmController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var data = await filmLogic.Get(id);
        return Ok(data);
    }

    // POST api/<FilmController>
    [HttpPost]
    public async Task Post([FromBody] Film film)
    {
        film.Created = DateTime.Now;
        await filmLogic.Add(film);
    }

    // PUT api/<FilmController>/5
    [HttpPut("{id}")]
    public async Task Put(int id, [FromBody] Film film)
    {
        await filmLogic.Update(id, film);
    }

    // DELETE api/<FilmController>/5
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await filmLogic.Delete(id);
    }
}