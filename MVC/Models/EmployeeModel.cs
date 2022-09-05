using Domain.Employee;
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
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Stanowisko")]
        public string RoleString {
            get
            {
                switch (EnumRole)
                {
                    case Role.Programer:
                        return "Programista";

                    case Role.ProjectManager:
                        return "Menedżer projektu";

                    case Role.Qa:
                        return "QA";

                    default:
                        return "";
                }
            }

            set { } 
        }

        public Role EnumRole { get; set; }

    }
}
