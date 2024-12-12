using WebApplication7.Models;

namespace WebApplication7.Data
{
    public interface IDataService
    {
        // Методы для работы с книгами
        List<Book> GetBooks();
        void AddBook(Book book);
        void DeleteBook(int bookId);
        void EditBook(Book book);
        List<Book> SearchBooks(string searchString);

        // Методы для работы с авторами
        List<Author> GetAuthors();
        void AddAuthor(Author author);

        List<Ganr> GetGanrs();  // Доданий метод для отримання жанрів
        //void AddGanr(Ganr ganr);
    }
}
