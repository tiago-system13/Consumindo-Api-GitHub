using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace aplicacao.Banco
{
    public class DbFavorito
    {
        private readonly FileStream _arquivoLog;
        private readonly string DbFileName = "github_favoritos.txt";
        private readonly string AuthFileName = "github_authorizacao.txt";
        private readonly string ErrorLogFileName = "LogError.txt";      
        private string LocalArquivoSalvo = "";

        public String CriarDiretorioSeNaoExistir(string path)
        {
            var returnPath = HttpContext.Current.Server.MapPath(path);

            if (!Directory.Exists(returnPath))
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));

            return returnPath;
        }

        public Dictionary<string, string> GetAuth()
        {
            return !File.Exists(LocalArquivoSalvo + AuthFileName)
                ? new Dictionary<string, string> { { "", "" } }
                : JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(LocalArquivoSalvo + AuthFileName));
        }

        public DbFavorito()
        {
            LocalArquivoSalvo = CriarDiretorioSeNaoExistir("~/Arquivos/");           
            if (!File.Exists(LocalArquivoSalvo + DbFileName))
                _arquivoLog = new FileStream(LocalArquivoSalvo + DbFileName, FileMode.CreateNew);

            if (!File.Exists(LocalArquivoSalvo + ErrorLogFileName))
                _arquivoLog = new FileStream(LocalArquivoSalvo + ErrorLogFileName, FileMode.CreateNew);
        }

        public List<Repositorio> MarcarFavoritoBase(Repositorio repo, bool isRemoval)
        {
            var repos = Favoritos();
            if (repo == null) return repos;

            if (isRemoval)
            {
                repos.Remove(repos.Find(r => r.ID == repo.ID));
            }
            else if(!repos.Any(r => r.ID == repo.ID))                
            {
                repos.Add(repo);
            }else if (repos.Any(r => r.ID == repo.ID))
            {
                throw new ArgumentException("Esse repositório já foi marcado como favorito!");
            }
        
            Limpar();
            File.WriteAllText(LocalArquivoSalvo + DbFileName, JsonConvert.SerializeObject(repos));
            return repos;
        }

        public List<Repositorio> Favoritos() => JsonConvert.DeserializeObject<List<Repositorio>>(File.ReadAllText(LocalArquivoSalvo + DbFileName)) ?? new List<Repositorio>();

        public void Limpar() => File.WriteAllText(LocalArquivoSalvo + DbFileName, string.Empty);

       
    }
}