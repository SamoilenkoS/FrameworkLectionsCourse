using CoursesDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
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
            _coursesContext.Goods.Add(good);

            await _coursesContext.SaveChangesAsync();

            return good;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = _coursesContext.Goods.Attach(new Good { Id = id });
            var result = item != null;
            if (result)
            {
                _coursesContext.Entry(item).State = EntityState.Deleted;
                await _coursesContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IEnumerable<Good>> GetAllAsync()
        {
            return await _coursesContext.Goods.ToListAsync();
        }

        public async Task<Good> GetByIdAsync(int id)
        {
            return await _coursesContext.Goods.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Good good)
        {
            var item = _coursesContext.Goods.Attach(good);
            _coursesContext.Entry(good).State = EntityState.Modified;
            await _coursesContext.SaveChangesAsync();

            return item != null;
        }
    }
}
