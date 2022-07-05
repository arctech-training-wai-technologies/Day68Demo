using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeCrud.RepositoryPattern.RepositoryBase;

namespace EmployeeCrud.Data.Models;

public class Salary : DataModelBase
{
    [Column(TypeName = "decimal(15, 2)")]
    public decimal Basic { get; set; }

    [Column(TypeName = "decimal(15, 2)")]
    public decimal Hra { get; set; }

    [Column(TypeName = "decimal(15, 2)")]
    public decimal Da { get; set; }

    [Column(TypeName = "decimal(15, 2)")]
    public decimal Bonus { get; set; }

    [Column(TypeName = "date")]
    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
    public DateTime EffectiveFrom { get; set; } = DateTime.Now;
    
    public int EmployeeRefId { get; set; }

    [ForeignKey(nameof(EmployeeRefId))]
    public Employee? EmployeeRef { get; set; }
}