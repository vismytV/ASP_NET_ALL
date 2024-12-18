using Microsoft.AspNetCore.Mvc;
using WebApplication12.Models;

// Status codes
// 100-199 - information
// 200-299 - success
// 300-399 - redirect
// 400-499 - user error
// 500 - server error

namespace WebApplication12.Controllers
{
    [ApiController]
    [Route("car")]
    public class CarController : ControllerBase
    {
        

        private static List<Car> _cars = new List<Car>()
        {
        new Car{Id = 1, Brand="Toyota", Model="kx-290",Color="blue",Year=2010},
        new Car{Id = 8, Brand="Toyota", Model="rst-1320",Color="blue",Year=2015},
        };
        private static int _nextId = 9;

        private static bool prov_povtor(Car new_car)
        {
            bool rez = false;

            var r=_cars.FirstOrDefault(c=>c.Brand==new_car.Brand && c.Year==new_car.Year 
            && c.Model==new_car.Model && c.Color==new_car.Color);
            if (r != null) { rez=true; }

            return rez;
        }

        [HttpGet]//показати машини в певній вирізкі
        public IActionResult GetCars([FromQuery] int startNom = 1, [FromQuery] int kol = 5)
        {
            //star_nom-початковий номерр авто для показу,  kol-скільки показувати авто 
            var cars = _cars.Skip(startNom - 1).Take(kol).ToList();

            return Ok(cars);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)//Отримати машину по Id
        {
            var car = _cars.FirstOrDefault(c => c.Id == id);
            if (car == null) return NotFound();
            return Ok(car);
        }

        
        [HttpGet("brand/{brand}")]
        public IActionResult GetCarsByBrand([FromRoute]string brand)//Отримати усі машини по бренду
        {
            //var cars = _cars.Where(c => c.Brand == brand).ToList();
            var cars = _cars.Where(c => c.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)).ToList();
            return Ok(cars);
        }

        
        [HttpPost]
        public IActionResult AddCar([FromBody] Car car)//Додати машину
        {
            bool rez= prov_povtor(car);

            if (rez == false)
            {
                car.Id = _nextId++;
                _cars.Add(car);
                return Created($"/cars/{car.Id}", car);
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)//Видалити машину по id
        {
            var car = _cars.FirstOrDefault(c => c.Id == id);
            if (car == null) return NotFound();
            _cars.Remove(car);
            return NoContent();
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, [FromBody] Car updatedCar)//Оновити машину
        {
            var car = _cars.FirstOrDefault(c => c.Id == id);
            if (car == null) return NotFound();
            car.Brand = updatedCar.Brand;
            car.Model = updatedCar.Model;
            car.Color = updatedCar.Color;
            car.Year = updatedCar.Year;
            return Ok(car);
        }

        
        [HttpPatch("color/{id}")]
        public IActionResult UpdateCarColor(int id, [FromBody] string color)//Оновити колір машини
        {
            var car = _cars.FirstOrDefault(c => c.Id == id);
            if (car == null) return NotFound();
            car.Color = color;
            return Ok(car);
        }

        
        [HttpDelete("batch-delete")]//Видалити кілька машин по вказаним id
        public IActionResult DeleteMultipleCars([FromBody] List<int> batch)
        {
            _cars.RemoveAll(c => batch.Contains(c.Id));
            return NoContent();
        }

        
        [HttpGet("/brands")]
        public IActionResult GetBrands()//Отримати усі бренди машин
        {
            var brands = _cars.Select(c => c.Brand).Distinct().ToArray();
            return Ok(brands);
        }
    }

}
