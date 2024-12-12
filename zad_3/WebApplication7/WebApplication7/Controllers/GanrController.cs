using Microsoft.AspNetCore.Mvc;
using WebApplication7.Data;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class GanrController : Controller
    {
        private readonly IDataService _repository;

        public GanrController(IDataService repository)
        {
            _repository = repository;
        }

        /*// Відображення форми для створення жанру
        public IActionResult Create()
        {
            return View();
        }

        // Обробка POST-запиту для створення жанру
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name")] Ganr ganr)
        {
            if (ModelState.IsValid)
            {
                // Додаємо жанр у сховище
                _repository.AddGanr(ganr);

                // Перенаправляємо користувача на сторінку з усіма жанрами
                return RedirectToAction("Index", "Ganr");
            }

            // У разі помилки повертаємо користувача на форму
            return View(ganr);
        }

        // Перегляд усіх жанрів
        public IActionResult Index()
        {
            var genres = _repository.GetGanrs();  // Отримуємо всі жанри з репозиторію
            return View(genres);  // Повертаємо список жанрів до вигляду
        }
        */
    }
}
