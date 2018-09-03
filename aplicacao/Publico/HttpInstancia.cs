using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace aplicacao
{
    public class HttpInstancia
    {
        private static HttpClient httpClientInstance;

        private HttpInstancia()
        {
        }

        public static HttpClient GetHttpClientInstance()
        {
            if (httpClientInstance == null)
            {
                httpClientInstance = new HttpClient();
                httpClientInstance.DefaultRequestHeaders.ConnectionClose = false;
                httpClientInstance.DefaultRequestHeaders.Add("User-Agent", "Teste-Desenvolvimento");
            }

            return httpClientInstance;
        }
    }
}