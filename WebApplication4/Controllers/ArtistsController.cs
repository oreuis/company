using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.NewModels;

namespace WebApplication4.Controllers
{
    public class ArtistsController : Controller
    {


        CompanyEntities obiektCompany;
        public ArtistsController()//konstruktor
        {
            obiektCompany = new CompanyEntities();
        }


        // GET: Artists
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Index(ArtistsNewModel obiektArtystow)
        {

            Artist artycha = new Artist()
            {
                name = obiektArtystow.name,
                surname = obiektArtystow.surname,
                nick = obiektArtystow.nick

            };

            obiektCompany.Artists.Add(artycha);
            obiektCompany.SaveChanges();

            return Json(new { message = "Artysta dodany", success = true }, JsonRequestBehavior.AllowGet);


        }

        public PartialViewResult WyswietlArtist()
        {
            IEnumerable<ArtistsNewModel> WysArt =
                (from objart in obiektCompany.Artists

                 select new ArtistsNewModel()
                 {
                     name = objart.name,
                     surname = objart.surname,
                     nick = objart.nick


                 }).ToList();

            return PartialView("NazwaArtystow", WysArt);
        }


    }
}
