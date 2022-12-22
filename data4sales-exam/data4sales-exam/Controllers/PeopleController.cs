using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace data4sales_exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleLogic peopleLogic;

        public PeopleController(IPeopleLogic peopleLogic)
        {
            this.peopleLogic = peopleLogic;
        }

        // GET: api/<PeopleController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await peopleLogic.Get();
            return Ok(data);
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await peopleLogic.Get(id);
            return Ok(data);
        }

        // POST api/<PeopleController>
        [HttpPost]
        public async Task Post([FromBody] People people)
        {
            people.Created = DateTime.Now;
            await peopleLogic.Add(people);
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] People people)
        {
            await peopleLogic.Update(id, people);
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await peopleLogic.Delete(id);
        }
    }
}
