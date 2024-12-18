using Microsoft.AspNetCore.Mvc;
using WebApplication13.Data;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class CarServiseController : Controller
    {

        private readonly IDataServise _dataService;

        // Внедряем сервис через конструктор
        public CarServiseController(IDataServise dataService)
        {
            _dataService = dataService;
        }

        // Виведення усіх авто
        public IActionResult Index()
        {
            // Получаем список машин
            List<Car> cars;
            List<InfoJson> infoJson;

            cars = _dataService.GetGar();

            // Получаем список InfoJson
            infoJson = _dataService.GetInfoJson();

            // Передаём оба списка в представление через ViewBag
            ViewData["Cars"] = cars;
            ViewData["InfoJson"] = infoJson;

			
			//var newCar = new Car(); // Пустой объект для формы
			return View(); // Передаём пустой объект модели

        }

        [HttpPost]
        public IActionResult Index(Car car)
        {
			_dataService.AddCar(car);

			return RedirectToAction(nameof(Index));

		}
    }
}
