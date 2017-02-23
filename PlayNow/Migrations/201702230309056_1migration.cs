namespace PlayNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChatRoomModels", "GameSession_GameSessionId", c => c.Int());
            CreateIndex("dbo.ChatRoomModels", "GameSession_GameSessionId");
            AddForeignKey("dbo.ChatRoomModels", "GameSession_GameSessionId", "dbo.GameSessionModels", "GameSessionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChatRoomModels", "GameSession_GameSessionId", "dbo.GameSessionModels");
            DropIndex("dbo.ChatRoomModels", new[] { "GameSession_GameSessionId" });
            DropColumn("dbo.ChatRoomModels", "GameSession_GameSessionId");
        }
    }
}
