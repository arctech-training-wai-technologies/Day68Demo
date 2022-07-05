using System.ComponentModel.DataAnnotations;
using EmployeeCrud.RepositoryPattern.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Data.Models;

public class Department : DataModelBase
{
    [Required]
    [Unicode(false)]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Unicode(false)]
    [StringLength(50)]
    public string? Location { get; set; }
}