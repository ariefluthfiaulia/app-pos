using AppPOS.Repository;
using AppPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPOS.Web.Controllers
{
    public class PembelianController : Controller
    {
        // GET: Pembelian
        public ActionResult Index()
        {
            ViewBag.SupplierList = new SelectList(SupplierRepo.GetAll(), "Id", "Nama");
            return View();
        }

        public ActionResult HeaderPembelian()
        {
            return PartialView();
        }

        public ActionResult GetItemById(int id)
        {
            return PartialView(PembelianRepo.GetDetailById(id));
        }

        [HttpPost]
        public ActionResult Save(HeaderDetailPembelianViewModel model)
        {
            ReturnValueViewModel result = PembelianRepo.SaveSelling(model);
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult HapusBarang(DetailPembelianViewModel model)
        {
            if (PembelianRepo.HapusBarang(model))
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = PembelianRepo.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}