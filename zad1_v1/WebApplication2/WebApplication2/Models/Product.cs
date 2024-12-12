using System;

namespace WebApplication2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }//назва
        public decimal Price { get; set; }//ціна
        public string Description { get; set; }//опис
        public DateTime ManufactureDate { get; set; }//дата виготовлення
        public Category Category { get; set; } // Додаємо категорію
    }
}
