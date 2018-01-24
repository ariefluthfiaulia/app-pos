using AppPOS.Repository;
using AppPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPOS.Web.Controllers
{
    public class KaryawanController : Controller
    {
        // GET: Karyawan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return PartialView(KaryawanRepo.GetAll());
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(KaryawanViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (KaryawanRepo.Update(model))
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = KaryawanRepo.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Edit(int id)
        {
            KaryawanViewModel model = KaryawanRepo.GetById(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(KaryawanViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (KaryawanRepo.Update(model))
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = KaryawanRepo.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Details(int id)
        {
            ViewBag.KaryawanList = new SelectList(KaryawanRepo.GetAll());
            KaryawanViewModel model = KaryawanRepo.GetById(id);
            return PartialView(model);
        }

        public ActionResult Delete(int id)
        {
            ViewBag.KaryawanList = new SelectList(KaryawanRepo.GetAll(), "Id", "Description");
            KaryawanViewModel model = KaryawanRepo.GetById(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            if (KaryawanRepo.DeleteById(id))
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = KaryawanRepo.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}