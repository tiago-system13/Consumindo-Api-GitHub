using aplicacao.Banco;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aplicacao.Repositorios
{
    public class ServicoDeRepositorio : ServicoApiGitHub,IServicoRepositorio
    {
        public IEnumerable<FormularioDeRepositorios> ListarRepositorio(string nome)
        {
            var listaRepositorios = new List<FormularioDeRepositorios>();
            if (string.IsNullOrWhiteSpace(nome)) return ListarTodosRepositorios();
            nome = Regex.Replace(nome, "[^0-9a-zA-Z]+", "");
            var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}/search/repositories?q=name:{nome.Trim()}+page=1&per_page=30&size:<=800&stars:500&is:public&status:success");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");            
            var repositorio = ApiRespostaRequisicao(request);
            foreach (var repo in repositorio)
            {
                listaRepositorios.Add(new FormularioDeRepositorios()
                {
                    ID = repo.ID,
                    Name = repo.Name,
                    Description = repo.Description,
                    Language = repo.Language,
                    Updated_at = repo.Updated_at,
                    Html_url = repo.Html_url,
                    Login = repo.Proprietario.login,
                    Contribuidor = repo.Contribuidor,
                });
            }
            return listaRepositorios;
        }

        public IEnumerable<FormularioDeRepositorios> ListarTodosRepositorios()
        {
            var listaRepositorios = new List<FormularioDeRepositorios>();          
            var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}/search/repositories?q=page=1&per_page=50&size:<=1000&stars:500&is:public&status:success");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");            
            var repositorio = ApiRespostaRequisicao(request);
            foreach (var repo in repositorio)
            {
                listaRepositorios.Add(new FormularioDeRepositorios()
                {
                    ID = repo.ID,
                    Name = repo.Name,
                    Description = repo.Description,
                    Language = repo.Language,
                    Updated_at = repo.Updated_at,
                    Html_url = repo.Html_url,
                    Login = repo.Proprietario.login,
                    Contribuidor = repo.Contribuidor
                });
            }
            return listaRepositorios;
        }

        public Collection<FormularioDeContribuinte> ListarContribuintes(string query)
        {
            var listaDeContribuidores = new Collection<FormularioDeContribuinte>();
            if (string.IsNullOrWhiteSpace(query)) return listaDeContribuidores;
            var request = new HttpRequestMessage(HttpMethod.Get, query);
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            var contribuidores = ApiRespostaRequisicaoContribuidores(request);
            foreach (var item in contribuidores)
            {
                listaDeContribuidores.Add(new FormularioDeContribuinte() {                 
                    Name = item.Login,
                    Contributions = item.Contributions,
                    html_url = item.html_url  
                });
            }
            return listaDeContribuidores;
        }

        public void SalvarFavorito(FormularioDeRepositorios formulario)
        {
            new DbFavorito().MarcarFavoritoBase(formulario.PreencherRepositorio(), false);
        }

        public IEnumerable<FormularioDeRepositorios> ListarRepositorioFavoritos()
        {
            var Lista = new List<FormularioDeRepositorios>(); 
            foreach (var item in new DbFavorito().Favoritos())
            {
                Lista.Add(
                new FormularioDeRepositorios()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Description = item.Description,
                    Language = item.Language,
                    Updated_at = item.Updated_at,
                    Html_url = item.Html_url,
                    Login = item.Proprietario.login,
                    Contribuidor = item.Contribuidor
                }
                );
            }
           return Lista;
        }

        public bool ExcluirItemFavorito(string id)
        {
            new DbFavorito().MarcarFavoritoBase(new Repositorio() { ID = id}, true);
            return true;
            
        }
    }
}
