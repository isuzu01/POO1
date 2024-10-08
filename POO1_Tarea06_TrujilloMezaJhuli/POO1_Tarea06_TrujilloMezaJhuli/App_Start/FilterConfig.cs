using System.Web;
using System.Web.Mvc;

namespace POO1_Tarea06_TrujilloMezaJhuli
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
