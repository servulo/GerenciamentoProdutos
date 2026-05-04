using GerenciamentoProdutos.Domain.Entities;
using GerenciamentoProdutos.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace GerenciamentoProdutos.Web.Mappers
{
    public static class ProdutoMapper
    {
        public static ProdutoViewModel ToViewModel(Produto produto)
        {
            return new ProdutoViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                QuantidadeEstoque = produto.QuantidadeEstoque
            };
        }

        public static Produto ToEntity(ProdutoViewModel viewModel)
        {
            return new Produto
            {
                Id = viewModel.Id,
                Nome = viewModel.Nome,
                Descricao = viewModel.Descricao,
                Preco = viewModel.Preco,
                QuantidadeEstoque = viewModel.QuantidadeEstoque
            };
        }

        public static IEnumerable<ProdutoViewModel> ToViewModelList(IEnumerable<Produto> produtos)
        {
            return produtos.Select(ToViewModel);
        }
    }
}