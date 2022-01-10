using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCoSample.Domain.Entities;
using UnluCoSample.Domain.Repositories.Base;

namespace UnluCoSample.Domain.Repositories
{
    public interface INumberPlateRepository : IRepository<NumberPlate>
    {
        Task<NumberPlate> GetByName(string name);
        Task SeedDb();
    }
}
