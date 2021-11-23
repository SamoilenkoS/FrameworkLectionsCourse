using FrameworkLectionsCourse.Models;
using FrameworkLectionsCourse.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrameworkLectionsCourse.Controllers
{
    public class GoodsController : Controller
    {
        private GoodsService _goodsService = new GoodsService();
        // GET: Goods
        public ActionResult Index()
        {
            return View(_goodsService.GetAllGoods());
        }

        // GET: Goods/Details/5
        public ActionResult Details(int id)
        {
            return View(_goodsService.GetGoodById(id));
        }

        // GET: Goods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
        [HttpPost]
        public ActionResult Create(Good good)
        {
            try
            {
                _goodsService.Add(good);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Goods/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_goodsService.GetGoodById(id));
        }

        // POST: Goods/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Good good)
        {
            try
            {
                good.Id = id;
                _goodsService.Update(good);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Goods/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_goodsService.GetGoodById(id));
        }

        // POST: Goods/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Good good)
        {
            try
            {
                _goodsService.Delete(id);
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
