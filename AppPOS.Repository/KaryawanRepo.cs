using AppPOS.DataModel;
using AppPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.Repository
{
    public class KaryawanRepo
    {
        public static string Message = string.Empty;

        public static List<KaryawanViewModel> GetAll()
        {
            List<KaryawanViewModel> result = new List<KaryawanViewModel>();
            using (var db = new PosContext())
            {
                result = (from kar in db.Mst_Karyawans
                          select new KaryawanViewModel
                          {
                              Id = kar.Id,
                              NoInduk = kar.NoInduk,
                              NamaDepan = kar.NamaDepan,
                              NamaTengah = kar.NamaTengah,
                              NamaBelakang = kar.NamaBelakang,
                              Alamat = kar.Alamat,
                              TempatLahir = kar.TempatLahir,
                              TanggalLahir = kar.TanggalLahir,
                              JenisKelamin = kar.JenisKelamin,
                              IsActivated = kar.IsActivated
                          }).ToList();
            }
            return result;
        }

        public static bool Update(KaryawanViewModel model)
        {
            bool result = true;

            try
            {
                using (var db = new PosContext())
                {
                    if (model.Id == 0)
                    {
                        Karyawan karyawan = new Karyawan();
                        karyawan.Id = model.Id;
                        karyawan.NoInduk = model.NoInduk;
                        karyawan.NamaDepan = model.NamaDepan;
                        karyawan.NamaTengah = model.NamaTengah;
                        karyawan.NamaBelakang = model.NamaBelakang;
                        karyawan.Alamat = model.Alamat;
                        karyawan.TempatLahir = model.TempatLahir;
                        karyawan.TanggalLahir = model.TanggalLahir;
                        karyawan.JenisKelamin = model.JenisKelamin;
                        karyawan.IsActivated = model.IsActivated;
                        karyawan.CreatedBy = "Rio";
                        karyawan.CreatedDate = DateTime.Now;
                        db.Mst_Karyawans.Add(karyawan);
                        db.SaveChanges();
                    }
                    else
                    {
                        Karyawan karyawan = db.Mst_Karyawans.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (karyawan != null)
                        {
                            karyawan.NoInduk = model.NoInduk;
                            karyawan.NamaDepan = model.NamaDepan;
                            karyawan.NamaTengah = model.NamaTengah;
                            karyawan.NamaBelakang = model.NamaBelakang;
                            karyawan.Alamat = model.Alamat;
                            karyawan.TempatLahir = model.TempatLahir;
                            karyawan.TanggalLahir = model.TanggalLahir;
                            karyawan.JenisKelamin = model.JenisKelamin;
                            karyawan.IsActivated = model.IsActivated;
                            karyawan.ModifiedBy = "Rio";
                            karyawan.ModifiedDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result = false;
                Message = ex.Message;
            }

            return result;
        }

        public static KaryawanViewModel GetById(int id)
        {
            KaryawanViewModel result = new KaryawanViewModel();

            using (var db = new PosContext())
            {
                result = (from kar in db.Mst_Karyawans
                          where kar.Id == id
                          select new KaryawanViewModel
                          {
                              Id = kar.Id,
                              NoInduk = kar.NoInduk,
                              NamaDepan = kar.NamaDepan,
                              NamaTengah = kar.NamaTengah,
                              NamaBelakang = kar.NamaBelakang,
                              Alamat = kar.Alamat,
                              TempatLahir = kar.TempatLahir,
                              TanggalLahir = kar.TanggalLahir,
                              JenisKelamin = kar.JenisKelamin,
                              IsActivated = kar.IsActivated
                          }).FirstOrDefault();
            }
            return result;
        }

        public static bool DeleteById(int id)
        {
            bool result = true;
            try
            {
                using (var db = new PosContext())
                {
                    Karyawan karyawan = db.Mst_Karyawans.Where(d => d.Id == id).FirstOrDefault();
                    db.Mst_Karyawans.Remove(karyawan);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                result = false;
                Message = ex.Message;
            }
            return result;
        }
    }
}
