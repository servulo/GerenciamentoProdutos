using Autofac;
using Autofac.Integration.Mvc;
using GerenciamentoProdutos.Data.Context;
using GerenciamentoProdutos.Data.Repositories;
using GerenciamentoProdutos.Domain.Interfaces;
using NHibernate;
using System.Reflection;
using System.Web.Mvc;

namespace GerenciamentoProdutos.Web.App_Start
{
    public static class AutofacConfig
    {
        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterInstance(NHibernateHelper.SessionFactory)
                   .As<ISessionFactory>()
                   .SingleInstance();

            builder.Register(c => c.Resolve<ISessionFactory>().OpenSession())
                   .As<ISession>()
                   .InstancePerRequest();

            builder.RegisterType<ProdutoRepository>()
                   .As<IProdutoRepository>()
                   .InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}