using System;
using System.Data.Entity;

namespace JewelryStore.Models
{
    public class JewelryDbInitializer : DropCreateDatabaseAlways<JewelryContext>
    {
        protected override void Seed(JewelryContext db)
        {
            // Додаємо категорії
            var cat1 = new Category { Name = "Підвіски", Description = "Елегантні підвіски з різних матеріалів" };
            var cat2 = new Category { Name = "Броші", Description = "Декоративні броші для одягу" };
            var cat3 = new Category { Name = "Каблучки із каменями", Description = "Каблучки з дорогоцінним камінням" };
            var cat4 = new Category { Name = "Чоловічі прикраси", Description = "Прикраси для чоловіків" };

            db.Categories.Add(cat1);
            db.Categories.Add(cat2);
            db.Categories.Add(cat3);
            db.Categories.Add(cat4);
            db.SaveChanges();

            // Додаємо прикраси з категоріями
            db.Jewelries.Add(new Jewelry { Name = "Перстень «Місячне сяйво»", Type = "Каблучка", Material = "Платина", Weight = 4.2, Price = 12500, CategoryId = cat3.Id });
            db.Jewelries.Add(new Jewelry { Name = "Підвіска «Зоряний пил»", Type = "Підвіска", Material = "Срібло", Weight = 2.8, Price = 3200, CategoryId = cat1.Id });
            db.Jewelries.Add(new Jewelry { Name = "Браслет «Титановий»", Type = "Браслет", Material = "Титан", Weight = 18.5, Price = 5800, CategoryId = cat4.Id });
            db.Jewelries.Add(new Jewelry { Name = "Сережки «Бронзовий вік»", Type = "Сережки", Material = "Бронза", Weight = 6.1, Price = 2100, CategoryId = cat2.Id });
            db.Jewelries.Add(new Jewelry { Name = "Намисто «Полярна ніч»", Type = "Намисто", Material = "Платина", Weight = 22.3, Price = 28000, CategoryId = cat1.Id });

            db.Purchases.Add(new Purchase { Person = "Тест Тестовий", Address = "м. Київ, вул. Хрещатик 1", JewelryId = 1, Date = DateTime.Now });

            base.Seed(db);
        }
    }
}