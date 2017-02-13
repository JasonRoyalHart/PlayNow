namespace PlayNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameModels", "GameId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameModels", "GameId");
        }
    }
}
