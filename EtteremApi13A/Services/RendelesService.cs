using EtteremApi13A.Models;
using EtteremApi13A.Models.Dtos;
using EtteremApi13A.Services.IEtterem;
using Microsoft.EntityFrameworkCore;

namespace EtteremApi13A.Services
{
    public class RendelesService : IRendeles
    {
        private readonly EtteremContext _context;
        private readonly ResponseDto _responseDto;
        public RendelesService(EtteremContext context, ResponseDto responseDto)
        {
            _context = context;
            _responseDto = responseDto;
        }

        public async Task<object> GetAll()
        {
            try
            {
                var requestResult = await _context.Rendeles.ToListAsync();
                _responseDto.Message = "Sikeres lekérdezés.";
                _responseDto.Result = requestResult;
                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.Result = null;
                return _responseDto;
            }
        }

        public async Task<object> Post(AddRendelesDto addRendelesDto)
        {
            try
            {
                var requestResult = new Rendele 
                { 
                    AsztalSzam = addRendelesDto.AsztalSzam,
                    FizetesMod = addRendelesDto.FizetesMod
                };

                await _context.Rendeles.AddAsync(requestResult);
                await _context.SaveChangesAsync();

                _responseDto.Message = "Sikeres hozzáadás.";
                _responseDto.Result = requestResult;
                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.Result = null;
                return _responseDto;
            }
        }
    }
}
