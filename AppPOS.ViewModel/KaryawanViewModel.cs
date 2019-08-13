using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.ViewModel
{
    public class KaryawanViewModel
    {
        public int Id { get; set; }

        [Display(Name = "No Induk")]
        public string NoInduk { get; set; }

        public string NamaDepan { get; set; }

        public string NamaTengah { get; set; }

        public string NamaBelakang { get; set; }

        [Display(Name = "Nama Lengkap")]
        public string NamaLengkap
        {
            get
            {
                return (string.IsNullOrEmpty(NamaDepan) ? "" : NamaDepan + " ") +
                    (string.IsNullOrEmpty(NamaTengah) ? "" : NamaTengah + " ") +
                    (string.IsNullOrEmpty(NamaBelakang) ? "" : NamaBelakang);
            }
        }

        [MaxLength(500)]
        public string Alamat { get; set; }

        public string TempatLahir { get; set; }

        [Display(Name = "Tanggal Lahir"), DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TanggalLahir { get; set; }

        [Display(Name = "Tempat Tanggal Lahir ")]
        public string TempatTanggalLahir
        {
            get
            {
                return TempatLahir + ", " + TanggalLahir.ToString("dd-MMM-yy");
            }
        }

        [MaxLength(1), Required]
        public string JenisKelamin { get; set; }

        [Display(Name ="Jenis Kelamin")]
        public string JenisKelaminDesc
        {
            get
            {
                if (JenisKelamin == "L")
                    return "Laki-Laki";
                else if (JenisKelamin == "P")
                    return "Perempuan";
                else
                    return "";
            }
        }

        [Display(Name = "Is Activated?")]
        public bool IsActivated { get; set; }
    }
}
