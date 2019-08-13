using AppPOS.DataModel;
using AppPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.Repository
{
    public class PembelianRepo
    {
        public static string Message = string.Empty;
        public static DetailPembelianViewModel GetDetailById(int id)
        {
            DetailPembelianViewModel result = new DetailPembelianViewModel();
            using (var db = new PosContext())
            {
                result = (from d in db.Mst_DetailBarangs
                          join b in db.Mst_Barangs
                          on d.IdBarang equals b.Id
                          //join h in db.Trans_HeaderPenjualans
                          //on d.IdHeaderPenjualan equals h.Id
                          where d.Id == id
                          select new DetailPembelianViewModel
                          {
                              IdDetailBarang = d.Id,
                              IdSupplier = d.IdSupplier,
                              CodeBarang = b.Code,
                              Deskripsi = b.Deskripsi,
                              HargaPembelian = d.HargaPembelian
                          }).FirstOrDefault();
            }
            return result;
        }

        public static ReturnValueViewModel SaveSelling(HeaderDetailPembelianViewModel model)
        {
            ReturnValueViewModel result = new ReturnValueViewModel();
            result.Success = true;
            result.Referensi = GetNewReference();

            try
            {
                using (var db = new PosContext())
                {
                    HeaderPembelian ph = new HeaderPembelian();
                    ph.Id = 1;
                    //ph.IdPembeli = model.IdPembeli;
                    ph.Referensi = result.Referensi;
                    ph.TanggalPembelian = DateTime.Now;
                    ph.CreatedDate = DateTime.Now;
                    ph.CreatedBy = "Arief";

                    db.Trans_HeaderPembelians.Add(ph);

                    foreach (var item in model.Details)
                    {
                        DetailPembelian pd = new DetailPembelian();
                        pd.IdHeaderPembelian = ph.Id;
                        pd.IdDetailBarang = item.IdDetailBarang;
                        pd.HargaPembelian = item.HargaPembelian;
                        pd.JumlahBarang = item.JumlahBarang;
                        pd.Total = item.HargaPembelian * item.JumlahBarang; //item.Amount;
                        pd.CreatedBy = "Arief";
                        pd.CreatedDate = DateTime.Now;

                        db.Trans_DetailPembelians.Add(pd);
                    }

                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.InnerException.ToString();
            }
            return result;
        }

        public static string GetNewReference()
        {
            //SLS -> Sales/Selling
            //1801 -> 2 dig thn, 2 dig bulan
            //0001 -> Increment
            //Setiap ganti bulan, increament diawali dari 1
            //SLS-1801-0001
            string NewRef = string.Format("PUR-{0}{1}-", DateTime.Now.ToString("yy"), DateTime.Now.Month.ToString("D2"));
            int NewIncrement = 1;
            using (var db = new PosContext())
            {
                var result = (from sh in db.Trans_HeaderPembelians
                              where sh.Referensi.Contains(NewRef)
                              select new { id = sh.Id, referensi = sh.Referensi })
                              .OrderByDescending(x => x.referensi)
                              .FirstOrDefault();
                if (result != null)
                {
                    string[] OldReff = result.referensi.Split('-');
                    NewIncrement = int.Parse(OldReff[2]) + 1;
                }
                NewRef += NewIncrement.ToString("D4");
            }
            return NewRef;
        }

        public static bool HapusBarang(DetailPembelianViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new PosContext())
                {
                    DetailPembelian es = db.Trans_DetailPembelians.Where(o => o.IdHeaderPembelian == model.IdHeaderPembelian && o.IdDetailBarang == model.IdDetailBarang).FirstOrDefault();
                    if (es != null)
                    {
                        db.Trans_DetailPembelians.Remove(es);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                result = false;
            }
            return result;
        }
    }
}
