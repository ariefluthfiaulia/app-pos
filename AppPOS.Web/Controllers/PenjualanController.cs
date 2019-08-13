using AppPOS.Repository;
using AppPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPOS.Web.Controllers
{
    public class PenjualanController : Controller
    {
        // GET: Penjualan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HeaderPenjualan()
        {
            return PartialView();
        }

        public ActionResult GetItemById(int id)
        {
            return PartialView(PenjualanRepo.GetDetailById(id));
        }

        [HttpPost]
        public ActionResult Save(HeaderDetailPenjualanViewModel model)
        {
            ReturnValueViewModel result = PenjualanRepo.SaveSelling(model);
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult HapusBarang(DetailPenjualanViewModel model)
        {
            if (PenjualanRepo.HapusBarang(model))
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = PenjualanRepo.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}