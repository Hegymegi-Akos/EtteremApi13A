using EtteremApi13A.Models.Dtos;

namespace EtteremApi13A.Services.IEtterem
{
    public interface ITermek
    {
        Task<object> GetAll();
        Task<object> Post(AddTermekDto addTermekDto);
        Task<object> Delete(int id);
        Task<object> Update(int id, UpdateTermekDto updateTermekDto);
    }
}
