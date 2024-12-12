using Microsoft.AspNetCore.Mvc;
using WebApplication7.Data;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IDataService _repository;

        public AuthorController(IDataService repository)
        {
            _repository = repository;
        }

        // Дія для відображення всіх авторів
        public IActionResult CreateAuthor()
        {
            var authors = _repository.GetAuthors();  // Отримуємо всіх авторів через репозиторій
            return View(authors);  // Передаємо їх у представлення
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAuthor(Author author)
        {
            // Перевіряємо, чи існує книга
            var existingAuthor = _repository.GetAuthors().FirstOrDefault(b => b.Name.Equals(author.Name, StringComparison.OrdinalIgnoreCase)
            && b.DateTime == author.DateTime);

            if (existingAuthor != null)
            {
                TempData["SearchMessage1"] = "Такий автор вже є";
            }
            else
            {
                _repository.AddAuthor(author);
            }

            
                return RedirectToAction("CreateAuthor", "Author");
            
            
        }
    }
}
