using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using dotnety.Domain.Entities;
using dotnety.Domain.Repositories;
using dotnety.Infrastructure.Database;

namespace dotnety.Infrastructure.Repositories
{
    public class NumberPlateRepository(DotnetyDbContext dotnetyDbContext) : INumberPlateRepository
    {
        private readonly DotnetyDbContext _dbContext = dotnetyDbContext;

        public Task Add(NumberPlate entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(NumberPlate entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NumberPlate>> Get(Expression<Func<NumberPlate, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NumberPlate>> GetAll()
        {
            return await _dbContext.NumberPlates.ToListAsync();
        }

        public async Task<NumberPlate?> GetById(int id)
            => await _dbContext.NumberPlates.FindAsync(id);

        public async Task<NumberPlate?> GetByName(string name)
            => await _dbContext.NumberPlates.Where(m => m.Name == name).SingleOrDefaultAsync();

        public async Task SeedDb()
        {
            bool d = _dbContext.NumberPlates.Any();
            if (!d)
            {
                await _dbContext.NumberPlates.AddRangeAsync(
                    new NumberPlate() { Id = 1, Name = "Adana" },
                    new NumberPlate() { Id = 2, Name = "Adıyaman" },
                    new NumberPlate() { Id = 3, Name = "Afyon" },
                    new NumberPlate() { Id = 4, Name = "Ağrı" },
                    new NumberPlate() { Id = 5, Name = "Amasya" },
                    new NumberPlate() { Id = 6, Name = "Ankara" },
                    new NumberPlate() { Id = 7, Name = "Antalya" },
                    new NumberPlate() { Id = 8, Name = "Artvin" },
                    new NumberPlate() { Id = 9, Name = "Aydın" },
                    new NumberPlate() { Id = 10, Name = "Balıkesir" },
                    new NumberPlate() { Id = 11, Name = "Bilecik" },
                    new NumberPlate() { Id = 12, Name = "Bingöl" },
                    new NumberPlate() { Id = 13, Name = "Bitlis" },
                    new NumberPlate() { Id = 14, Name = "Bolu" },
                    new NumberPlate() { Id = 15, Name = "Burdur" },
                    new NumberPlate() { Id = 16, Name = "Bursa" },
                    new NumberPlate() { Id = 17, Name = "Çanakkale" },
                    new NumberPlate() { Id = 18, Name = "Çankırı" },
                    new NumberPlate() { Id = 19, Name = "Çorum" },
                    new NumberPlate() { Id = 20, Name = "Denizli" },
                    new NumberPlate() { Id = 21, Name = "Diyarbakır" },
                    new NumberPlate() { Id = 22, Name = "Edirne" },
                    new NumberPlate() { Id = 23, Name = "Elazığ" },
                    new NumberPlate() { Id = 24, Name = "Erzincan" },
                    new NumberPlate() { Id = 25, Name = "Erzurum" },
                    new NumberPlate() { Id = 26, Name = "Eskişehir" },
                    new NumberPlate() { Id = 27, Name = "Gaziantep" },
                    new NumberPlate() { Id = 28, Name = "Giresun" },
                    new NumberPlate() { Id = 29, Name = "Gümüşhane" },
                    new NumberPlate() { Id = 30, Name = "Hakkari" },
                    new NumberPlate() { Id = 31, Name = "Hatay" },
                    new NumberPlate() { Id = 32, Name = "Isparta" },
                    new NumberPlate() { Id = 33, Name = "İçel" },
                    new NumberPlate() { Id = 34, Name = "İstanbul" },
                    new NumberPlate() { Id = 35, Name = "İzmir" },
                    new NumberPlate() { Id = 36, Name = "Kars" },
                    new NumberPlate() { Id = 37, Name = "Kastamonu" },
                    new NumberPlate() { Id = 38, Name = "Kayseri" },
                    new NumberPlate() { Id = 39, Name = "Kırklareli" },
                    new NumberPlate() { Id = 40, Name = "Kırşehir" },
                    new NumberPlate() { Id = 41, Name = "Kocaeli" },
                    new NumberPlate() { Id = 42, Name = "Konya" },
                    new NumberPlate() { Id = 43, Name = "Kütahya" },
                    new NumberPlate() { Id = 44, Name = "Malatya" },
                    new NumberPlate() { Id = 45, Name = "Manisa" },
                    new NumberPlate() { Id = 46, Name = "Kahramanmaraş" },
                    new NumberPlate() { Id = 47, Name = "Mardin" },
                    new NumberPlate() { Id = 48, Name = "Muğla" },
                    new NumberPlate() { Id = 49, Name = "Muş" },
                    new NumberPlate() { Id = 50, Name = "Nevşehir" },
                    new NumberPlate() { Id = 51, Name = "Niğde" },
                    new NumberPlate() { Id = 52, Name = "Ordu" },
                    new NumberPlate() { Id = 53, Name = "Rize" },
                    new NumberPlate() { Id = 54, Name = "Sakarya" },
                    new NumberPlate() { Id = 55, Name = "Samsun" },
                    new NumberPlate() { Id = 56, Name = "Siirt" },
                    new NumberPlate() { Id = 57, Name = "Sinop" },
                    new NumberPlate() { Id = 58, Name = "Sivas" },
                    new NumberPlate() { Id = 59, Name = "Tekirdağ" },
                    new NumberPlate() { Id = 60, Name = "Tokat" },
                    new NumberPlate() { Id = 61, Name = "Trabzon" },
                    new NumberPlate() { Id = 62, Name = "Tunceli" },
                    new NumberPlate() { Id = 63, Name = "Şanlıurfa" },
                    new NumberPlate() { Id = 64, Name = "Uşak" },
                    new NumberPlate() { Id = 65, Name = "Van" },
                    new NumberPlate() { Id = 66, Name = "Yozgat" },
                    new NumberPlate() { Id = 67, Name = "Zonguldak" },
                    new NumberPlate() { Id = 68, Name = "Aksaray" },
                    new NumberPlate() { Id = 69, Name = "Bayburt" },
                    new NumberPlate() { Id = 70, Name = "Karaman" },
                    new NumberPlate() { Id = 71, Name = "Kırıkkale" },
                    new NumberPlate() { Id = 72, Name = "Batman" },
                    new NumberPlate() { Id = 73, Name = "Şırnak" },
                    new NumberPlate() { Id = 74, Name = "Bartın" },
                    new NumberPlate() { Id = 75, Name = "Ardahan" },
                    new NumberPlate() { Id = 76, Name = "Iğdır" },
                    new NumberPlate() { Id = 77, Name = "Yalova" },
                    new NumberPlate() { Id = 78, Name = "Karabük" },
                    new NumberPlate() { Id = 79, Name = "Kilis" },
                    new NumberPlate() { Id = 80, Name = "Osmaniye" },
                    new NumberPlate() { Id = 81, Name = "Düzce" }
                    );
                await _dbContext.SaveChangesAsync();
            }
        }

        public Task Update(NumberPlate entity)
        {
            throw new NotImplementedException();
        }
    }
}
