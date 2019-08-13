using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.DataModel
{
    [Table("TransDetailPembelian")]
    public class DetailPembelian: BaseTable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int IdHeaderPembelian { get; set; }

        public int IdDetailBarang { get; set; }

        [Column(TypeName = "decimal")]
        public decimal HargaPembelian { get; set; }

        [Column(TypeName = "decimal")]
        public decimal JumlahBarang { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Total { get; set; }

        [ForeignKey("IdHeaderPembelian")]
        public virtual HeaderPembelian HeaderPembelian { get; set; }

        //[ForeignKey("IdBarang")]
        //public virtual Barang Barang { get; set; }

        //[ForeignKey("IdSupplier")]
        //public virtual Supplier Supplier { get; set; }

        [ForeignKey("IdDetailBarang")]
        public virtual DetailBarang DetailBarang { get; set; }
    }
}
