using GerenciamentoProdutos.Data.Context;
using GerenciamentoProdutos.Domain.Entities;
using GerenciamentoProdutos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoProdutos.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _context.Produtos;
        }

        public Produto ObterPorId(int id)
        {
            return _context.Produtos.Find(id);
        }

        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Atualizar(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var produto = _context.Produtos.Find(id);
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

    }
}
