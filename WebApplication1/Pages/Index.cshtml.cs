using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using System.Linq;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        [HttpGet]
        public JsonResult OnGetListaMedidasCautelaresVehiculo(DataSourceLoadOptions loadOptions, string codigoPredial)
        {
            List<Predio> predios = new List<Predio>();

            if (!string.IsNullOrEmpty(codigoPredial))
            {
               predios.Add( GetPredioByCodigoPredial(codigoPredial));
            }

            return new JsonResult(DataSourceLoader.Load(predios, loadOptions));

        }


        private List<Predio> ListaPredios()
        {
            List<Predio> predios = new List<Predio>();

            Predio predio1 = new Predio {  CodigoPredial="0001", Avaluo=1000000 , Direccion="Palmas 42", Estrato="5"};
            Predio predio2 = new Predio { CodigoPredial = "0002", Avaluo = 2000000, Direccion = "Zona franca santander", Estrato = "4" };
            Predio predio3 = new Predio { CodigoPredial = "0003", Avaluo = 3000000, Direccion = "Edificio Montevechio", Estrato = "3" };
            Predio predio4 = new Predio { CodigoPredial = "0004", Avaluo = 4000000, Direccion = "Chico Real 2 ", Estrato = "1" };

            predios.Add(predio1);
            predios.Add(predio2);
            predios.Add(predio3);
            predios.Add(predio4);

            return predios;
        }
        private Predio GetPredioByCodigoPredial(string CodigoPredial)
        {
            Predio predio = ListaPredios().Where(s => s.CodigoPredial == CodigoPredial).FirstOrDefault();
            return predio;
        }

    }
}
