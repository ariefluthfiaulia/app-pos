using AppPOS.Repository;
using AppPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPOS.Web.Controllers
{
    public class ReturPenjualanController : Controller
    {
        // GET: ReturPenjualan
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
            return PartialView(ReturPenjualanRepo.GetDetailById(id));
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
            return PartialView(ReturPenjualanRepo.ListBarang(noReferensi));
        }


        //public ActionResult ReturBarang(int IdHeaderPenjualan, int IdBarang)
        //{
        //    PembeliViewModel model = ReturPenjualanRepo.ReturBarang(IdHeaderPenjualan, IdBarang);
        //    return PartialView(model);
        //}

        public ActionResult Edit(int idBarang, int idHeaderPenjualan)
        {
            //ViewBag.SupplierList = new SelectList(SupplierRepo.GetAll(), "Id", "Description");
            DetailReturPenjualanViewModel model = ReturPenjualanRepo.GetById(idBarang, idHeaderPenjualan);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(DetailReturPenjualanViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (ReturPenjualanRepo.Update(model))
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = ReturPenjualanRepo.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
            }
        }

        //[HttpPost]
        //public ActionResult ReturBarang(PembeliViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (PembeliRepo.Update(model))
        //        {
        //            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json(new { success = false, message = PembeliRepo.Message }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    else
        //    {
        //        return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}