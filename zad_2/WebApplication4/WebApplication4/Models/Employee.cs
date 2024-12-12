using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }//ім'я
        
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }//прізвище

        [Required]
        [DataType(DataType.Date)]
        public DateTime DenNarodg { get; set; }

        
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Зарплата має бути більшою за 0.")]
        public double Zarplata { get; set; }
    }
}
