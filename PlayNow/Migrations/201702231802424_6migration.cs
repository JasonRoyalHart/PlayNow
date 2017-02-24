namespace PlayNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserModels", "Game_Id", c => c.Int());
            CreateIndex("dbo.UserModels", "Game_Id");
            AddForeignKey("dbo.UserModels", "Game_Id", "dbo.Games", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserModels", "Game_Id", "dbo.Games");
            DropIndex("dbo.UserModels", new[] { "Game_Id" });
            DropColumn("dbo.UserModels", "Game_Id");
        }
    }
}
