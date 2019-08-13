using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.DataModel
{
    [Table("MstKaryawan")]
    public class Karyawan : BaseTable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key, Column(TypeName = "varchar"), MaxLength(10), Required]
        public string NoInduk { get; set; }

        //public int IdToko { get; set; }

        [Column(TypeName = "varchar"), MaxLength(30), Required]
        public string NamaDepan { get; set; }

        [Column(TypeName = "varchar"), MaxLength(30)]
        public string NamaTengah { get; set; }

        [Column(TypeName = "varchar"), MaxLength(30)]
        public string NamaBelakang { get; set; }

        [Column(TypeName = "varchar"), MaxLength(500)]
        public string Alamat { get; set; }

        [Column(TypeName = "varchar"), MaxLength(30)]
        public string TempatLahir { get; set; }

        public DateTime TanggalLahir { get; set; }

        [Column(TypeName = "varchar"), MaxLength(1)]
        [Required]
        public string JenisKelamin { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActivated { get; set; }

        //[ForeignKey("IdToko")]
        //public virtual Toko Toko { get; set; }

        public virtual ICollection<HeaderPenjualan> HeaderPenjualans { get; set; }

        public virtual ICollection<HeaderPembelian> HeaderPembelians { get; set; }
    }
}
