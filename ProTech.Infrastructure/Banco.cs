using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using ProTech.Domain;

namespace ProTech.Infrastructure
{
    public static class Banco
    {
        private static string GetCaminhoArquivo()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            baseDir = baseDir.Replace(@"\ProTech\ProTech", @"\ProTech\ProTech.Infrastructure");
            return Path.Combine(baseDir, "candidato.json");
        }

        public static Candidato ConsultarCandidato()
        {
            string json = File.ReadAllText(GetCaminhoArquivo());
            return JsonSerializer.Deserialize<Candidato>(json);
        }

        public static void SalvarCandidato(Candidato candidato)
        {
            string json = JsonSerializer.Serialize(candidato);
            File.WriteAllText(GetCaminhoArquivo(), json);
        }
    }
}
