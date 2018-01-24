using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.ViewModel
{
    public class SupplierViewModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nama { get; set; }

        [MaxLength(500)]
        public string Alamat { get; set; }

        [Display(Name ="No. Telepon"), MaxLength(14)]
        public string NoTelp { get; set; }

        public bool IsActivated { get; set; }
    }
}
