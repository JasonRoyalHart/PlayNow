namespace PlayNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PublicPlaceModels", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PublicPlaceModels", "Name");
        }
    }
}
