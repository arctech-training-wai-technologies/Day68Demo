using System.ComponentModel.DataAnnotations;
using EmployeeCrud.RepositoryPattern.RepositoryBase;

namespace EmployeeCrud.ViewModel;

public class DepartmentViewModel : ViewModelBase
{
    [Display(Name = "Department")]
    public string Name { get; set; } = null!;

    public string? Location { get; set; }
}