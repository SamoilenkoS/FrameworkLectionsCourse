using CoursesBL.Services;
using CoursesDAL.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FrameworkLectionsCourse.Controllers
{
    public class GoodsController : Controller
    {
        private IGoodsService _goodsService;

        public GoodsController(IGoodsService goodsService)
        {
            _goodsService = goodsService;
        }

        // GET: Goods
        public async Task<ActionResult> Index()
        {
            return View(await _goodsService.GetAllAsync());
        }

        // GET: Goods/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _goodsService.GetByIdAsync(id));
        }

        // GET: Goods/Create
        [Authorize(Roles ="User,Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Good good)
        {
            try
            {
                await _goodsService.CreateAsync(good);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Goods/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _goodsService.GetByIdAsync(id));
        }

        // POST: Goods/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Good good)
        {
            try
            {
                good.GoodId = id;
                await _goodsService.UpdateAsync(good);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Goods/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _goodsService.GetByIdAsync(id));
        }

        // POST: Goods/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult >Delete(int id, Good good)
        {
            try
            {
                await _goodsService.DeleteAsync(id);
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
