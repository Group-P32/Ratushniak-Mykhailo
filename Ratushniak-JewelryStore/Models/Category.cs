using System.Collections.Generic;

namespace JewelryStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        // Назва категорії
        public string Name { get; set; }
        // Опис категорії
        public string Description { get; set; }

        // Навігаційна властивість — список прикрас у категорії
        public ICollection<Jewelry> Jewelries { get; set; }

        public Category()
        {
            Jewelries = new List<Jewelry>();
        }
    }
}