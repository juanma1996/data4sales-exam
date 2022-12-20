using DataAccessInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace data4sales_exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IRepository<People> peopleRepository;

        public PeopleController(IRepository<People> peopleRepository)
        {
            this.peopleRepository = peopleRepository;
        }
        // GET: api/<PeopleController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await peopleRepository.GetAllAsync();
            return Ok(data);
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public People Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<PeopleController>
        [HttpPost]
        public void Post([FromBody] People people)
        {
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] People value)
        {
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
