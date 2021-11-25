using CoursesBL.Services;
using CoursesDAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrameworkLectionsCourse
{
    public class DependencyResolverModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGoodsService>().To<GoodsService>();
            Bind<IGoodsRepository>().To<GoodsRepository>();
        }
    }
}