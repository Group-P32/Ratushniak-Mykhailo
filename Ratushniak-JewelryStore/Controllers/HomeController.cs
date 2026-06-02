using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JewelryStore.Models;

namespace Ratushniak_JewelryStore.Controllers
{
    public class HomeController : Controller
    {
        JewelryContext db = new JewelryContext();

        public ActionResult Index()
        {
            IEnumerable<Jewelry> jewelries = db.Jewelries;
            ViewBag.Jewelries = jewelries;
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.JewelryId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Дякуємо, " + purchase.Person + ", за покупку в магазині «Срібна підкова»!";
        }
    }
}