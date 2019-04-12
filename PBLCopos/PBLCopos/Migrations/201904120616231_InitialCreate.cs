namespace PBLCopos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bebedouroes",
                c => new
                    {
                        BebedouroId = c.Int(nullable: false, identity: true),
                        Localizacao = c.String(),
                        StatusCopo = c.Int(nullable: false),
                        EstoqueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BebedouroId)
                .ForeignKey("dbo.Estoques", t => t.EstoqueId, cascadeDelete: true)
                .Index(t => t.EstoqueId);
            
            CreateTable(
                "dbo.Estoques",
                c => new
                    {
                        EstoqueId = c.Int(nullable: false, identity: true),
                        SacosdeCopo = c.String(),
                        Qtd_ML = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EstoqueId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bebedouroes", "EstoqueId", "dbo.Estoques");
            DropIndex("dbo.Bebedouroes", new[] { "EstoqueId" });
            DropTable("dbo.Estoques");
            DropTable("dbo.Bebedouroes");
        }
    }
}
