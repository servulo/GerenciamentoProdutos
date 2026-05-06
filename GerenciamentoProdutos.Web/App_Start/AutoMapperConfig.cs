using AutoMapper;
using GerenciamentoProdutos.Domain.Entities;
using GerenciamentoProdutos.Web.ViewModels;

namespace GerenciamentoProdutos.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Produto, ProdutoViewModel>();
                cfg.CreateMap<ProdutoViewModel, Produto>();
            });
        }
    }
}