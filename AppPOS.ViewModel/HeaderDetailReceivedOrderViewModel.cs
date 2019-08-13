using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.ViewModel
{
    public class HeaderDetailReceivedOrderViewModel
    {
        public int Id { get; set; }

        //[Display(Name = "No. Induk"), MaxLength(10)]
        //public string IdKaryawan { get; set; }

        //[Display(Name = "ID Toko"), MaxLength(10)]
        //public int? IdToko { get; set; }

        //[Display(Name = "No. Member"), MaxLength(10)]
        //public string IdPembeli { get; set; }

        [MaxLength(13)]
        public string Referensi { get; set; }

        public DateTime TanggalPembelian { get; set; }

        public List<DetailReceivedOrderViewModel> Details { get; set; }
    }

    public class DetailReceivedOrderViewModel
    {
        public int Id { get; set; }

        public int IdHeaderPembelian { get; set; }

        public int IdDetailBarang { get; set; }

        public int IdBarang { get; set; }

        public int IdSupplier { get; set; }

        [Display(Name = "Kode"), MaxLength(10)]
        public string CodeBarang { get; set; }

        [Display(Name = "Deskripsi Barang"), MaxLength(50)]
        public string Deskripsi { get; set; }

        [Display(Name = "Harga Pembelian")]
        public decimal HargaPembelian { get; set; }

        [Display(Name = "Jumlah Barang")]
        public decimal JumlahBarang { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Total { get; set; }
    }
}
