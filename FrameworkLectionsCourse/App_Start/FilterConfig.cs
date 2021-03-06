using System.Web.Mvc;

namespace FrameworkLectionsCourse
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ArgumentExceptionHandleFilterAttribute());
            filters.Add(new LoggerFilter());
        }
    }
}
