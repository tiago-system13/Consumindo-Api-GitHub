using aplicacao.Banco;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace aplicacao.MeusRepositorios
{
    public class ServicoMeuRepositorio : ServicoApiGitHub,IServicoMeuProprietario
    {

        public IEnumerable<FormularioMeuRepositorio> ListarMeusRepositorios(PesquisaMeuRepositorio dadosPesquisa)
        {
            var listaRepositorios = new List<FormularioMeuRepositorio>();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}/users/{dadosPesquisa.usuario ?? UsuarioPadrao}/repos");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");                        
            var repositorio = ApiRespostaRequisicaoRepositorioCandidadto(request);            
            foreach (var repo in repositorio)
            {
                listaRepositorios.Add(new FormularioMeuRepositorio()
                {
                    ID = repo.ID,
                    Name = repo.Name,
                    Description = repo.Description,
                    Language = repo.Language,                 
                    Updated_at = repo.Updated_at,
                    Login = repo.Proprietario.login,
                    Html_url = repo.Html_url
                });
            }
            return listaRepositorios.OrderBy(m => m.Name);
        }
    }
}
