using AppPOS.Repository;
using AppPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPOS.Web.Controllers
{
    public class BarangController : Controller
    {
        // GET: Barang
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return PartialView(BarangRepo.GetAll());
        }

        public ActionResult Create()
        {
            ViewBag.SupplierList = new SelectList(SupplierRepo.GetAll(), "Id", "Nama");
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(BarangViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (BarangRepo.Update(model))
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = BarangRepo.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.SupplierList = new SelectList(SupplierRepo.GetAll(), "Id", "Nama");
            BarangViewModel model = BarangRepo.GetById(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(BarangViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (BarangRepo.Update(model))
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = BarangRepo.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            return PartialView(BarangRepo.GetById(id));
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            if (BarangRepo.DeleteById(id))
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = BarangRepo.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Details(int id)
        {
            ViewBag.SupplierList = new SelectList(SupplierRepo.GetAll(), "Id", "Nama");
            BarangViewModel model = BarangRepo.GetById(id);
            return PartialView(model);
        }

        //public ActionResult ListByDivision(int DivisionId)
        //{
        //    return PartialView(DepartmentRepo.GetAll(DivisionId));
        //}

        //public ActionResult ListByDepartment(int DeptId)
        //{
        //    return PartialView(JobPositionRepo.GetAll(DeptId));
        //}

        //public ActionResult ListByDepartmentJson(int DeptId)
        //{
        //    List<JobPositionViewModel> model = new List<JobPositionViewModel>();
        //    model.Add(new JobPositionViewModel() { Id = 0, Description = "Select Job Position" });
        //    foreach (var item in JobPositionRepo.GetAll(DeptId))
        //    {
        //        model.Add(new JobPositionViewModel() { Id = item.Id, Description = item.Description });
        //    }

        //    return Json(new { data = model }, JsonRequestBehavior.AllowGet);
        //}
    }
}