using CoursesBL.Services;
using CoursesDAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FrameworkLectionsCourse.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // GET: Users
        public async Task<ActionResult> Index()
        {
            return View(await _usersService.GetAllUsersAsync());
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _usersService.GetUserByUserId(id));
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            try
            {
                await _usersService.CreateUserWithCar(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }

            return Redirect("Index");
        }

        [HttpPost]
        public ActionResult Login(LoginInfo loginInfo)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Login");
            }

            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var user = manager.Find(loginInfo.Username, loginInfo.Password);

            var userIdentity = manager.CreateIdentity(user,
                DefaultAuthenticationTypes.ApplicationCookie);

            authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);

            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();

            return Redirect("Index");
        }
    }
}
