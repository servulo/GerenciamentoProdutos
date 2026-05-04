using GerenciamentoProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoProdutos.Data.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Produto> Produtos { get; set; }

    }
}
