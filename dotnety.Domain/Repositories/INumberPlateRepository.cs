using System.Threading.Tasks;
using dotnety.Domain.Entities;

namespace dotnety.Domain.Repositories
{
    public interface INumberPlateRepository
    {
        Task<NumberPlate?> GetById(int id);
        Task<NumberPlate?> GetByName(string name);
        Task SeedDb();
    }
}