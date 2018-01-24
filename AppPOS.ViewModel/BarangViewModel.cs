using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.ViewModel
{
    public class BarangViewModel
    {
        public int Id { get; set; }

        [MaxLength(10)]
        public string Code { get; set; }

        [Display(Name = "Supplier")]
        public int IdSupplier { get; set; }

        [Display(Name = "Supplier")]
        public string NamaSupplier { get; set; }

        [DisplayName("Deskripsi")]
        public string Deskripsi { get; set; }

        [Display(Name="Harga"), Column(TypeName = "money")]
        public decimal Harga { get; set; }

        [Display(Name = "Stok")]
        public int Stok { get; set; }

        [Display(Name = "Record ini aktif?")]
        public bool IsActivated { get; set; }
    }
}
