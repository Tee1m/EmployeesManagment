using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Display(Name = "Imie")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        public string SecondName { get; set; }
        [Display(Name = "Wiek")]
        public int Age { get; set; }
        [Display(Name = "nr. telefonu")]
        public string TelephoneNumber { get; set; }
    }
}
