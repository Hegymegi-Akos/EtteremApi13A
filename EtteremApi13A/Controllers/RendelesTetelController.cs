using EtteremApi13A.Services.IEtterem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtteremApi13A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendelesTetelController : ControllerBase
    {
        private readonly IRendelesTetel _di;
        public RendelesTetelController(IRendelesTetel rendelestetel)
        {
            _di = rendelestetel;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var requestResult = await _di.GetAll();
            if (requestResult != null)
            {
                return Ok(requestResult);
            }

            return BadRequest(requestResult);
        }
    }
}
