using System.Web;
using System.Web.Mvc;

namespace POO1_T2_Parte02_TrujilloMezaJhuli
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
