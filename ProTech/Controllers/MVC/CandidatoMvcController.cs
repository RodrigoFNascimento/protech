using ProTech.Domain;
using ProTech.Infrastructure;
using System.Web.Mvc;

namespace ProTech.Controllers
{
    public class CandidatoMvcController : Controller
    {
        // GET: CandidatoMvc
        public ActionResult Index()
        {
            Candidato candidato = Banco.ConsultarCandidato();
            ViewBag.Message = candidato;
            return View();
        }
    }
}