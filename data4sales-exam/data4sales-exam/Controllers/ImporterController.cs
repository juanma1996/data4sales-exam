using BusinessLogicInterface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace data4sales_exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImporterController : ControllerBase
    {
        private readonly IImporterLogic importerLogic;

        public ImporterController(IImporterLogic importerLogic)
        {
            this.importerLogic = importerLogic;
        }

        // POST api/<ImporterController>
        [HttpPost]
        public async Task Post()
        {
            await importerLogic.ImportAsync();
        }
    }
}
