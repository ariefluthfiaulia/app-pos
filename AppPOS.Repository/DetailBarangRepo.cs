using AppPOS.DataModel;
using AppPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.Repository
{
    public class DetailBarangRepo
    {
        public static string Message = string.Empty;

        public static List<DetailBarangViewModel> GetAll()
        {
            return GetAll(0);
        }

        public static List<DetailBarangViewModel> GetAll(int IdSupplier)
        {
            List<DetailBarangViewModel> result = new List<DetailBarangViewModel>();
            using (var db = new PosContext())
            {
                result = (from d in db.Mst_DetailBarangs
                              join b in db.Mst_Barangs
                              on d.IdBarang equals b.Id
                              where d.IdSupplier == (IdSupplier > 0 ? IdSupplier : d.IdSupplier)
                          select new DetailBarangViewModel
                          {
                              Id = d.Id,
                              IdSupplier = d.IdSupplier,
                              IdBarang = d.IdBarang,
                              Code = b.Code,
                              Deskripsi = b.Deskripsi,
                              HargaPembelian = d.HargaPembelian,
                              //HargaPenjualan=d.HargaPenjualan,
                              //Stok = d.Stok,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }
    }
}
