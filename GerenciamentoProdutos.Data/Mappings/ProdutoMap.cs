using FluentNHibernate.Mapping;
using GerenciamentoProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoProdutos.Data.Mappings
{
    public class ProdutoMap : ClassMap<Produto>
    {

        public ProdutoMap() 
        {

            Table("Produtos");

            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Nome)
                .Column("Nome")
                .Length(100)
                .Not.Nullable();

            Map(x => x.Descricao)
                .Column("Descricao")
                .Length(500)
                .Not.Nullable();

            Map(x => x.Preco)
                .Column("Preco")
                .Not.Nullable();

            Map(x => x.QuantidadeEstoque)
                .Column("QuantidadeEstoque")
                .Not.Nullable();
        
        }
    }
}
