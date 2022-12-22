using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace data4sales_exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanetLogic planetLogic;

        public PlanetController(IPlanetLogic planetLogic)
        {
            this.planetLogic = planetLogic;
        }

        // GET: api/<PlanetController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await planetLogic.Get();
            return Ok(data);
        }

        // GET api/<PlanetController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await planetLogic.Get(id);
            return Ok(data);
        }

        // POST api/<PlanetController>
        [HttpPost]
        public async Task Post([FromBody] Planet planet)
        {
            planet.Created = DateTime.Now;
            await planetLogic.Add(planet);
        }

        // PUT api/<PlanetController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Planet planet)
        {
            await planetLogic.Update(id, planet);
        }

        // DELETE api/<PlanetController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await planetLogic.Delete(id);
        }
    }
}
