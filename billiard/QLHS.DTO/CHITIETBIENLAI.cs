namespace Bida.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETBIENLAI")]
    public partial class CHITIETBIENLAI
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string MAKH { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string MABIENLAI { get; set; }

        [Column(TypeName = "money")]
        public decimal? TONGTIEN { get; set; }

        public int? SOGIO { get; set; }
    }
}
