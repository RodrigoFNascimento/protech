using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProTech.Controllers.API;
using ProTech.Domain;
using ProTech.Infrastructure;

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
        public MensagemRetorno AdicionarFormacao(Formacao formacao)
        {
            try
            {
                Candidato candidato = Banco.ConsultarCandidato();
                candidato.Formacao.Add(formacao);
                Banco.SalvarCandidato(candidato);
                return new MensagemRetorno()
                {
                    Codigo = 200,
                    Mensagem = "OK"
                };
            }
            catch (Exception ex)
            {
                return new MensagemRetorno
                {
                    Codigo = 500,
                    Mensagem = ex.Message
                };
            }
        }
    }
}
