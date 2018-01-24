using AppPOS.DataModel;
using AppPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPOS.Repository
{
    public class SupplierRepo
    {
        public static string Message = string.Empty;
        public static List<SupplierViewModel> GetAll()
        {
            List<SupplierViewModel> result = new List<SupplierViewModel>();
            using (var db = new PosContext())
            {
                result = (from sup in db.Mst_Suppliers
                          select new SupplierViewModel
                          {
                              Id = sup.Id,
                              Nama = sup.Nama,
                              Alamat = sup.Alamat,
                              NoTelp = sup.NoTelp,
                              IsActivated = sup.IsActivated
                          }).ToList();
            }
            return result;
        }

        //Create dan Edit
        public static bool Update(SupplierViewModel model)
        {
            bool result = true;

            try
            {
                using (var db = new PosContext())
                {
                    if (model.Id == 0)
                    {
                        Supplier supplier = new Supplier();
                        supplier.Id = model.Id;
                        supplier.Nama = model.Nama;
                        supplier.Alamat = model.Alamat;
                        supplier.NoTelp = model.NoTelp;
                        supplier.IsActivated = model.IsActivated;
                        supplier.CreatedBy = "Arief";
                        supplier.CreatedDate = DateTime.Now;

                        db.Mst_Suppliers.Add(supplier);
                        db.SaveChanges();
                    }
                    else
                    {
                        Supplier supplier = db.Mst_Suppliers.Where(d => d.Id == model.Id).FirstOrDefault();
                        if (supplier != null)
                        {
                            supplier.Nama = model.Nama;
                            supplier.Alamat = model.Alamat;
                            supplier.NoTelp = model.NoTelp;
                            supplier.IsActivated = model.IsActivated;
                            supplier.ModifiedBy = "Arief";
                            supplier.ModifiedDate = DateTime.Now;

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

        public static SupplierViewModel GetById(int id)
        {
            SupplierViewModel result = new SupplierViewModel();
            using (var db = new PosContext())
            {
                result = (from sup in db.Mst_Suppliers
                          where sup.Id == id
                          select new SupplierViewModel
                          {
                              Id = sup.Id,
                              Nama = sup.Nama,
                              Alamat = sup.Alamat,
                              NoTelp = sup.NoTelp,
                              IsActivated = sup.IsActivated
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
                    Supplier supplier = db.Mst_Suppliers.Where(d => d.Id == id).FirstOrDefault();
                    db.Mst_Suppliers.Remove(supplier);
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
