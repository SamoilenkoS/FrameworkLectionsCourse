using CoursesBL.Services;
using CoursesDAL.Repositories;
using Ninject.Modules;

namespace FrameworkLectionsCourse
{
    public class DependencyResolverModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGoodsService>().To<GoodsService>();
            Bind<IGoodsRepository>().To<GoodsRepository>();
            Bind<IUsersRepository>().To<UsersRepository>();
            Bind<IUsersService>().To<UsersService>();
        }
    }
}