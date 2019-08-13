using AppPOS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPOS.Web.Controllers
{
    public class ReceivedOrderController : Controller
    {
        // GET: ReceivedOrder
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
            return PartialView(ReceivedOrderRepo.GetDetailById(id));
        }

        //[HttpPost]
        //public ActionResult Save(HeaderDetailReturPenjualanViewModel model)
        //{
        //    ReturnValueViewModel result = ReturPenjualanRepo.SaveSelling(model);
        //    return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public ActionResult HapusBarang(DetailReturPenjualanViewModel model)
        //{
        //    if (ReturPenjualanRepo.HapusBarang(model))
        //    {
        //        return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(new { success = false, message = ReturPenjualanRepo.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        public ActionResult ListBarang(string noReferensi)
        {
            return PartialView(ReceivedOrderRepo.ListBarang(noReferensi));
        }
    }
}