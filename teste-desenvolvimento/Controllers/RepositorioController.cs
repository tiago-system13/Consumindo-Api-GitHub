using aplicacao.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace teste_desenvolvimento.Controllers
{
    public class RepositorioController : Controller
    {
        private readonly IServicoRepositorio _servRepositorio;

        public RepositorioController(IServicoRepositorio servRepositorio)
        {
            _servRepositorio = servRepositorio;
        }

        // GET: Repositorio
        public ActionResult IndexRepositorio()
        {
            return View();
        }
        public ActionResult IndexRepositorioFavorito()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PesquisarRepositorios(string nome)
        {
            return Json(_servRepositorio.ListarRepositorio(nome).ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult PesquisarRepositoriosFavoritos()
        {
            return Json(_servRepositorio.ListarRepositorioFavoritos().ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ContribuidoresDoRepositorio(string query)
        {
            return Json(_servRepositorio.ListarContribuintes(query).ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]       
        public ActionResult Cadastrar(FormularioDeRepositorios formularioRepositorio)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _servRepositorio.SalvarFavorito(formularioRepositorio);
                    return Json(new { Sucesso = true, mensagem = "Repositório marcado com sucesso!" }, JsonRequestBehavior.AllowGet);
                }
                catch (ArgumentException ex)
                {
                    return Json(new { Sucesso = false, mensagem = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            
            return  View("IndexRepositorio");
        }
        public ActionResult ExcluirFavorito(string id)
        {           
            try
            {
                var existeItem = _servRepositorio.ExcluirItemFavorito(id);                
                return Json(new { Sucesso = true, mensagem = "Repositório favorito desmarcado com sucesso!" }, JsonRequestBehavior.AllowGet);
            }
            catch (ArgumentException ex)
            {
                return Json(new { Sucesso = false, mensagem = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}