using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Data.Models;

public class Department
{
    public int Id { get; set; }

    [Required]
    [Unicode(false)]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Unicode(false)]
    [StringLength(50)]
    public string? Location { get; set; }
}