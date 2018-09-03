using aplicacao.Banco;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Script.Serialization;

namespace aplicacao
{
    public class ServicoApiGitHub : MinhaApi
    {
        public string BaseUrl => "https://api.github.com";
        public string UsuarioPadrao => "tiago-system13";

        public IEnumerable<Repositorio> ApiRespostaRequisicao(HttpRequestMessage request)
        {            
            var jsonString = HttpInstancia.GetHttpClientInstance().SendAsync(request).Result.Content.ReadAsStringAsync().Result;            
            return new JArray(JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString)["items"])
                .Select(item => new Repositorio()
                {
                    ID = item["id"]?.ToString(),
                    Name = item["name"]?.ToString(),
                    Description = item["description"]?.ToString(),
                    Updated_at = DateTime.Parse(item["updated_at"]?.ToString()),
                    Proprietario = ObterUsuario(item["owner"]["login"]?.ToString()),
                    Language = item["language"]?.ToString(),
                    Html_url = item["html_url"]?.ToString(),
                    Contribuidor = item["contributors_url"]?.ToString()
                }
                );
        }

        public IEnumerable<Contribuidor> ApiRespostaRequisicaoContribuidores(HttpRequestMessage request)
        {           
            var jsonString = HttpInstancia.GetHttpClientInstance().SendAsync(request).Result.Content.ReadAsStringAsync().Result;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<Contribuidor> elementos = jss.Deserialize<List<Contribuidor>>(jsonString);
            return elementos;
        }

        public IEnumerable<Repositorio> ApiRespostaRequisicaoRepositorioCandidadto(HttpRequestMessage request)
        {           
            var jsonString = HttpInstancia.GetHttpClientInstance().SendAsync(request).Result.Content.ReadAsStringAsync().Result;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<Repositorio> elementos = jss.Deserialize<List<Repositorio>>(jsonString);
            return elementos;
        }

        public Proprietario ObterUsuario(string usuario = "tiago-system13")
        {
            var usuarioRequest = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}/users/{usuario ?? UsuarioPadrao}");
            usuarioRequest.Headers.Add("Accept", "application/vnd.github.v3+json");
            var auth = new DbFavorito().GetAuth().First();
            if (auth.Key != string.Empty) usuarioRequest.Headers.Add(auth.Key, auth.Value);
            var jsonString = HttpInstancia.GetHttpClientInstance().SendAsync(usuarioRequest).Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Proprietario>(jsonString);
        }
    }
}