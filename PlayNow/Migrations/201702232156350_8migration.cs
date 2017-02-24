namespace PlayNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RPGSessionModels", "RPG_RPGId", "dbo.RPGs");
            DropIndex("dbo.RPGSessionModels", new[] { "RPG_RPGId" });
            RenameColumn(table: "dbo.RPGSessionModels", name: "RPG_RPGId", newName: "RPGId");
            AddColumn("dbo.RPGSessionModels", "RPGName", c => c.String());
            AlterColumn("dbo.RPGSessionModels", "RPGId", c => c.Int(nullable: false));
            CreateIndex("dbo.RPGSessionModels", "RPGId");
            AddForeignKey("dbo.RPGSessionModels", "RPGId", "dbo.RPGs", "RPGId", cascadeDelete: true);
            DropColumn("dbo.RPGSessionModels", "GameId");
            DropColumn("dbo.RPGSessionModels", "GameName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RPGSessionModels", "GameName", c => c.String());
            AddColumn("dbo.RPGSessionModels", "GameId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RPGSessionModels", "RPGId", "dbo.RPGs");
            DropIndex("dbo.RPGSessionModels", new[] { "RPGId" });
            AlterColumn("dbo.RPGSessionModels", "RPGId", c => c.Int());
            DropColumn("dbo.RPGSessionModels", "RPGName");
            RenameColumn(table: "dbo.RPGSessionModels", name: "RPGId", newName: "RPG_RPGId");
            CreateIndex("dbo.RPGSessionModels", "RPG_RPGId");
            AddForeignKey("dbo.RPGSessionModels", "RPG_RPGId", "dbo.RPGs", "RPGId");
        }
    }
}
