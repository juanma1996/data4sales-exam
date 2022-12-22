using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace data4sales_exam.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly IVehicleLogic vehicleLogic;

    public VehicleController(IVehicleLogic vehicleLogic)
    {
        this.vehicleLogic = vehicleLogic;
    }

    // GET: api/<VehicleController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var data = await vehicleLogic.Get();
        return Ok(data);
    }

    // GET api/<VehicleController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var data = await vehicleLogic.Get(id);
        return Ok(data);
    }

    // POST api/<VehicleController>
    [HttpPost]
    public async Task Post([FromBody] Vehicle vehicle)
    {
        vehicle.Created = DateTime.Now;
        await vehicleLogic.Add(vehicle);
    }

    // PUT api/<VehicleController>/5
    [HttpPut("{id}")]
    public async Task Put(int id, [FromBody] Vehicle vehicle)
    {
        await vehicleLogic.Update(id, vehicle);
    }

    // DELETE api/<VehicleController>/5
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await vehicleLogic.Delete(id);
    }
}