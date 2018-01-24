using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.DataModel
{
    [Table("TransDetailPenjualan")]
    public class DetailPenjualan: BaseTable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int IdHeaderPenjualan { get; set; }

        public int IdBarang { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Harga { get; set; }

        [Column(TypeName = "decimal")]
        public decimal JumlahBarang { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Total { get; set; }

        //[ForeignKey("IdHeaderPenjualan")]
        //public virtual HeaderPenjualan HeaderPenjualan { get; set; }

        //[ForeignKey("IdBarang")]
        //public virtual Barang Barang { get; set; }
    }
}
