using AppPOS.Repository;
using AppPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPOS.Web.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return PartialView(SupplierRepo.GetAll());
        }

        public ActionResult Create()
        {
            //ViewBag.SupplierList = new SelectList(SupplierRepo.GetAll(), "Id", "Description");
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(SupplierViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (SupplierRepo.Update(model))
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = SupplierRepo.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Edit(int id)
        {
            //ViewBag.SupplierList = new SelectList(SupplierRepo.GetAll(), "Id", "Description");
            SupplierViewModel model = SupplierRepo.GetById(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(SupplierViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (SupplierRepo.Update(model))
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = SupplierRepo.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            return PartialView(SupplierRepo.GetById(id));
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            if (SupplierRepo.DeleteById(id))
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = SupplierRepo.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Details(int id)
        {
            //ViewBag.JobPositionList = new SelectList(JobPositionRep.GetAll(), "Id", "Description");
            SupplierViewModel model = SupplierRepo.GetById(id);
            return PartialView(model);
        }
    }
}