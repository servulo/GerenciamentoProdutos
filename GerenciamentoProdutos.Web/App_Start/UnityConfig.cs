using GerenciamentoProdutos.Data.Context;
using GerenciamentoProdutos.Data.Repositories;
using GerenciamentoProdutos.Domain.Interfaces;
using NHibernate;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace GerenciamentoProdutos.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterInstance<ISessionFactory>(NHibernateHelper.SessionFactory);

            container.RegisterFactory<ISession>(c => c.Resolve<ISessionFactory>().OpenSession());

            container.RegisterType<IProdutoRepository, ProdutoRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}