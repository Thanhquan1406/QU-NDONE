namespace Bida.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUANLI")]
    public partial class QUANLI
    {
        [Key]
        [StringLength(50)]
        public string MANHANVIEN { get; set; }

        [StringLength(100)]
        public string TENNHANVIEN { get; set; }

        public bool? CALAM { get; set; }

        [StringLength(100)]
        public string PASSNV { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
