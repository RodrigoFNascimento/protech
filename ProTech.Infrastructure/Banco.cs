using ProTech.Domain;
using System;
using System.IO;
using System.Text.Json;

namespace ProTech.Infrastructure
{
    public static class Banco
    {
        /// <summary>
        /// Retorna o caminho onde está o arquivo
        /// JSON com as informações do candidato.
        /// </summary>
        /// <returns>Caminho do arquivo JSON.</returns>
        private static string GetCaminhoArquivo()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            baseDir = baseDir.Replace(@"\ProTech\ProTech", @"\ProTech\ProTech.Infrastructure");
            return Path.Combine(baseDir, "candidato.json");
        }

        /// <summary>
        /// Lê os dados do arquivo JSON.
        /// </summary>
        /// <returns>Objeto contento os dados do arquivo JSON.</returns>
        public static Candidato ConsultarCandidato()
        {
            string json = File.ReadAllText(GetCaminhoArquivo());
            return JsonSerializer.Deserialize<Candidato>(json);
        }

        /// <summary>
        /// Salva os dados do candidato no arquivo JSON.
        /// </summary>
        /// <param name="candidato">Candidato cujos dados serão salvos.</param>
        public static void SalvarCandidato(Candidato candidato)
        {
            string json = JsonSerializer.Serialize(candidato);
            File.WriteAllText(GetCaminhoArquivo(), json);
        }
    }
}
