using AppPOS.DataModel;
using AppPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.Repository
{
    public class TokoRepo
    {
        public static string Message = string.Empty;

        public static List<TokoViewModel> GetAll()
        {
            List<TokoViewModel> result = new List<TokoViewModel>();
            using (var db = new PosContext())
            {
                result = (from tk in db.Mst_Toko
                          select new TokoViewModel
                          {
                              Id = tk.Id,
                              Nama = tk.Nama,
                              Alamat = tk.Alamat,
                              NoTelp = tk.NoTelp
                          }).ToList();
            }
            return result;
        }

        public static bool Update(TokoViewModel model)
        {
            bool result = true;

            try
            {
                using (var db = new PosContext())
                {
                    if (model.Id == 0)
                    {
                        Toko toko = new Toko();
                        toko.Id = model.Id;
                        toko.Nama = model.Nama;
                        toko.Alamat = model.Alamat;
                        toko.NoTelp = model.NoTelp;
                        toko.CreatedBy = "Rio";
                        toko.CreatedDate = DateTime.Now;
                        db.Mst_Toko.Add(toko);
                        db.SaveChanges();
                    }
                    else
                    {
                        Toko toko = db.Mst_Toko.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (toko != null)
                        {
                            toko.Nama = model.Nama;
                            toko.Alamat = model.Alamat;
                            toko.NoTelp = model.NoTelp;
                            toko.ModifiedBy = "Rio";
                            toko.ModifiedDate = DateTime.Now;
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
        public static TokoViewModel GetById(int id)
        {
            TokoViewModel result = new TokoViewModel();

            using (var db = new PosContext())
            {
                result = (from tk in db.Mst_Toko
                          where tk.Id == id
                          select new TokoViewModel
                          {
                              Id = tk.Id,
                              Nama = tk.Nama,
                              Alamat = tk.Alamat,
                              NoTelp = tk.NoTelp
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
                    Toko toko = db.Mst_Toko.Where(d => d.Id == id).FirstOrDefault();
                    db.Mst_Toko.Remove(toko);
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
