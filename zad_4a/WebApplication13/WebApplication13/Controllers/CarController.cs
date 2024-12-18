using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication13.Data;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    [ApiController]
    [Route("car")]
    public class CarController : ControllerBase
    {
        private readonly IDataServise _carService;

        // Внедрение зависимости через конструктор
        public CarController(IDataServise carService)
        {
            _carService = carService;
        }

        [HttpGet] // Показати машини в певній вирізці або всі
		public IActionResult GetCars([FromQuery] int startNom=-1, [FromQuery] int kol=-1)
        {
            if (startNom!=-1 && kol != -1)
            {
				var cars = _carService.GetGar().Skip(startNom - 1).Take(kol).ToList();
				return Ok(cars);
			}

			var cars1 = _carService.GetGar().ToList();
			return Ok(cars1);
		}


        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            var car = _carService.GetGar().FirstOrDefault(c => c.Id == id);
            if (car == null) return NotFound();
            return Ok(car);
        }

        [HttpPost] // Додати машину
        public IActionResult AddCar([FromBody] Car car)
        {
            _carService.AddCar(car);
            return Created($"/car/{car.Id}", car);
        }

        [HttpDelete("{id}")] // Видалити машину по id
        public IActionResult DeleteCar(int id)
        {
            _carService.DeleteCar(id);
            return NoContent();
        }

        [HttpGet("brand/{brand}")] // Отримати усі машини по бренду
        public IActionResult GetCarsByBrand([FromRoute] string brand)
        {
            var cars = _carService.GetGar()
                .Where(c => c.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase))
                .ToList();
            return Ok(cars);
        }

        [HttpGet("/brands")] // Отримати усі бренди машин
        public IActionResult GetBrands()
        {
            var brands = _carService.GetGar()
                .Select(c => c.Brand)
                .Distinct()
                .ToArray();
            return Ok(brands);
        }

		[HttpPut("{id}")]
		public IActionResult UpdateCar(int id,[FromBody] Car updatedCar)//Оновити машину
        {
            
			var car = _carService.GetGar().FirstOrDefault(c => c.Id == id);
            
            if (car == null) return NotFound();
            car.Brand = updatedCar.Brand;
            car.Model = updatedCar.Model;
            car.Color = updatedCar.Color;
            car.Year = updatedCar.Year;
            return Ok(car);
        }
    }
}
