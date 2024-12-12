using Microsoft.AspNetCore.Mvc;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IDataService _dataService;

        public EmployeeController(IDataService dataService)
        {
            _dataService = dataService;
        }

        // Страница для создания работника
        public IActionResult Create()
        {
            return View();
        }
        // Обработка формы для добавления работеика
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Employee employee)
        {
            //var existingEmployee = _dataService.GetEmployees().FirstOrDefault(e => e.FirstName == employee.FirstName
            //  && e.LastName == employee.LastName && e.DenNarodg==employee.DenNarodg);
            var existingEmployee = _dataService.GetEmployees()
    .FirstOrDefault(e => string.Equals(e.FirstName, employee.FirstName, StringComparison.Ordinal) &&
                         string.Equals(e.LastName, employee.LastName, StringComparison.Ordinal)
                         && e.DenNarodg == employee.DenNarodg);

            if (existingEmployee != null)
            {
                // Добавляем сообщение в TempData
                TempData["ErrorMessage"] = "Такий робітник вже існує в базі.";

                // Возвращаем представление с текущими данными работника
                return View(employee);
            }

            var existingManager = _dataService.GetManagers()
    .FirstOrDefault(m => string.Equals(m.FirstName, employee.FirstName, StringComparison.Ordinal) &&
                         string.Equals(m.LastName, employee.LastName, StringComparison.Ordinal)
                         && m.DenNarodg == employee.DenNarodg);

            if (existingManager != null)
            {
                // Добавляем сообщение в TempData
                TempData["ErrorMessage"] = $"{employee.FirstName} {employee.LastName} вже записаний в базі як менеджер.";
                return View(employee);
            }


            // Если данные валидны, добавляем работника
            if (ModelState.IsValid)
            {
                employee.Id = _dataService.GetEmployees().Count + 1;
                _dataService.AddEmployee(employee);
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }



        public IActionResult Index()
        {
            // Получаем список сотрудников из общего сервиса
            var employees = _dataService.GetEmployees();
            return View(employees);
        }
    }

    

}
