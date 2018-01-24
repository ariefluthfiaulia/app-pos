using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.DataModel
{
    [Table("MstToko")]
    public class Toko : BaseTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Column(TypeName = "varchar"), MaxLength(30), Required]
        public string Nama { get; set; }

        [Column(TypeName = "varchar"), MaxLength(500)]
        public string Alamat { get; set; }

        [Column(TypeName = "varchar"), MaxLength(14)]
        public string NoTelp { get; set; }

        //public virtual ICollection<HeaderPembelian> HeaderPembelians { get; set; }

        //public virtual ICollection<HeaderPenjualan> HeaderPenjualans { get; set; }
    }
}
