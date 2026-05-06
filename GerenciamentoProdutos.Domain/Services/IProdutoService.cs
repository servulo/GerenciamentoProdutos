using GerenciamentoProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoProdutos.Domain.Services
{
    public interface IProdutoService
    {
        IEnumerable<Produto> ObterTodos();
        Produto ObterPorId(int id);
        void Criar(Produto produto);

        void Atualizar(Produto produto);

        void Remover(int id);
    }
}
