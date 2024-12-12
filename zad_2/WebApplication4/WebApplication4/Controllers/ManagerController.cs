using Microsoft.AspNetCore.Mvc;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IDataService _dataService;

        // Внедрение IDataService через конструктор
        public ManagerController(IDataService dataService)
        {
            _dataService = dataService;
        }

        // Страница для создания менеджера
        public IActionResult Create()
        {
            return View();
        }
        // Обработка формы для добавления менеджера
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Manager manager)
        {
            // Проверка на существующего менеджера
            //var existingManager = _dataService.GetManagers().FirstOrDefault(e => e.FirstName == manager.FirstName
            //    && e.LastName == manager.LastName && e.DenNarodg == manager.DenNarodg);
            var existingManager = _dataService.GetManagers()
    .FirstOrDefault(e => string.Equals(e.FirstName, manager.FirstName, StringComparison.Ordinal) &&
                         string.Equals(e.LastName, manager.LastName, StringComparison.Ordinal)
                         && e.DenNarodg == manager.DenNarodg);

            if (existingManager != null)
            {
                // Добавляем сообщение в TempData
                TempData["ErrorMessage"] = "Такий менеджер вже існує в базі.";
                return View(manager);
            }

            // Получаем список сотрудников из сервиса
            var employees = _dataService.GetEmployees();

            /*var existingEmployee = _dataService.GetEmployees().FirstOrDefault(e => e.FirstName == 
            manager.FirstName  && e.LastName == manager.LastName && e.DenNarodg == manager.DenNarodg); */
            var existingEmployee = _dataService.GetEmployees()
    .FirstOrDefault(e => string.Equals(e.FirstName, manager.FirstName, StringComparison.Ordinal) &&
                         string.Equals(e.LastName, manager.LastName, StringComparison.Ordinal)
                         && e.DenNarodg == manager.DenNarodg);

            int totalEmployees = employees.Count;  // Общее количество работников
            int subordinatesCount = manager.EmployeeCount;  // Количество подчиненных у менеджера

            if (existingEmployee != null)
            {
                // Добавляем сообщение в TempData
                TempData["ErrorMessage"] = $"{manager.FirstName} {manager.LastName} вже записаний в базі як робітник.";
                return View(manager);
            }


            // Проверка, чтобы количество подчиненных не превышало количество работников
            if (subordinatesCount > totalEmployees)
            {
                TempData["ErrorMessage"] = "Менеджер не може мати більше підлеглих, ніж є робітників.";
                return View(manager);
            }

            // Если данные валидны, добавляем менеджера
            if (ModelState.IsValid)
            {
                manager.Id = _dataService.GetManagers().Count + 1;
                _dataService.AddManager(manager);  // Добавляем менеджера через сервис
                return RedirectToAction(nameof(Index));
            }

            return View(manager);
        }

        // Метод для отображения списка менеджеров
        public IActionResult Index()
        {
            // Получаем список менеджеров из общего сервиса
            var managers = _dataService.GetManagers();
            return View(managers);
        }
    }
}
