using CoursesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesBL.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByUserId(int userId);
        Task<User> CreateUserAsync(User user);
        Task<User> CreateUserWithCar(User user);
    }
}
