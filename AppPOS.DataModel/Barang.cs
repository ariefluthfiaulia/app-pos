using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.DataModel
{
    [Table("MstBarang")]
    public class Barang: BaseTable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar"), MaxLength(10)]
        public string Code { get; set; }

        //public int IdSupplier { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50)]
        public string Deskripsi { get; set; }

        //[Column(TypeName = "decimal")]
        //public decimal HargaPembelian { get; set; }

        [Column(TypeName = "decimal")]
        public decimal HargaPenjualan { get; set; }

        public int Stok { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActivated { get; set; }

        //[ForeignKey("IdSupplier")]
        //public virtual Supplier Supplier { get; set; }

        //public virtual ICollection<DetailPembelian> DetailPembelians { get; set; }

        public virtual ICollection<DetailPenjualan> DetailPenjualans { get; set; }

        public virtual ICollection<DetailBarang> DetailBarangs { get; set; }
    }
}
