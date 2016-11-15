
using System.ComponentModel.DataAnnotations.Schema;

[Table("tb_position")]
public class Position
{
    public long id { get; set; }

    [Column("latitude")]
    public double lat { get; set; }
    [Column("longitude")]
    public double lon { get; set; }
}