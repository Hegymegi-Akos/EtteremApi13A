using EtteremApi13A.Models;
using EtteremApi13A.Models.Dtos;
using EtteremApi13A.Services.IEtterem;
using Microsoft.EntityFrameworkCore;

namespace EtteremApi13A.Services
{
    public class RendelesTetel : IRendelesTetel
    {
        private readonly EtteremContext _context;
        private readonly ResponseDto _responseDto;
        public RendelesTetel(EtteremContext context, ResponseDto responseDto)
        {
            _context = context;
            _responseDto = responseDto;
        }
        public async Task<object> GetAll()
        {
            try
            {
                var requestResult = await _context.Rendelestetels.ToListAsync();
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
    }
}
