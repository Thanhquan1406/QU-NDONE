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

        public int SOLUONGKHO { get; set; }

        public int PRICE { get; set; }

        public int? MABAN { get; set; }

        public int? MABIENLAI { get; set; }

        public int? SOLUONGKHACHMUA { get; set; }

        public virtual BAN BAN { get; set; }

        public virtual BIENLAI BIENLAI { get; set; }
    }
}
