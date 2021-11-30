using CoursesDAL.Models;
using CoursesDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoursesBL.Services
{
    public class GoodsService : IGoodsService
    {
        private readonly IGoodsRepository _goodsRepository;

        public GoodsService(IGoodsRepository goodsRepository)
        {
            _goodsRepository = goodsRepository;
        }

        public async Task<Good> CreateAsync(Good good)
        {
            if(good.Category == CoursesDAL.Enums.Category.Wholesale && !good.MinCount.HasValue)
            {
                throw new ArgumentException();
            }
            return await _goodsRepository.CreateAsync(good);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _goodsRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Good>> GetAllAsync()
        {
            return await _goodsRepository.GetAllAsync();
        }

        public async Task<Good> GetByIdAsync(int id)
        {
            return await _goodsRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Good good)
        {
            return await _goodsRepository.UpdateAsync(good);
        }
    }
}