using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.DataModel
{
    [Table("MstSupplier")]
    public class Supplier: BaseTable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50)]
        public string Nama { get; set; }

        [Column(TypeName = "varchar"), MaxLength(500)]
        public string Alamat { get; set; }

        [Column(TypeName = "varchar"), MaxLength(14)]
        public string NoTelp { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActivated { get; set; }

        //public virtual ICollection<DetailPembelian> DetailPembelians { get; set; }

        //public virtual ICollection<DetailPenjualan> DetailPenjualans { get; set; }

        public virtual ICollection<DetailBarang> DetailBarangs { get; set; }
    }
}
