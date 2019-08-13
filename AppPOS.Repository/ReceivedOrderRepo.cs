using AppPOS.DataModel;
using AppPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.Repository
{
    public class ReceivedOrderRepo
    {
        public static string Message = string.Empty;
        public static DetailReceivedOrderViewModel GetDetailById(int id)
        {
            DetailReceivedOrderViewModel result = new DetailReceivedOrderViewModel();
            using (var db = new PosContext())
            {
                result = (from b in db.Mst_Barangs
                          join dbr in db.Mst_DetailBarangs
                          on b.Id equals dbr.IdBarang
                          where b.Id == id
                          select new DetailReceivedOrderViewModel
                          {
                              IdBarang = b.Id,
                              //IdSupplier = d.IdSupplier,
                              CodeBarang = b.Code,
                              Deskripsi = b.Deskripsi,
                              //Stok = b.Stok,
                              HargaPembelian = dbr.HargaPembelian
                          }).FirstOrDefault();
            }
            return result;
        }

        //public static ReturnValueViewModel SaveSelling(HeaderDetailReceivedOrderViewModel model)
        //{
        //    ReturnValueViewModel result = new ReturnValueViewModel();
        //    result.Success = true;
        //    result.Referensi = GetNewReference();

        //    try
        //    {
        //        using (var db = new PosContext())
        //        {
        //            HeaderPenjualan sh = new HeaderPenjualan();
        //            sh.Id = 1;
        //            sh.IdPembeli = model.IdPembeli;
        //            sh.Referensi = result.Referensi;
        //            sh.TanggalPenjualan = DateTime.Now;
        //            sh.CreatedDate = DateTime.Now;
        //            sh.CreatedBy = "Arief";

        //            db.Trans_HeaderPenjualans.Add(sh);

        //            foreach (var item in model.Details)
        //            {
        //                DetailPenjualan sd = new DetailPenjualan();
        //                sd.IdHeaderPenjualan = sh.Id;
        //                sd.IdBarang = item.IdBarang;
        //                sd.HargaPenjualan = item.HargaPenjualan;
        //                sd.JumlahBarang = item.JumlahBarang;
        //                sd.Total = item.HargaPenjualan * item.JumlahBarang; //item.Amount;
        //                sd.CreatedBy = "Arief";
        //                sd.CreatedDate = DateTime.Now;

        //                db.Trans_DetailPenjualans.Add(sd);
        //            }

        //            db.SaveChanges();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Success = false;
        //        result.Message = ex.InnerException.ToString();
        //    }
        //    return result;
        //}

        //public static string GetNewReference()
        //{
        //    //SLS -> Sales/Selling
        //    //1801 -> 2 dig thn, 2 dig bulan
        //    //0001 -> Increment
        //    //Setiap ganti bulan, increament diawali dari 1
        //    //SLS-1801-0001
        //    string NewRef = string.Format("SLS-{0}{1}-", DateTime.Now.ToString("yy"), DateTime.Now.Month.ToString("D2"));
        //    int NewIncrement = 1;
        //    using (var db = new PosContext())
        //    {
        //        var result = (from sh in db.Trans_HeaderPenjualans
        //                      where sh.Referensi.Contains(NewRef)
        //                      select new { id = sh.Id, referensi = sh.Referensi })
        //                      .OrderByDescending(x => x.referensi)
        //                      .FirstOrDefault();
        //        if (result != null)
        //        {
        //            string[] OldReff = result.referensi.Split('-');
        //            NewIncrement = int.Parse(OldReff[2]) + 1;
        //        }
        //        NewRef += NewIncrement.ToString("D4");
        //    }
        //    return NewRef;
        //}

        //public static bool HapusBarang(DetailReturPenjualanViewModel model)
        //{
        //    bool result = true;
        //    try
        //    {
        //        using (var db = new PosContext())
        //        {
        //            DetailPenjualan es = db.Trans_DetailPenjualans.Where(o => o.IdHeaderPenjualan == model.IdHeaderPenjualan && o.IdBarang == model.IdBarang).FirstOrDefault();
        //            if (es != null)
        //            {
        //                db.Trans_DetailPenjualans.Remove(es);
        //                db.SaveChanges();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ex.Message;
        //        result = false;
        //    }
        //    return result;
        //}

        public static List<DetailReceivedOrderViewModel> ListBarang(string noReferensi)
        {
            List<DetailReceivedOrderViewModel> result = new List<DetailReceivedOrderViewModel>();
            using (var db = new PosContext())
            {
                result = (from b in db.Mst_Barangs
                          join dbr in db.Mst_DetailBarangs
                          on b.Id equals dbr.IdBarang
                          join dp in db.Trans_DetailPembelians
                          on dbr.Id equals dp.IdDetailBarang
                          join hp in db.Trans_HeaderPembelians
                          on dp.IdHeaderPembelian equals hp.Id

                          where hp.Referensi == noReferensi
                          select new DetailReceivedOrderViewModel
                          {
                              IdBarang = b.Id,
                              CodeBarang = b.Code,
                              Deskripsi = b.Deskripsi,
                              JumlahBarang = dp.JumlahBarang,
                              Total = dp.Total,
                              HargaPembelian = dbr.HargaPembelian
                          }).ToList();
            }
            return result;
        }
    }
}
