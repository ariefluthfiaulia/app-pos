using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.DataModel
{
    [Table("TransHeaderPembelian")]
    public class HeaderPembelian: BaseTable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string IdKaryawan { get; set; }

        public int IdToko { get; set; }

        public DateTime TanggalPembelian { get; set; }

        [ForeignKey("IdKaryawan")]
        public virtual Karyawan Karyawan { get; set; }

        //[ForeignKey("IdToko")]
        //public virtual Toko Toko { get; set; }

        //public virtual ICollection<DetailPembelian> DetailPembelians { get; set; }
    }
}
