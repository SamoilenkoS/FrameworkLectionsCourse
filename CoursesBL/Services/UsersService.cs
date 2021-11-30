using CoursesDAL.Models;
using CoursesDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesBL.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _usersRepository.CreateUserAsync(user);
        }

        public async Task<User> CreateUserWithCar(User user)
        {
            user = await CreateUserAsync(user);
            await _usersRepository.CreateCarAsync(
                new Car
                {
                    Model = "Tesla",
                    UserId = user.UserId
                });

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _usersRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByUserId(int userId)
        {
            return await _usersRepository.GetUserByUserId(userId);
        }
    }
}
