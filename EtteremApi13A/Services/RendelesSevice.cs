using EtteremApi13A.Models;
using EtteremApi13A.Models.Dtos;
using EtteremApi13A.Services.IEtterem;
using Microsoft.EntityFrameworkCore;

namespace EtteremApi13A.Services
{
    public class RendelesSevice : IRendeles
    {
        private readonly EtteremContext _context;
        private readonly ResponseDto _responseDto;
        public RendelesSevice(EtteremContext context, ResponseDto responseDto)
        {
            _context = context;
            _responseDto = responseDto;
        }

        public async Task<object> GetAllRendeles()
        {
            try
            {
                var rendelesek = await _context.Rendeles.ToListAsync();
                _responseDto.Message = "Sikeres lekérdezés.";
                _responseDto.Result = rendelesek;
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
