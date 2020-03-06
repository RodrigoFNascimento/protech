using ProTech.Domain;
using ProTech.Infrastructure;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProTech.Controllers
{
    public class CandidatoApiController : ApiController
    {
        [HttpGet]
        public Candidato ConsultarCandidato()
        {
            try
            {
                Candidato c = Banco.ConsultarCandidato();
                return c;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        public HttpResponseMessage AdicionarFormacao(Formacao formacao)
        {
            try
            {
                Candidato candidato = Banco.ConsultarCandidato();
                if (!IsValid(formacao))
                    throw new Exception("Formação inválida");
                candidato.Formacao.Add(formacao);
                Banco.SalvarCandidato(candidato);

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
        }

        /// <summary>
        /// Valida os dados da formação.
        /// </summary>
        /// <param name="formacao">Formação a ser validada.</param>
        /// <returns>
        /// <c>true</c> caso a formação seja válida,
        /// <c>false</c> caso contrário.
        /// </returns>
        private bool IsValid(Formacao formacao)
        {
            if (formacao.Curso.Length > 150)
                return false;
            if (formacao.Status != "Concluido"
                && formacao.Status != "Em Andamento"
                && formacao.Status != "Trancado")
                return false;

            return true;
        }
    }
}
