namespace Bida.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDER")]
    public partial class ORDER
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MADV { get; set; }

        [Required]
        [StringLength(100)]
        public string TENNUOC { get; set; }

        public int SOLUONG { get; set; }

        public int PRICE { get; set; }
    }
}
