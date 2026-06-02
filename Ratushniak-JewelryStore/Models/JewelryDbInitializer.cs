using System.Data.Entity;

namespace JewelryStore.Models
{
    public class JewelryDbInitializer : DropCreateDatabaseAlways<JewelryContext>
    {
        protected override void Seed(JewelryContext db)
        {
            db.Jewelries.Add(new Jewelry { Name = "Перстень «Місячне сяйво»", Type = "Каблучка", Material = "Платина", Weight = 4.2, Price = 12500 });
            db.Jewelries.Add(new Jewelry { Name = "Підвіска «Зоряний пил»", Type = "Підвіска", Material = "Срібло", Weight = 2.8, Price = 3200 });
            db.Jewelries.Add(new Jewelry { Name = "Браслет «Титановий»", Type = "Браслет", Material = "Титан", Weight = 18.5, Price = 5800 });
            db.Jewelries.Add(new Jewelry { Name = "Сережки «Бронзовий вік»", Type = "Сережки", Material = "Бронза", Weight = 6.1, Price = 2100 });
            db.Jewelries.Add(new Jewelry { Name = "Намисто «Полярна ніч»", Type = "Намисто", Material = "Платина", Weight = 22.3, Price = 28000 });

            db.Purchases.Add(new Purchase { Person = "Тест Тестовий", Address = "м. Київ, вул. Хрещатик 1", JewelryId = 1, Date = System.DateTime.Now });

            base.Seed(db);
        }
    }
}