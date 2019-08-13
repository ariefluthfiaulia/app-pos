using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.DataModel
{
    [Table("MstDetailBarang")]
    public class DetailBarang:BaseTable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int IdBarang { get; set; }

        public int IdSupplier { get; set; }

        [Column(TypeName = "decimal")]
        public decimal HargaPembelian { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActivated { get; set; }

        [ForeignKey("IdSupplier")]
        public virtual Supplier Supplier { get; set; }

        [ForeignKey("IdBarang")]
        public virtual Barang Barang { get; set; }

        public virtual ICollection<DetailPembelian> DetailPembelians { get; set; }

        //public virtual ICollection<DetailPenjualan> DetailPenjualans { get; set; }
    }
}
