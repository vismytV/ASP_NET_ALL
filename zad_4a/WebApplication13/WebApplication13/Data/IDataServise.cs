using WebApplication13.Models;

namespace WebApplication13.Data
{
    public interface IDataServise
    {
        // Методы для работы с авто
        List<Car> GetGar();
        void AddCar(Car car);
        void DeleteCar(int carId);
        void EditCar(Car car);
        List<Car> SearchCars(string searchString);

        List<InfoJson> GetInfoJson();
    }
}
