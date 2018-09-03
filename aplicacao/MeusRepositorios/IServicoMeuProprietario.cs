using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacao.MeusRepositorios
{
    public interface IServicoMeuProprietario
    {
        IEnumerable<FormularioMeuRepositorio> ListarMeusRepositorios(PesquisaMeuRepositorio dadosPesquisa);
    }
}
