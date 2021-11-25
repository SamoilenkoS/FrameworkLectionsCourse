using CoursesDAL.Models;
using System.Collections.Generic;

namespace CoursesDAL.Repositories
{
    public class GoodsRepositoryList
    {
        private static int _id;
        private static List<Good> _goods;

        static GoodsRepositoryList()
        {
            _id = 1;
            _goods = new List<Good>
            {
                new Good
                {
                    GoodId = _id++,
                    Title = "Retail A",
                    Category = Enums.Category.Retail
                },
                new Good
                {
                    GoodId = _id++,
                    Title = "Wholesale A",
                    Category = Enums.Category.Wholesale
                },
                new Good
                {
                    GoodId = _id++,
                    Title = "Wholesale B",
                    Category = Enums.Category.Wholesale,
                    MinCount = 10
                }
            };
        }

        public void Add(Good good)
        {
            good.GoodId = _id++;
            _goods.Add(good);
        }

        public IEnumerable<Good> GetAllGoods()
        {
            return _goods;
        }

        public Good GetGoodById(int id)
        {
            return _goods.Find(x => x.GoodId == id);
        }

        public void Update(Good good)
        {
            var element = _goods.Find(x => x.GoodId == good.GoodId);
            if (element != null)
            {
                var index = _goods.IndexOf(element);
                _goods[index] = good;
            }
        }

        public bool Delete(int id)
        {
            var element = _goods.Find(x => x.GoodId == id);

            return _goods.Remove(element);
        }
    }
}
