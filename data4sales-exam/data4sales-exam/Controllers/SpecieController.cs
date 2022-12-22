using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace data4sales_exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecieController : ControllerBase
    {
        private readonly ISpecieLogic specieLogic;

        public SpecieController(ISpecieLogic specieLogic)
        {
            this.specieLogic = specieLogic;
        }

        // GET: api/<SpecieController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await specieLogic.Get();
            return Ok(data);
        }

        // GET api/<SpecieController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await specieLogic.Get(id);
            return Ok(data);
        }

        // POST api/<SpecieController>
        [HttpPost]
        public async Task Post([FromBody] Specie specie)
        {
            specie.Created = DateTime.Now;
            await specieLogic.Add(specie);
        }

        // PUT api/<SpecieController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Specie specie)
        {
            await specieLogic.Update(id, specie);
        }

        // DELETE api/<SpecieController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await specieLogic.Delete(id);
        }
    }
}
