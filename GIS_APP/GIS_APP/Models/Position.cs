using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("tb_positions")]
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        [Column("latitude")]
        public double lat { get; set; }
        [Column("longitude")]
        public double lng { get; set; }

        [ForeignKey("area")]
        public long area_id { get; set; }
        public virtual Area area { get; set; }

        public virtual List<Point> lsPoints { get; set; }
    }
}