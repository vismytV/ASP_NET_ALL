namespace WebApplication7.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Pages { get; set; }

        public DateTime DateTime { get; set; }//дата випуску

        
        // Зв'язок з автором
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        //Зв'язок з жанром
        public int GanrId { get; set; }
        
        public Ganr Ganr { get; set; }
    }


}
