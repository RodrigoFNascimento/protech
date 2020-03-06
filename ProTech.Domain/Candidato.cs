using System.Collections.Generic;

namespace ProTech.Domain
{
    public class Candidato
    {
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public List<Formacao> Formacao { get; set; }
        public int ExperienciaTotal { get; set; }
        public List<Experiencia> Experiencia { get; set; }
        public List<ExperienciaEmpresa> ExperienciaEmpresas { get; set; }
    }
}
