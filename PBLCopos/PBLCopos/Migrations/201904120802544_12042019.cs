namespace PBLCopos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12042019 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Estoques", "SacosdeCopo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Estoques", "SacosdeCopo", c => c.String());
        }
    }
}
