using WebApplication13.Models;

namespace WebApplication13.Data
{
    public class CarDataServise : IDataServise
    {
        private readonly List<Car> _cars; // Локальный список машин

        // Конструктор без параметров
        public CarDataServise()
        {
            // Инициализация списка машин
            _cars = new List<Car>
            {
                new Car { Id = 1, Brand = "Toyota", Model = "kx-290", Color = "blue", Year = 2010 },
                new Car { Id = 2, Brand = "Toyota", Model = "rst-1320", Color = "red", Year = 2015 }
            };
        }

        public List<Car> GetGar() => _cars;

        public void AddCar(Car car)
        {
            car.Id = _cars.Max(c => c.Id) + 1;
            _cars.Add(car);
        }

        public void DeleteCar(int carId)
        {
            var car = _cars.FirstOrDefault(c => c.Id == carId);
            if (car != null) _cars.Remove(car);
        }

        public void EditCar(Car car)
        {
            var existingCar = _cars.FirstOrDefault(c => c.Id == car.Id);
            if (existingCar != null)
            {
                existingCar.Brand = car.Brand;
                existingCar.Model = car.Model;
                existingCar.Color = car.Color;
                existingCar.Year = car.Year;
            }
        }

        public List<Car> SearchCars(string searchString)
        {
            return _cars.Where(c => c.Brand.Contains(searchString) || c.Model.Contains(searchString)).ToList();
        }

        public List<InfoJson> GetInfoJson() => new List<InfoJson>()
        {
            new InfoJson
            {
                Id = 1,
                Name = "allAvto",
                Description="<br/>  {<br/>    \"id\": ~ID авто,<br/>    \"brand\": \"~бренд \",<br/>" +
                "    \"model\": ~модель \"\",<br/>    \"color\": \"~колір\",<br/>    \"year\": ~рік випуску<br/>}"
			},
			new InfoJson
			{
				Id = 2,
				Name = "newAvto",
				Description="<br/>  {<br/>    \"brand\": \"~бренд (string)\",<br/>" +
				"    \"model\": ~модель (string)\"\",<br/>    \"color\": \"~колір (string)\",<br/>" +
				"    \"year\": ~рік випуску (int)<br/>}"
			},
		};
    }
     
}
