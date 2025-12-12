using EtteremApi13A.Models.Dtos;

namespace EtteremApi13A.Services.IEtterem
{
    public interface IRendeles
    {
        Task<object> GetAll();
        Task<object> Post(AdsTermekDto addRendelesDto);
        Task<object> Delete(int id);
        Task<object> Update(int id, UpdateRendelesDto updateRendelesDto);
    }
}
