using CoursesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesDAL.Repositories
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByUserId(int userId);
        Task<User> CreateUserAsync(User user);
        Task<Car> CreateCarAsync(Car car);
        Task CreateUserRolesAsync();
    }
}
