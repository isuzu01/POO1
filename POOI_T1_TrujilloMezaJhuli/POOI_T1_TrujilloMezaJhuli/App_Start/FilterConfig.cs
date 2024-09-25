using System.Web;
using System.Web.Mvc;

namespace POOI_T1_TrujilloMezaJhuli
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
