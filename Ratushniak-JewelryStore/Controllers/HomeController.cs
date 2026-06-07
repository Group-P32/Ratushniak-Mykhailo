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

        public ActionResult Index(int? categoryId, decimal? minPrice,
            decimal? maxPrice, int page = 1)
        {
            int pageSize = 3; // кількість прикрас на сторінці

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

            // Пагінація
            int totalItems = jewelries.Count();
            var jewelriesPerPage = jewelries
                .OrderBy(j => j.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Список категорій
            List<Category> categories = db.Categories.ToList();
            categories.Insert(0, new Category { Name = "Всі категорії", Id = 0 });

            JewelryListViewModel viewModel = new JewelryListViewModel
            {
                Jewelries = jewelriesPerPage,
                Categories = new SelectList(categories, "Id", "Name"),
                SelectedCategoryId = categoryId,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                PageInfo = new PageInfo
                {
                    PageNumber = page,
                    PageSize = pageSize,
                    TotalItems = totalItems
                }
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