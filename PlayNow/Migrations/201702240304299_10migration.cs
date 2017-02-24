namespace PlayNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10migration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ChatRoomModels", name: "RPGSessionModel_RPGSessionId", newName: "RPGSession_RPGSessionId");
            RenameIndex(table: "dbo.ChatRoomModels", name: "IX_RPGSessionModel_RPGSessionId", newName: "IX_RPGSession_RPGSessionId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ChatRoomModels", name: "IX_RPGSession_RPGSessionId", newName: "IX_RPGSessionModel_RPGSessionId");
            RenameColumn(table: "dbo.ChatRoomModels", name: "RPGSession_RPGSessionId", newName: "RPGSessionModel_RPGSessionId");
        }
    }
}
