using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class DataService : IDataService
    {
        

        // Списки для хранения данных
        private static List<Employee> _employees = new List<Employee>()
        {
            new Employee {
                Id=1,FirstName="Микола", LastName="Буц", DenNarodg=new DateTime(1975,1,1),
                Zarplata=15000},

            new Employee {
                Id=2,FirstName="Іван", LastName="Нога", DenNarodg=new DateTime(1980,11,7),
                Zarplata=15000}
        };


        private static List<Manager> _managers = new List<Manager>()
        {
         new Manager {
                Id=1,FirstName="Семен", LastName="Вода", DenNarodg=new DateTime(1975,10,10),
                Zarplata=25000, EmployeeCount = 2}
        };

        public List<Employee> GetEmployees()
        {
            return _employees;
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public List<Manager> GetManagers()
        {
            return _managers;
        }

        public void AddManager(Manager manager)
        {
            _managers.Add(manager);
        }
    }

}
