using GerenciamentoProdutos.Domain.Entities;
using GerenciamentoProdutos.Domain.Interfaces;
using GerenciamentoProdutos.Domain.Services;
using System;
using System.Collections.Generic;

namespace GerenciamentoProdutos.Domain.Implementations
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public Produto ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public void Criar(Produto produto)
        {
            if (string.IsNullOrWhiteSpace(produto.Nome))
                throw new ArgumentException("O nome do produto é obrigatório.");

            var produtos = _repository.ObterTodos();
            foreach (var p in produtos)
            {
                if (p.Nome.Equals(produto.Nome, StringComparison.OrdinalIgnoreCase))
                    throw new ArgumentException($"Já existe um produto com o nome '{produto.Nome}'.");
            }

            _repository.Adicionar(produto);
        }

        public void Atualizar(Produto produto)
        {
            if (string.IsNullOrWhiteSpace(produto.Nome))
                throw new ArgumentException("O nome do produto é obrigatório.");

            _repository.Atualizar(produto);
        }

        public void Remover(int id)
        {
            var produto = _repository.ObterPorId(id);
            if (produto == null)
                throw new ArgumentException($"Produto com ID {id} não encontrado.");

            _repository.Remover(id);
        }
    }
}