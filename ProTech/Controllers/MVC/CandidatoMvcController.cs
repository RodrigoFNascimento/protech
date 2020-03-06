using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProTech.Infrastructure;
using ProTech.Domain;

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