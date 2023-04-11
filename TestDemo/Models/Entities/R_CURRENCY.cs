using System.ComponentModel.DataAnnotations.Schema;

namespace TestDemo.Models.Entities;

public class R_CURRENCY
{

    public int Id { get; set; }
    [Column(TypeName = "varchar(60)")]
    public string Title { get; set; }
    [Column(TypeName = "varchar(3)")]
    public string Code { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public double Value { get; set; }
    [Column(TypeName = "Date")]
    public DateTime A_Date { get; set; }


}