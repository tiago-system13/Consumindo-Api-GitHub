using aplicacao.MeusRepositorios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacao.Repositorios
{
   public class FormularioDeRepositorios:FormularioMeuRepositorio
    {                    

        public string Contribuidor { get; set; }
        
        public Collection<FormularioDeContribuinte> Contribuintes { get; set; }

        public FormularioDeRepositorios()
        {
            Contribuintes = new Collection<FormularioDeContribuinte>();            
        }

        public Repositorio PreencherRepositorio()
        {
            return new Repositorio()
            {
                ID = ID,
                Language = Language,
                Description = Description,
                Html_url = Html_url,
                Updated_at = Updated_at,
                Name = Name,
                Proprietario = new Proprietario() { login = Login }
            };
        }
    }
}
