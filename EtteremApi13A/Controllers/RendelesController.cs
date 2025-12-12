using EtteremApi13A.Services.IEtterem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtteremApi13A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendelesController : ControllerBase
    {
        private readonly IRendeles _di;
        public RendelesController(IRendeles rendeles)
        {
            _di = rendeles;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var requestResult = await _di.GetAll();
            if(requestResult != null)
            {
                return Ok(requestResult);
            }

            return BadRequest(requestResult);
        }
    }
}
