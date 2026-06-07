using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace Ratushniak_JewelryStore.Filters
{
    public class CultureAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string cultureName = null;

            var session = filterContext.HttpContext.Session;
            if (session != null && session["lang"] != null)
                cultureName = session["lang"].ToString();
            else
                cultureName = "uk";

            if (cultureName != "uk" && cultureName != "en" && cultureName != "fr")
                cultureName = "uk";

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);

            base.OnActionExecuting(filterContext);
        }
    }
}