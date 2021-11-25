using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrameworkLectionsCourse.Controllers
{
    public class HomeController : Controller
    {
        private const string CookieName = "TestCookie";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            if (Request.Cookies.AllKeys.Contains(CookieName))
            {
                var value = Convert.ToInt32(Request.Cookies[CookieName].Value);
                if(value != 5)
                {
                    Response.Cookies[CookieName].Value = (++value).ToString();
                }
                else
                {
                    Response.Cookies[CookieName].Expires =
                        DateTime.Now.AddSeconds(1);
                }
            }
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            HttpCookie httpCookie = new HttpCookie("TestCookie");
            httpCookie.Expires = DateTime.Now.AddMinutes(5);
            httpCookie.Value = "0";
            Response.Cookies.Add(httpCookie);

            ViewBag.Message = "Your contact page.";
            ViewData["Test"] = "Hello world!";

            return View();
        }
    }
}