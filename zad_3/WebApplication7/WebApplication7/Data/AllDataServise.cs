using WebApplication7.Models;

namespace WebApplication7.Data
{
    public class AllDataServise : IDataService
    {
        private readonly static List<Ganr> _ganrs = new List<Ganr>()
        {
            new Ganr
            {
                Id = 1,
                Name="Фантастика"
            },
            new Ganr
            {
                Id = 2,
                Name="Детектив"
            },
            new Ganr
            {
                Id = 3,
                Name="Історичний"
            }
        };

        private readonly static List<Author> _authors = new List<Author>()
{
    new Author { Id = 1, Name = "Bob Kras", Biography = "певний текст",
        DateTime=new DateTime(1975,2,2)  },
    new Author { Id = 2, Name = "Микола Ворона", Biography = "певний текст",
    DateTime=new DateTime(1960,4,12) }
};

        private readonly static List<Book> _books = new List<Book>()
{
    new Book
    {
        Id = 1,
        Title = "Проба",
        Price = 1000,
        Pages = 100,
        AuthorId = 1,
        Author = _authors.FirstOrDefault(a => a.Id == 1), // Присвоєння автора за Id
        DateTime = new DateTime(2020,10,1),
        GanrId = 1,
        Ganr =_ganrs.FirstOrDefault(g=>g.Id==1)
    },
    new Book
    {
        Id = 2,
        Title = "Туман",
        Price = 1000,
        Pages = 100,
        AuthorId = 1,
        Author = _authors.FirstOrDefault(a => a.Id == 1), // Присвоєння автора за Id
        DateTime = new DateTime(2020,10,1),
        GanrId = 1,
        Ganr =_ganrs.FirstOrDefault(g=>g.Id==2)
    }
};

        private int _bookCounter = 1;
        private int _authorCounter = 1;
        private int _ganrCounter = 1;
        // Методы для работы с книгами
        public List<Book> GetBooks() => _books;

        public void AddBook(Book book)
        {
            book.Id = _bookCounter++;
            _books.Add(book);
        }

        public void DeleteBook(int bookId)
        {
            var book = _books.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                _books.Remove(book);
            }
        }

        public void EditBook(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Price = book.Price;
                existingBook.Pages = book.Pages;
                existingBook.AuthorId = book.AuthorId;
                existingBook.Author = book.Author;
                existingBook.GanrId = book.GanrId;
                existingBook.Ganr = book.Ganr;
            }
        }

        public List<Book> SearchBooks(string searchString)
        {
            return _books.Where(b => b.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Методы для работы с авторами
        public List<Author> GetAuthors() => _authors;

        public void AddAuthor(Author author)
        {
            author.Id = _authorCounter++;
            _authors.Add(author);
        }

        public List<Ganr> GetGanrs() => _ganrs;

        public void AddGanr(Ganr ganr)
        {
            ganr.Id = _ganrCounter++;
            _ganrs.Add(ganr);
        }
    }
}

