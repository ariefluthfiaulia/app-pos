using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.ViewModel
{
    public class DetailBarangViewModel
    {
        public int Id { get; set; }

        public int IdBarang { get; set; }

        public int IdSupplier { get; set; }

        [MaxLength(50)]
        public string NamaSupplier { get; set; }

        [MaxLength(10)]
        public string Code { get; set; }

        [Display(Name ="Deskripsi"), MaxLength(50)]
        public string Deskripsi { get; set; }

        [Display(Name="Harga Pembelian")]
        public decimal HargaPembelian { get; set; }

        //[Display(Name = "Harga Penjualan")]
        //public decimal HargaPenjualan { get; set; }

        public int Stok { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActivated { get; set; }
    }
}
