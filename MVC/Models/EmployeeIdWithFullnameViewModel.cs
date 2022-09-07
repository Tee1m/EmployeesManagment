using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class EmployeeIdWithFullnameViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Pracownik")]
        public string FullName { get; set; }
    }
}
