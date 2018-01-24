using AppPOS.DataModel;
using AppPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.Repository
{
    public class PembeliRepo
    {
        public static string Message = string.Empty;

        public static List<PembeliViewModel> GetAll()
        {
            List<PembeliViewModel> result = new List<PembeliViewModel>();
            using (var db = new PosContext())
            {
                result = (from pem in db.Mst_Pembeli
                          select new PembeliViewModel
                          {
                              Id = pem.Id,
                              NoMember = pem.NoMember,
                              NamaDepan = pem.NamaDepan,
                              NamaTengah = pem.NamaTengah,
                              NamaBelakang = pem.NamaBelakang,
                              Alamat = pem.Alamat,
                              TempatLahir = pem.TempatLahir,
                              TanggalLahir = pem.TanggalLahir,
                              JenisKelamin = pem.JenisKelamin,
                              IsActivated = pem.IsActivated
                          }).ToList();
            }
            return result;
        }

        public static bool Update(PembeliViewModel model)
        {
            bool result = true;

            try
            {
                using (var db = new PosContext())
                {
                    if (model.Id == 0)
                    {
                        Pembeli pembeli = new Pembeli();
                        pembeli.Id = model.Id;
                        pembeli.NoMember = model.NoMember;
                        pembeli.NamaDepan = model.NamaDepan;
                        pembeli.NamaTengah = model.NamaTengah;
                        pembeli.NamaBelakang = model.NamaBelakang;
                        pembeli.Alamat = model.Alamat;
                        pembeli.TempatLahir = model.TempatLahir;
                        pembeli.TanggalLahir = model.TanggalLahir;
                        pembeli.JenisKelamin = model.JenisKelamin;
                        pembeli.IsActivated = model.IsActivated;
                        pembeli.CreatedBy = "Rio";
                        pembeli.CreatedDate = DateTime.Now;
                        db.Mst_Pembeli.Add(pembeli);
                        db.SaveChanges();
                    }
                    else
                    {
                        Pembeli pembeli = db.Mst_Pembeli.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (pembeli != null)
                        {
                            pembeli.NoMember = model.NoMember;
                            pembeli.NamaDepan = model.NamaDepan;
                            pembeli.NamaTengah = model.NamaTengah;
                            pembeli.NamaBelakang = model.NamaBelakang;
                            pembeli.Alamat = model.Alamat;
                            pembeli.TempatLahir = model.TempatLahir;
                            pembeli.TanggalLahir = model.TanggalLahir;
                            pembeli.JenisKelamin = model.JenisKelamin;
                            pembeli.IsActivated = model.IsActivated;
                            pembeli.ModifiedBy = "Rio";
                            pembeli.ModifiedDate = DateTime.Now;
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

        public static PembeliViewModel GetById(int id)
        {
            PembeliViewModel result = new PembeliViewModel();

            using (var db = new PosContext())
            {
                result = (from pem in db.Mst_Pembeli
                          where pem.Id == id
                          select new PembeliViewModel
                          {
                              Id = pem.Id,
                              NoMember = pem.NoMember,
                              NamaDepan = pem.NamaDepan,
                              NamaTengah = pem.NamaTengah,
                              NamaBelakang = pem.NamaBelakang,
                              Alamat = pem.Alamat,
                              TempatLahir = pem.TempatLahir,
                              TanggalLahir = pem.TanggalLahir,
                              JenisKelamin = pem.JenisKelamin,
                              IsActivated = pem.IsActivated
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
                    Pembeli pembeli = db.Mst_Pembeli.Where(d => d.Id == id).FirstOrDefault();
                    db.Mst_Pembeli.Remove(pembeli);
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
