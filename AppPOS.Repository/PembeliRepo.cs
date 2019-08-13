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
                result = (from pem in db.Mst_Pembelis
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
                        db.Mst_Pembelis.Add(pembeli);
                        db.SaveChanges();
                    }
                    else
                    {
                        Pembeli pembeli = db.Mst_Pembelis.Where(o => o.Id == model.Id).FirstOrDefault();
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
                result = (from pem in db.Mst_Pembelis
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
                    Pembeli pembeli = db.Mst_Pembelis.Where(d => d.Id == id).FirstOrDefault();
                    db.Mst_Pembelis.Remove(pembeli);
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

        public static PembeliViewModel GetByNoMember(string noMember)
        {
            PembeliViewModel result = new PembeliViewModel();
            using (var db = new PosContext())
            {
                result = (from bli in db.Mst_Pembelis
                          //join job in db.Mst_JobPositions on emp.JobPositionId equals job.Id
                          //join dep in db.Mst_Departments on job.DepartmentId equals dep.Id
                          //join div in db.Mst_Divisions on dep.DivisionId equals div.Id
                          where bli.NoMember == noMember
                          select new PembeliViewModel
                          {
                              Id = bli.Id,
                              NoMember = bli.NoMember,
                              NamaDepan = bli.NamaDepan,
                              NamaTengah = bli.NamaTengah,
                              NamaBelakang = bli.NamaBelakang,
                              Alamat = bli.Alamat,
                              TempatLahir = bli.TempatLahir,
                              TanggalLahir = bli.TanggalLahir,
                              JenisKelamin = bli.JenisKelamin,
                              IsActivated = bli.IsActivated
                          }).FirstOrDefault();
            }
            return result;
        }

        public static PembeliViewModel GetByNoReferensi(string noReferensi)
        {
            PembeliViewModel result = new PembeliViewModel();
            using (var db = new PosContext())
            {
                result = (from bli in db.Mst_Pembelis
                          join hpn in db.Trans_HeaderPenjualans on bli.NoMember equals hpn.IdPembeli
                          //join dep in db.Mst_Departments on job.DepartmentId equals dep.Id
                          //join div in db.Mst_Divisions on dep.DivisionId equals div.Id
                          where hpn.Referensi == noReferensi
                          select new PembeliViewModel
                          {
                              Id = bli.Id,
                              NoMember = bli.NoMember,
                              NamaDepan = bli.NamaDepan,
                              NamaTengah = bli.NamaTengah,
                              NamaBelakang = bli.NamaBelakang,
                              Alamat = bli.Alamat,
                              TempatLahir = bli.TempatLahir,
                              TanggalLahir = bli.TanggalLahir,
                              JenisKelamin = bli.JenisKelamin,
                              IsActivated = bli.IsActivated
                          }).FirstOrDefault();
            }
            return result;
        }


    }
}
