using AppPOS.Repository;
using AppPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPOS.Web.Controllers
{
    public class TokoController : Controller
    {
        // GET: Toko
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return PartialView(TokoRepo.GetAll());
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(TokoViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (TokoRepo.Update(model))
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = TokoRepo.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Edit(int id)
        {
            TokoViewModel model = TokoRepo.GetById(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(TokoViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (TokoRepo.Update(model))
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = TokoRepo.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            ViewBag.KaryawanList = new SelectList(TokoRepo.GetAll(), "Id", "Description");
            TokoViewModel model = TokoRepo.GetById(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            if (TokoRepo.DeleteById(id))
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = TokoRepo.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}