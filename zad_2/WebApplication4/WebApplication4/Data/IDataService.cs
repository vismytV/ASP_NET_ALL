using WebApplication4.Models;

namespace WebApplication4.Data
{
    public interface IDataService
    {
        List<Employee> GetEmployees();
        void AddEmployee(Employee employee);
        List<Manager> GetManagers();
        void AddManager(Manager manager);
    }
}
