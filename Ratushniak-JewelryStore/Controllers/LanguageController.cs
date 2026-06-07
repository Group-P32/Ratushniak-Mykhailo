using System.Web.Mvc;

namespace Ratushniak_JewelryStore.Controllers
{
    public class LanguageController : Controller
    {
        public ActionResult Change(string lang, string returnUrl)
        {
            if (lang == "uk" || lang == "en" || lang == "fr")
                Session["lang"] = lang;
            else
                Session["lang"] = "uk";

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }
    }
}