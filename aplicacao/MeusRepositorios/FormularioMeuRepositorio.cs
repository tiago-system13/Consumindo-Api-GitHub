using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacao.MeusRepositorios
{
   public class FormularioMeuRepositorio
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Description { get; set; }
        public DateTime? Updated_at { get; set; }       
        public string Language { get; set; }
        public string Html_url { get; set; }
    }
}
