using GerenciamentoProdutos.Data.Context;
using GerenciamentoProdutos.Domain.Entities;
using GerenciamentoProdutos.Domain.Interfaces;
using NHibernate;
using System.Collections.Generic;

namespace GerenciamentoProdutos.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly ISession _session;

        public ProdutoRepository(ISession session)
        {
            _session = session;
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _session.Query<Produto>();
        }

        public Produto ObterPorId(int id)
        {
            return _session.Get<Produto>(id);
        }

        public void Adicionar(Produto produto)
        {
            using (var transaction = _session.BeginTransaction()) 
            {
                _session.Save(produto);
                transaction.Commit();
            }
        }

        public void Atualizar(Produto produto)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Update(produto);
                transaction.Commit();
            }

        }

        public void Remover(int id)
        {
            using (var transaction = _session.BeginTransaction()) 
            { 
                var produto = _session.Get<Produto>(id);
                _session.Delete(produto);
                transaction.Commit();
            }
        }

    }
}
