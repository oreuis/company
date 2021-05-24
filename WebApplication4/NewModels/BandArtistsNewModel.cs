using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.NewModels
{
    public class BandArtistsNewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string nick { get; set; }

        public int id_bands { get; set; }
        public string bands_name { get; set; }


        public List<SelectListItem>ListaZespolow { get; set; }
        public List<SelectListItem> ListaArtystow { get; set; }

    }

}