using System.Collections.Generic;
using System.Web.Mvc;

namespace JewelryStore.Models
{
    public class JewelryListViewModel
    {
        // Список прикрас після фільтрації
        public IEnumerable<Jewelry> Jewelries { get; set; }
        // Список категорій для dropdown
        public SelectList Categories { get; set; }
        // Вибрана категорія
        public int? SelectedCategoryId { get; set; }
        // Мінімальна ціна
        public decimal? MinPrice { get; set; }
        // Максимальна ціна
        public decimal? MaxPrice { get; set; }
        // Інформація про пагінацію
        public PageInfo PageInfo { get; set; }
    }
}