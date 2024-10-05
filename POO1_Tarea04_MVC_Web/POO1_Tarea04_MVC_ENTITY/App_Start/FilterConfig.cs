using System.Web;
using System.Web.Mvc;

namespace POO1_Tarea04_MVC_ENTITY
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
