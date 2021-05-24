using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.NewModels;

namespace WebApplication4.Controllers
{
    public class BandArtistsController : Controller
    {


        CompanyEntities obiektCompany;
        public BandArtistsController()//konstruktor
        {
            obiektCompany = new CompanyEntities();
        }


        // GET: BandArtists
        public ActionResult Index()
        {
            BandArtistsNewModel objektArtystow = new BandArtistsNewModel();

            objektArtystow.ListaArtystow = (from objArtysty in obiektCompany.Artists
                                               select new SelectListItem()
                                               {
                                                   Text = objArtysty.name,
                                                   Value = objArtysty.id.ToString()
                                               }).ToList();

            objektArtystow.ListaZespolow = (from objBandu in obiektCompany.Bands
                                            select new SelectListItem()
                                            {
                                                Text = objBandu.bands_name,
                                                Value = objBandu.id_bands.ToString()
                                            }).ToList();

            return View(objektArtystow);
        }



        [HttpPost]
        public ActionResult Index(BandArtistsNewModel obiektArtystow)
        {

            Bands_Artists artycha = new Bands_Artists()
            {
                id_artists = obiektArtystow.id,
                id_bands = obiektArtystow.id_bands
                

            };

            obiektCompany.Bands_Artists.Add(artycha);
            obiektCompany.SaveChanges();

            return Json(new { message = "Artysta dodany do zespołu", success = true }, JsonRequestBehavior.AllowGet);


        }

        public PartialViewResult WyswietlBandArtists()
        {
            IEnumerable<BandArtistsNewModel> WysBandArt =
                (from objart in obiektCompany.Bands_Artists
                 join obja in obiektCompany.Artists on objart.id_artists equals obja.id

                 join objb in obiektCompany.Bands on objart.id_bands equals objb.id_bands

                 select new BandArtistsNewModel()
                 {
                     name = obja.name,
                     surname = obja.surname,
                     nick = obja.nick,
                     bands_name = objb.bands_name


                 }).ToList();

            return PartialView("NazwaBandArtists", WysBandArt);
        }

    }
}