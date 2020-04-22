using System.Web;
using System.Web.Mvc;

namespace WebAppMVC_14Apr
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
