using aplicacao.MeusRepositorios;
using aplicacao.Repositorios;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacao.Testa
{
    public class AplicaoTestes
    {
        [TestFixture]
        public class MeusRepositoriosTests
        {
            [Test]
            public void ListarMeusRepositorios()
            {
                var sut = new ServicoMeuRepositorio();
                var resultado = sut.ListarMeusRepositorios(new PesquisaMeuRepositorio() { usuario= "tiago-system13" });
                Assert.That(resultado, !Is.Empty);
            }
        }

        [TestFixture]
        public class RepositoriosTests
        {
            [Test]
            public void ListarRepositoriosTests()
            {
                var sut = new ServicoDeRepositorio();
                var resultado = sut.ListarRepositorio("Java");
                Assert.That(resultado, !Is.Empty );
            }
            [Test]
            public void ListarTodosRepositoriosTests()
            {
                var sut = new ServicoDeRepositorio();
                var resultado = sut.ListarTodosRepositorios();
                Assert.That(resultado, !Is.Empty);
            }
            [Test]
            public void SalvarFavorito()
            {
                var sut = new ServicoDeRepositorio();
                var formulario = new FormularioDeRepositorios() { ID = "52880443", Name = "angular-base64-upload", Description = "Converts files from file input into base64 encoded models", Html_url = "https://github.com/tiago-system13/angular-base64-upload", Language = "JavaScript", Updated_at = Convert.ToDateTime("01/03/2016 10:54:26"), Login = null };
                sut.SalvarFavorito(formulario);
              //  Assert.That(sut.lista, !Is.Empty);
            }
        }
    }
}
