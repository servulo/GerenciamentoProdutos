using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using GerenciamentoProdutos.Data.Mappings;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace GerenciamentoProdutos.Data.Context
{
    public class NHibernateHelper
    {

        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    _sessionFactory = CreateSessionFactory();

                return _sessionFactory;
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString("Server=localhost,1433;Database=GerenciamentoProdutosDb;User Id=sa;Password=Senha@1234;"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProdutoMap>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}