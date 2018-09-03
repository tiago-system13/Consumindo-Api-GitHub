using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacao.Repositorios
{
    public interface IServicoRepositorio
    {

        IEnumerable<FormularioDeRepositorios> ListarRepositorio(string nome);
        IEnumerable<FormularioDeRepositorios> ListarRepositorioFavoritos();
        Collection<FormularioDeContribuinte> ListarContribuintes(string query);
        void SalvarFavorito(FormularioDeRepositorios formulario);
        bool ExcluirItemFavorito(string id);
    }
}
