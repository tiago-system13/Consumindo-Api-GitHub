using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace aplicacao
{
    public class ModuloAplicacao : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ModuloAplicacao)))
              .Where(x =>
                          x.Name
                           .StartsWith("Servico"))
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
