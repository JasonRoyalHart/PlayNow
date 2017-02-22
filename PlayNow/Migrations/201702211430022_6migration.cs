namespace PlayNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PublicPlaceModels", "MyRating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PublicPlaceModels", "MyRating");
        }
    }
}
