using AppPOS.DataModel;
using AppPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.Repository
{
    public class BarangRepo
    {
        public static string Message = string.Empty;
        public static List<BarangViewModel> GetAll()
        {
            List<BarangViewModel> result = new List<BarangViewModel>();
            using (var db = new PosContext())
            {
                result = (from brg in db.Mst_Barangs
                          join sup in db.Mst_Suppliers
                          on brg.IdSupplier equals sup.Id
                          //where dep.DivisionId == (DivisionId > 0 ? DivisionId : dep.DivisionId)
                          select new BarangViewModel
                          {
                              Id = brg.Id,
                              Code = brg.Code,
                              IdSupplier = brg.IdSupplier,
                              NamaSupplier = sup.Nama,
                              Deskripsi=brg.Deskripsi,
                              Harga=brg.Harga,
                              Stok=brg.Stok,
                              IsActivated = brg.IsActivated
                          }).ToList();
            }
            return result;
        }

        //Create dan Edit
        public static bool Update(BarangViewModel model)
        {
            bool result = true;

            try
            {
                using (var db = new PosContext())
                {
                    if (model.Id == 0)
                    {
                        Barang barang = new Barang();
                        barang.Id = model.Id;
                        barang.Code = model.Code;
                        barang.IdSupplier = model.IdSupplier;
                        barang.Deskripsi = model.Deskripsi;
                        barang.Harga = model.Harga;
                        barang.Stok = model.Stok;
                        barang.IsActivated = model.IsActivated;
                        barang.CreatedBy = "Arief";
                        barang.CreatedDate = DateTime.Now;

                        db.Mst_Barangs.Add(barang);
                        db.SaveChanges();
                    }
                    else
                    {
                        Barang barang = db.Mst_Barangs.Where(d => d.Id == model.Id).FirstOrDefault();
                        if (barang != null)
                        {
                            barang.Code = model.Code;
                            barang.IdSupplier = model.IdSupplier;
                            barang.Deskripsi = model.Deskripsi;
                            barang.Harga = model.Harga;
                            barang.Stok = model.Stok;
                            barang.IsActivated = model.IsActivated;
                            barang.ModifiedBy = "Arief";
                            barang.ModifiedDate = DateTime.Now;

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

        public static BarangViewModel GetById(int id)
        {
            BarangViewModel result = new BarangViewModel();
            using (var db = new PosContext())
            {
                result = (from brg in db.Mst_Barangs
                          join sup in db.Mst_Suppliers
                          on brg.IdSupplier equals sup.Id
                          select new BarangViewModel
                          {
                              Id = brg.Id,
                              Code = brg.Code,
                              IdSupplier=brg.IdSupplier,
                              NamaSupplier = sup.Nama,
                              Deskripsi = brg.Deskripsi,
                              Harga=brg.Harga,
                              Stok=brg.Stok,
                              IsActivated = brg.IsActivated
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
                    Barang barang = db.Mst_Barangs.Where(d => d.Id == id).FirstOrDefault();
                    db.Mst_Barangs.Remove(barang);
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
