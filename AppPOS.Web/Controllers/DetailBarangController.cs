using AppPOS.Repository;
using AppPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPOS.Web.Controllers
{
    public class DetailBarangController : Controller
    {
        // GET: DetailBarang
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListWithSelect()
        {
            return PartialView(DetailBarangRepo.GetAll());
        }

        public ActionResult ListWithSelectSupplier(int IdSupplier)
        {
            return PartialView(DetailBarangRepo.GetAll(IdSupplier));
        }
    }
}