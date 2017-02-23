namespace PlayNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChatRoomMessageModels", "GameSession", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChatRoomMessageModels", "GameSession");
        }
    }
}
