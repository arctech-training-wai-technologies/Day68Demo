using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Data.Models;

public class Employee
{
    public int Id { get; set; }

    [Unicode(false)]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    public DateTime? DateOfBirth { get; set; }

    [Unicode(false)]
    [StringLength(250)]
    public string Address { get; set; } = null!;

    [Unicode(false)]
    [Column(TypeName = "char(1)")]
    public char Gender { get; set; }
}
