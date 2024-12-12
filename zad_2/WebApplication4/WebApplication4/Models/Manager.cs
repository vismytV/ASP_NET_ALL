using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Manager : Employee
    {
        [Range(0, int.MaxValue, ErrorMessage = "Кількість підлеглих має бути більша або рівна 0.")]
        public int EmployeeCount { get; set; } // Кількість підлеглих
    }
}
