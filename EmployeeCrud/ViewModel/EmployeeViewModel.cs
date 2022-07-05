using System.ComponentModel.DataAnnotations;
using EmployeeCrud.RepositoryPattern.RepositoryBase;

namespace EmployeeCrud.ViewModel;

public class EmployeeViewModel: ViewModelBase
{
    [Display(Name = "Full Name")]
    public string Name { get; set; } = null!;

    [Display(Name="Birth Date")]
    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
    public DateTime? DateOfBirth { get; set; }

    public string Address { get; set; } = null!;

    public char Gender { get; set; }

    [Display(Name = "Department Id")]
    public int DepartmentRefId { get; set; }

    [Display(Name = "Department")] 
    public string? DepartmentName { get; set; }
}