using System.Web.Mvc;

namespace Ratushniak_JewelryStore
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Ratushniak_JewelryStore.Filters.CultureAttribute());
        }
    }
}