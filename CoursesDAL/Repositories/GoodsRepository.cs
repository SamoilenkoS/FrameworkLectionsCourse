using CoursesDAL.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesDAL.Repositories
{
    public class GoodsRepository : IGoodsRepository
    {
        private readonly CoursesContext _coursesContext;

        public GoodsRepository(CoursesContext coursesContext)
        {
            _coursesContext = coursesContext;
        }

        public async Task<Good> CreateAsync(Good good)
        {
            good.IsDeleted = false;
            _coursesContext.Goods.Add(good);

            await _coursesContext.SaveChangesAsync();

            return good;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _coursesContext.Goods.FindAsync(id);
            var result = item != null;
            if (result)
            {
                item.IsDeleted = true;
                _coursesContext.Entry(item).State = EntityState.Modified;
                await _coursesContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IEnumerable<Good>> GetAllAsync(bool isDeleted = false)
        {
            return await _coursesContext.Goods.Where(x => x.IsDeleted == isDeleted).ToListAsync();
        }

        public async Task<Good> GetByIdAsync(int id)
        {
            return await _coursesContext.Goods.Where(x =>
                !x.IsDeleted &&
                x.GoodId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Good good)
        {
            var item = _coursesContext.Goods.Attach(good);
            item.IsDeleted = false;
            _coursesContext.Entry(good).State = EntityState.Modified;
            await _coursesContext.SaveChangesAsync();

            return item != null;
        }
    }
}
