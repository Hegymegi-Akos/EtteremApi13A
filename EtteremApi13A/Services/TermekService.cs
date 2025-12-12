using EtteremApi13A.Models;
using EtteremApi13A.Models.Dtos;
using EtteremApi13A.Services.IEtterem;
using Microsoft.EntityFrameworkCore;

namespace EtteremApi13A.Services
{
    public class TermekService : ITermek
    {
        private readonly EtteremContext _context;
        private readonly ResponseDto _responseDto;
        public TermekService(EtteremContext context, ResponseDto responseDto)
        {
            _context = context;
            _responseDto = responseDto;
        }

        public async Task<object> Delete(int id)
        {
            try
            {
                var requestResult = await _context.Termeks.FirstOrDefaultAsync(x => x.TermekId == id);

                if (requestResult != null)
                {
                    _context.Termeks.Remove(requestResult);
                    await _context.SaveChangesAsync();

                    _responseDto.Message = "Sikeres törlés.";
                    _responseDto.Result = requestResult;
                    return _responseDto;
                }

                _responseDto.Message = "Nincs ilyen id.";
                _responseDto.Result = requestResult;
                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.Result = ex.Data;
                return _responseDto;
            }
        }

        public async Task<object> GetAll()
        {
            try
            {
                var requestResult = await _context.Termeks.ToListAsync();
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

        public async Task<object> Post(AddTermekDto addTermekDto)
        {
            try
            {
                var requestResult = new Termek
                {
                    TermekNev = addTermekDto.TermekNev,
                    Ar = addTermekDto.Ar
                };

                await _context.Termeks.AddAsync(requestResult);
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

        public async Task<object> Update(int id, UpdateTermekDto updateTermekDto)
        {
            try
            {
                var requestResult = await _context.Termeks.FirstOrDefaultAsync(x => x.TermekId == id);

                if (requestResult != null)
                {
                    requestResult.TermekNev = updateTermekDto.TermekNev;
                    requestResult.Ar = updateTermekDto.Ar;

                    _context.Termeks.Update(requestResult);
                    await _context.SaveChangesAsync();

                    _responseDto.Message = "Sikeres frissítés.";
                    _responseDto.Result = requestResult;
                    return _responseDto;
                }

                _responseDto.Message = "Nincs ilyen id.";
                _responseDto.Result = requestResult;
                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.Result = ex.Data;
                return _responseDto;
            }
        }
    }
}
