using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.NewModels;

namespace WebApplication4.Controllers
{
    public class BandsController : Controller
    {

        CompanyEntities obiektCompany;
        public BandsController()//konstruktor
        {
            obiektCompany = new CompanyEntities();
        }


        // GET: Artists
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Index(BandsNewModel obiektBandow)
        {

            Band b = new Band()

            {
                bands_name = obiektBandow.bands_name

            };

            obiektCompany.Bands.Add(b);
            obiektCompany.SaveChanges();

            return Json(new { message = "Band dodany", success = true }, JsonRequestBehavior.AllowGet);


        }

        public PartialViewResult WyswietlBand()
        {
            IEnumerable<BandsNewModel> WysBand =
                (from objband in obiektCompany.Bands

                 select new BandsNewModel()
                 {
                     bands_name = objband.bands_name,


                 }).ToList();

            return PartialView("NazwaBandow", WysBand);
        }


    }
}


