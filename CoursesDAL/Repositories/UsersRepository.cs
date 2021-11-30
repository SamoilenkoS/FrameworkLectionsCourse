using CoursesDAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesDAL.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly CoursesContext _coursesContext;

        public UsersRepository(CoursesContext coursesContext)
        {
            _coursesContext = coursesContext;
        }

        public async Task<Car> CreateCarAsync(Car car)
        {
            _coursesContext.Cars.Add(car);
            await _coursesContext.SaveChangesAsync();

            return car;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            IdentityResult result = await manager.CreateAsync(new IdentityUser()
            {
                UserName = "TestUserName"
            }, "TestPassword");

            _coursesContext.Users.Add(user);
            await _coursesContext.SaveChangesAsync();

            return user;
        }

        public async Task CreateUserRolesAsync()
        {
            var roleStore = new RoleStore<IdentityRole>();
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var identityResult = await roleManager.CreateAsync(new IdentityRole
            {
                Name = "Admin"
            });
            var identityResult2 = await roleManager.CreateAsync(new IdentityRole
            {
                Name = "User"
            });

            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = await userManager.FindAsync("TestUserName", "TestPassword");

            await userManager.AddToRoleAsync(user.Id, "Admin");
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _coursesContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByUserId(int userId)
        {
            return await _coursesContext.Users.FindAsync(userId);
        }
    }
}
