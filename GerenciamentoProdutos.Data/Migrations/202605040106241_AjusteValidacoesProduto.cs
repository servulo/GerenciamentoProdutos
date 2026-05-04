namespace GerenciamentoProdutos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjusteValidacoesProduto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produtoes", "Nome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Produtoes", "Descricao", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtoes", "Descricao", c => c.String());
            AlterColumn("dbo.Produtoes", "Nome", c => c.String());
        }
    }
}
