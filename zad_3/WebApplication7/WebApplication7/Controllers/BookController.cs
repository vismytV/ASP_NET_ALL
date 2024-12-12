using Microsoft.AspNetCore.Mvc;
using WebApplication7.Data;
using WebApplication7.Models;
using static System.Reflection.Metadata.BlobBuilder;


namespace WebApplication7.Controllers
{
    public class BookController : Controller
    {
        private readonly IDataService _repository;

        public BookController(IDataService repository)
        {
            _repository = repository;
        }

        // Виведення усіх книг
        public IActionResult Index(string searchString)
        {
            var books = string.IsNullOrEmpty(searchString)
                ? _repository.GetBooks()
                : _repository.SearchBooks(searchString);

            ViewBag.SearchMessage = string.IsNullOrEmpty(searchString)
                ? "Список книг"
                : $"{searchString}";

            return View(books);
        }


        // Додавання нової книги
        public IActionResult Create()
        {
            ViewData["Authors"] = _repository.GetAuthors();
            ViewData["Ganr"] = _repository.GetGanrs();  // Додаємо жанри
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            // Перевіряємо, чи існує книга
            var existingBook = _repository.GetBooks().FirstOrDefault(b => b.Title.Equals(book.Title, StringComparison.OrdinalIgnoreCase) 
            && b.AuthorId==book.AuthorId);

            if (existingBook != null)
            {
                TempData["SearchMessage1"] = "Така книга вже є";
            }
            else
            {
                book.Author = _repository.GetAuthors().FirstOrDefault(a => a.Id == book.AuthorId);
                book.Ganr = _repository.GetGanrs().FirstOrDefault(g => g.Id == book.GanrId);

                _repository.AddBook(book);
            }
            
            return RedirectToAction(nameof(Index));
            
        }

        // Видалення книги
        public IActionResult Delete(int id, string temp="0")
        {
            var book = _repository.GetBooks().FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                ViewBag.SearchMessage = temp;
                return View(book);
            }

            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _repository.GetBooks().FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _repository.DeleteBook(id);
                return RedirectToAction(nameof(Index));
            }

            TempData["SearchMessage1"] = "Книгу не знайдено";
            return RedirectToAction(nameof(Index));
        }

        // Редагування книги
        public IActionResult Edit(int id)
        {
            var book = _repository.GetBooks().FirstOrDefault(b => b.Id == id);
            
            ViewData["Authors"] = _repository.GetAuthors();
            ViewData["Ganr"] = _repository.GetGanrs();
            return View(book);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book, string OldTitle)
        {
            var existingBook = _repository.GetBooks().FirstOrDefault(b =>b.Id == id);
            if (existingBook == null)
            {
                TempData["SearchMessage1"] = "Книга була видалена раніше";
                return RedirectToAction(nameof(Index));
            }

            existingBook = _repository.GetBooks().FirstOrDefault(b => b.Title.Equals(OldTitle, StringComparison.OrdinalIgnoreCase)
            );
            if (existingBook == null)
            {
                TempData["SearchMessage1"] = "Книга була редагована раніше";
                return RedirectToAction(nameof(Index));
            }

            // Перевіряємо, чи існує книга
            existingBook = _repository.GetBooks().FirstOrDefault(b => b.Title.Equals(book.Title, StringComparison.OrdinalIgnoreCase)
            && b.AuthorId == book.AuthorId && id!=b.Id);

            if (existingBook != null)
            {
                TempData["SearchMessage1"] = "Така книга вже є";
            }
            else
            {
                book.Author = _repository.GetAuthors().FirstOrDefault(a => a.Id == book.AuthorId);
                book.Ganr = _repository.GetGanrs().FirstOrDefault(g => g.Id == book.GanrId);
                _repository.EditBook(book);
            }
        
            return RedirectToAction(nameof(Index));
        }
    }
}