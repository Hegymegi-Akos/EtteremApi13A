using EtteremApi13A.Models.Dtos;
using EtteremApi13A.Services.IEtterem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtteremApi13A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermekController : ControllerBase
    {
        private readonly ITermek _di;
        public TermekController(ITermek termek)
        {
            _di = termek;
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

        [HttpPost]
        public async Task<ActionResult> PostData(AddTermekDto addTermekDto)
        {
            var requestResult = await _di.Post(addTermekDto) as ResponseDto;
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
            else if (requestResult.Result == null)
            {
                return NotFound(requestResult);
            }
            else
            {
                return BadRequest(requestResult);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutData(int id, UpdateTermekDto updateTermekDto)
        {
            var requestResult = await _di.Update(id, updateTermekDto) as ResponseDto;

            if (requestResult.Result != null)
            {
                return Ok(requestResult);
            }
            else if (requestResult.Result == null)
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
