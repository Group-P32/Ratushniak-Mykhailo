using System;

namespace JewelryStore.Models
{
    public class PageInfo
    {
        // Номер поточної сторінки
        public int PageNumber { get; set; }
        // Кількість об'єктів на сторінці
        public int PageSize { get; set; }
        // Загальна кількість об'єктів
        public int TotalItems { get; set; }
        // Загальна кількість сторінок
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}