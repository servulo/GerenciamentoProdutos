using GerenciamentoProdutos.Data.Context;
using GerenciamentoProdutos.Data.Repositories;
using GerenciamentoProdutos.Domain.Interfaces;
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

            container.RegisterType<IProdutoRepository, ProdutoRepository>();
            container.RegisterType<AppDbContext>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}