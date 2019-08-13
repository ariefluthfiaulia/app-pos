using AppPOS.DataModel;
using AppPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.Repository
{
    public class ReturPenjualanRepo
    {
        public static string Message = string.Empty;
        public static DetailReturPenjualanViewModel GetDetailById(int id)
        {
            DetailReturPenjualanViewModel result = new DetailReturPenjualanViewModel();
            using (var db = new PosContext())
            {
                result = (from b in db.Mst_Barangs
                          where b.Id == id
                          select new DetailReturPenjualanViewModel
                          {
                              IdBarang = b.Id,
                              //IdSupplier = d.IdSupplier,
                              CodeBarang = b.Code,
                              Deskripsi = b.Deskripsi,
                              //Stok = b.Stok,
                              HargaPenjualan = b.HargaPenjualan
                          }).FirstOrDefault();
            }
            return result;
        }

        public static ReturnValueViewModel SaveSelling(HeaderDetailReturPenjualanViewModel model)
        {
            ReturnValueViewModel result = new ReturnValueViewModel();
            result.Success = true;
            result.Referensi = GetNewReference();

            try
            {
                using (var db = new PosContext())
                {
                    HeaderPenjualan sh = new HeaderPenjualan();
                    sh.Id = 1;
                    sh.IdPembeli = model.IdPembeli;
                    sh.Referensi = result.Referensi;
                    sh.TanggalPenjualan = DateTime.Now;
                    sh.CreatedDate = DateTime.Now;
                    sh.CreatedBy = "Arief";

                    db.Trans_HeaderPenjualans.Add(sh);

                    foreach (var item in model.Details)
                    {
                        DetailPenjualan sd = new DetailPenjualan();
                        sd.IdHeaderPenjualan = sh.Id;
                        sd.IdBarang = item.IdBarang;
                        sd.HargaPenjualan = item.HargaPenjualan;
                        sd.JumlahBarang = item.JumlahBarang;
                        sd.Total = item.HargaPenjualan * item.JumlahBarang; //item.Amount;
                        sd.CreatedBy = "Arief";
                        sd.CreatedDate = DateTime.Now;

                        db.Trans_DetailPenjualans.Add(sd);
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
            string NewRef = string.Format("SLS-{0}{1}-", DateTime.Now.ToString("yy"), DateTime.Now.Month.ToString("D2"));
            int NewIncrement = 1;
            using (var db = new PosContext())
            {
                var result = (from sh in db.Trans_HeaderPenjualans
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

        public static bool HapusBarang(DetailReturPenjualanViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new PosContext())
                {
                    DetailPenjualan es = db.Trans_DetailPenjualans.Where(o => o.IdHeaderPenjualan == model.IdHeaderPenjualan && o.IdBarang == model.IdBarang).FirstOrDefault();
                    if (es != null)
                    {
                        db.Trans_DetailPenjualans.Remove(es);
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

        public static List<DetailReturPenjualanViewModel> ListBarang(string noReferensi)
        {
            List<DetailReturPenjualanViewModel> result = new List<DetailReturPenjualanViewModel>();
            using (var db = new PosContext())
            {
                result = (from b in db.Mst_Barangs
                          join dp in db.Trans_DetailPenjualans
                          on b.Id equals dp.IdBarang
                          join hp in db.Trans_HeaderPenjualans
                          on dp.IdHeaderPenjualan equals hp.Id
                          //join h in db.Trans_HeaderPenjualans
                          //on d.IdHeaderPenjualan equals h.Id
                          where hp.Referensi == noReferensi
                          select new DetailReturPenjualanViewModel
                          {
                              IdBarang = b.Id,
                              //IdSupplier = d.IdSupplier,
                              CodeBarang = b.Code,
                              Deskripsi = b.Deskripsi,
                              JumlahBarang=dp.JumlahBarang,
                              Total=dp.Total,
                              JumlahPengembalian=dp.JumlahPengembalian,
                              //Stok = b.Stok,
                              HargaPenjualan = b.HargaPenjualan
                          }).ToList();
            }
            return result;
        }

        public static DetailReturPenjualanViewModel GetById(int idBarang, int idHeaderPenjualan)
        {
            DetailReturPenjualanViewModel result = new DetailReturPenjualanViewModel();
            using (var db = new PosContext())
            {
                result = (from dp in db.Trans_DetailPenjualans
                          where dp.IdBarang == idBarang && dp.IdHeaderPenjualan==idHeaderPenjualan
                          select new DetailReturPenjualanViewModel
                          {
                              Id = dp.Id,
                              IdHeaderPenjualan = dp.IdHeaderPenjualan,
                              IdBarang = dp.IdBarang,
                              HargaPenjualan = dp.HargaPenjualan,
                              JumlahBarang=dp.JumlahBarang,
                              Total=dp.Total,
                              JumlahPengembalian=dp.JumlahPengembalian,
                              TanggalPengembalian=dp.TanggalPengembalian,
                              AlasanPengembalian=dp.AlasanPengembalian
                          }).FirstOrDefault();
            }
            return result;
        }

        public static bool Update(DetailReturPenjualanViewModel model)
        {
            bool result = true;

            try
            {
                using (var db = new PosContext())
                {
                    if (model.Id == 0)
                    {
                        DetailPenjualan detailPenjualan = new DetailPenjualan();
                        detailPenjualan.Id = model.Id;
                        detailPenjualan.IdHeaderPenjualan = model.IdHeaderPenjualan;
                        detailPenjualan.IdBarang = model.IdBarang;
                        detailPenjualan.HargaPenjualan = model.HargaPenjualan;
                        detailPenjualan.JumlahBarang = model.JumlahBarang;
                        detailPenjualan.Total = model.Total;
                        detailPenjualan.JumlahPengembalian = model.JumlahPengembalian;
                        detailPenjualan.TanggalPengembalian = model.TanggalPengembalian;
                        detailPenjualan.AlasanPengembalian = model.AlasanPengembalian;
                        detailPenjualan.CreatedBy = "Arief";
                        detailPenjualan.CreatedDate = DateTime.Now;

                        db.Trans_DetailPenjualans.Add(detailPenjualan);
                        db.SaveChanges();
                    }
                    else
                    {
                        DetailPenjualan detailPenjualan = db.Trans_DetailPenjualans.Where(d => d.Id == model.Id).FirstOrDefault();
                        if (detailPenjualan != null)
                        {
                            detailPenjualan.IdHeaderPenjualan = model.IdHeaderPenjualan;
                            detailPenjualan.IdBarang = model.IdBarang;
                            detailPenjualan.HargaPenjualan = model.HargaPenjualan;
                            detailPenjualan.JumlahBarang = model.JumlahBarang;
                            detailPenjualan.Total = model.Total;
                            detailPenjualan.JumlahPengembalian = model.JumlahPengembalian;
                            detailPenjualan.TanggalPengembalian = model.TanggalPengembalian;
                            detailPenjualan.AlasanPengembalian = model.AlasanPengembalian;
                            detailPenjualan.ModifiedBy = "Arief";
                            detailPenjualan.ModifiedDate = DateTime.Now;

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
    }
}
