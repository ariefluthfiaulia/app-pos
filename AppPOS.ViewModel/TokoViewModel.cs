using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.ViewModel
{
    public class TokoViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Nama Toko")]
        public string Nama { get; set; }

        public string Alamat { get; set; }

        public string NoTelp { get; set; }
    }
}
