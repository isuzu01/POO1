using System.Web;
using System.Web.Mvc;

namespace POO1_EF_TrujilloMezaJhuli_AdventureWorks
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
