using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("tb_areas")]
    public class Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }
        public string name { get; set; }

        public virtual List<Position> lsPositions { get; set; }
    }
}