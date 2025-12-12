using EtteremApi13A.Models.Dtos;

namespace EtteremApi13A.Services.IEtterem
{
    public interface IRendeles
    {
        Task<object> GetAll();
        Task<object> Post(AddRendelesDto addRendelesDto);
    }
}
