using AppPOS.Repository;
using AppPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPOS.Web.Controllers
{
    public class PembeliController : Controller
    {
        // GET: Pembeli
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return PartialView(PembeliRepo.GetAll());
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(PembeliViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (PembeliRepo.Update(model))
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = PembeliRepo.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Edit(int id)
        {
            PembeliViewModel model = PembeliRepo.GetById(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(PembeliViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (PembeliRepo.Update(model))
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = PembeliRepo.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Details(int id)
        {
            ViewBag.KaryawanList = new SelectList(PembeliRepo.GetAll());
            PembeliViewModel model = PembeliRepo.GetById(id);
            return PartialView(model);
        }

        public ActionResult Delete(int id)
        {
            ViewBag.KaryawanList = new SelectList(PembeliRepo.GetAll(), "Id", "Description");
            PembeliViewModel model = PembeliRepo.GetById(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            if (PembeliRepo.DeleteById(id))
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = PembeliRepo.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}