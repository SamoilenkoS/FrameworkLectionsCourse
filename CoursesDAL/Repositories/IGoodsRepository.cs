using CoursesDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoursesDAL.Repositories
{
    public interface IGoodsRepository
    {
        Task<Good> CreateAsync(Good good);
        Task<IEnumerable<Good>> GetAllAsync();
        Task<Good> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Good good);
        Task<bool> DeleteAsync(int id);
    }
}
