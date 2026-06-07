using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using JewelryStore.Models;
using System.Data.Entity;

namespace Ratushniak_JewelryStore.Controllers
{
    public class HomeController : Controller
    {
        JewelryContext db = new JewelryContext();

        public ActionResult Index(int? categoryId, decimal? minPrice, decimal? maxPrice)
        {
            // Отримуємо всі прикраси з категоріями
            IQueryable<Jewelry> jewelries = db.Jewelries.Include(j => j.Category);

            // Фільтр за категорією
            if (categoryId != null && categoryId != 0)
            {
                jewelries = jewelries.Where(j => j.CategoryId == categoryId);
            }

            // Фільтр за мінімальною ціною
            if (minPrice != null)
            {
                jewelries = jewelries.Where(j => j.Price >= minPrice);
            }

            // Фільтр за максимальною ціною
            if (maxPrice != null)
            {
                jewelries = jewelries.Where(j => j.Price <= maxPrice);
            }

            // Формуємо список категорій для dropdown
            List<Category> categories = db.Categories.ToList();
            categories.Insert(0, new Category { Name = "Всі категорії", Id = 0 });

            // Формуємо ViewModel
            JewelryListViewModel viewModel = new JewelryListViewModel
            {
                Jewelries = jewelries.ToList(),
                Categories = new SelectList(categories, "Id", "Name"),
                SelectedCategoryId = categoryId,
                MinPrice = minPrice,
                MaxPrice = maxPrice
            };

            return View(viewModel);
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