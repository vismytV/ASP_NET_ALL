namespace WebApplication2.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }//Назва
        public int Discount { get; set; } // Знижка у відсотках
        public string Description { get; set; }//опис
    }
}
