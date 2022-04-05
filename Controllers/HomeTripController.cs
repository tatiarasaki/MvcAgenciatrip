using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcAgenciatrip.Controllers
{
    public class HomeTripController : Controller
    {
        //
        // GET: /HomeTrip/
        public IActionResult Index()
        {
            return View();
        }

        //
        // GET: /HomeTrip/Destinos/

        public IActionResult Destino(string nome, int numTimes = 1)
        {
               ViewData["Message"] = "Olá " + nome;
               ViewData["NumTimes"] = numTimes; 

               return View();
        }

        //
        // GET: /HomeTrip/Promoções/

        public IActionResult Promocao()
        {
            return View();
        }

        //
        // GET: /HomeTrip/Contato/

        public IActionResult Contato()
        {
            return View();
        }
    }
}
