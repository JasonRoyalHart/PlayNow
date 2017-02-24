namespace PlayNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameModelUserModels",
                c => new
                    {
                        GameModel_GameId = c.Int(nullable: false),
                        UserModel_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameModel_GameId, t.UserModel_UserId })
                .ForeignKey("dbo.GameModels", t => t.GameModel_GameId, cascadeDelete: true)
                .ForeignKey("dbo.UserModels", t => t.UserModel_UserId, cascadeDelete: true)
                .Index(t => t.GameModel_GameId)
                .Index(t => t.UserModel_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameModelUserModels", "UserModel_UserId", "dbo.UserModels");
            DropForeignKey("dbo.GameModelUserModels", "GameModel_GameId", "dbo.GameModels");
            DropIndex("dbo.GameModelUserModels", new[] { "UserModel_UserId" });
            DropIndex("dbo.GameModelUserModels", new[] { "GameModel_GameId" });
            DropTable("dbo.GameModelUserModels");
        }
    }
}
