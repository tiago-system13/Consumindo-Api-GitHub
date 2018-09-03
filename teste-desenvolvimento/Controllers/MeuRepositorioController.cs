using aplicacao.MeusRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace teste_desenvolvimento.Controllers
{
    public class MeuRepositorioController : Controller
    {
        private readonly IServicoMeuProprietario _servMeuRepositorio;

        public MeuRepositorioController(IServicoMeuProprietario servMeuRepositorio)
        {
            _servMeuRepositorio = servMeuRepositorio;
        }

        // GET: MeuRepositorio
        public ActionResult IndexMeuRepositorio()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PesquisarMeusRepositorios(PesquisaMeuRepositorio dados)
        {            
            return Json(_servMeuRepositorio.ListarMeusRepositorios(dados).ToList(),JsonRequestBehavior.AllowGet);
          
        }
    }
}