using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("tb_points")]
    public class Point
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        [Column("latitude")]
        public double lat { get; set; }

        [Column("longitude")]
        public double lon { get; set; }

        [ForeignKey("position")]
        public long pos_id { get; set; }
        public virtual Position position { get; set; }
    }
}