using EtteremApi13A.Models;
using EtteremApi13A.Models.Dtos;
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

        [HttpPost]
        public async Task<ActionResult> PostData(AddRendelesDto addRendelesDto)
        {
            var requestResult = await _di.Post(addRendelesDto) as ResponseDto;
            //var result = requestResult.Result as Rendele;

            if (requestResult != null)
            {
                return Ok(requestResult);
            }

            return BadRequest(requestResult);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteData(int id)
        {
            var requestResult = await _di.Delete(id) as ResponseDto;

            if (requestResult.Result != null)
            {
                return Ok(requestResult);
            }
            else if(requestResult.Result == null)
            {
                return NotFound(requestResult);
            }
            else
            {
                return BadRequest(requestResult);
            }

                
        }
    }
}
