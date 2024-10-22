namespace Bida.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            BANs = new HashSet<BAN>();
            BIENLAIs = new HashSet<BIENLAI>();
        }

        [Key]
        public int MAKH { get; set; }

        [StringLength(100)]
        public string TENKH { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAN> BANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BIENLAI> BIENLAIs { get; set; }
        public KHACHHANG(string tenkh, string sdt)
        {
            TENKH = tenkh;
            SDT = sdt;
            BANs = new HashSet<BAN>();
            BIENLAIs = new HashSet<BIENLAI>();
        }
    }
}
