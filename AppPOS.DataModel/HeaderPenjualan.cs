using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.DataModel
{
    [Table("TransHeaderPenjualan")]
    public class HeaderPenjualan: BaseTable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //public string IdKaryawan { get; set; }

        //public int? IdToko { get; set; }

        public string IdPembeli { get; set; }

        [Column(TypeName = "varchar"), MaxLength(13)]
        public string Referensi { get; set; }

        public DateTime TanggalPenjualan { get; set; }

        //[ForeignKey("IdKaryawan")]
        //public virtual Karyawan Karyawan { get; set; }

        //[ForeignKey("IdToko")]
        //public virtual Toko Toko { get; set; }

        [ForeignKey("IdPembeli")]
        public virtual Pembeli Pembeli { get; set; }

        public virtual ICollection<DetailPenjualan> DetailPenjualans { get; set; }
    }
}
