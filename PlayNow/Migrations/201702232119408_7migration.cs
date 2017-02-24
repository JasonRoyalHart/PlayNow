namespace PlayNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RPGSessionModels", "GameId", "dbo.Games");
            DropForeignKey("dbo.UserModels", "RPGSessionModel_RPGSessionId", "dbo.RPGSessionModels");
            DropIndex("dbo.UserModels", new[] { "RPGSessionModel_RPGSessionId" });
            DropIndex("dbo.RPGSessionModels", new[] { "GameId" });
            CreateTable(
                "dbo.RPGs",
                c => new
                    {
                        RPGId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImageData = c.Binary(),
                        Rating = c.Double(nullable: false),
                        AmazonLink = c.String(),
                    })
                .PrimaryKey(t => t.RPGId);
            
            CreateTable(
                "dbo.RPGSessionModelUserModels",
                c => new
                    {
                        RPGSessionModel_RPGSessionId = c.Int(nullable: false),
                        UserModel_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RPGSessionModel_RPGSessionId, t.UserModel_UserId })
                .ForeignKey("dbo.RPGSessionModels", t => t.RPGSessionModel_RPGSessionId, cascadeDelete: true)
                .ForeignKey("dbo.UserModels", t => t.UserModel_UserId, cascadeDelete: true)
                .Index(t => t.RPGSessionModel_RPGSessionId)
                .Index(t => t.UserModel_UserId);
            
            CreateTable(
                "dbo.RPGSessionModelUserModel1",
                c => new
                    {
                        RPGSessionModel_RPGSessionId = c.Int(nullable: false),
                        UserModel_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RPGSessionModel_RPGSessionId, t.UserModel_UserId })
                .ForeignKey("dbo.RPGSessionModels", t => t.RPGSessionModel_RPGSessionId, cascadeDelete: true)
                .ForeignKey("dbo.UserModels", t => t.UserModel_UserId, cascadeDelete: true)
                .Index(t => t.RPGSessionModel_RPGSessionId)
                .Index(t => t.UserModel_UserId);
            
            CreateTable(
                "dbo.RPGSessionModelUserModel2",
                c => new
                    {
                        RPGSessionModel_RPGSessionId = c.Int(nullable: false),
                        UserModel_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RPGSessionModel_RPGSessionId, t.UserModel_UserId })
                .ForeignKey("dbo.RPGSessionModels", t => t.RPGSessionModel_RPGSessionId, cascadeDelete: true)
                .ForeignKey("dbo.UserModels", t => t.UserModel_UserId, cascadeDelete: true)
                .Index(t => t.RPGSessionModel_RPGSessionId)
                .Index(t => t.UserModel_UserId);
            
            CreateTable(
                "dbo.RPGModelUserModels",
                c => new
                    {
                        RPGModel_RPGId = c.Int(nullable: false),
                        UserModel_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RPGModel_RPGId, t.UserModel_UserId })
                .ForeignKey("dbo.RPGModels", t => t.RPGModel_RPGId, cascadeDelete: true)
                .ForeignKey("dbo.UserModels", t => t.UserModel_UserId, cascadeDelete: true)
                .Index(t => t.RPGModel_RPGId)
                .Index(t => t.UserModel_UserId);
            
            AddColumn("dbo.ChatRoomModels", "RPGSessionModel_RPGSessionId", c => c.Int());
            AddColumn("dbo.RPGSessionModels", "Repeats", c => c.String());
            AddColumn("dbo.RPGSessionModels", "GM", c => c.Int(nullable: false));
            AddColumn("dbo.RPGSessionModels", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.RPGSessionModels", "ApprovalNeeded", c => c.Boolean(nullable: false));
            AddColumn("dbo.RPGSessionModels", "RPG_RPGId", c => c.Int());
            CreateIndex("dbo.ChatRoomModels", "RPGSessionModel_RPGSessionId");
            CreateIndex("dbo.RPGSessionModels", "RPG_RPGId");
            AddForeignKey("dbo.ChatRoomModels", "RPGSessionModel_RPGSessionId", "dbo.RPGSessionModels", "RPGSessionId");
            AddForeignKey("dbo.RPGSessionModels", "RPG_RPGId", "dbo.RPGs", "RPGId");
            DropColumn("dbo.UserModels", "RPGSessionModel_RPGSessionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserModels", "RPGSessionModel_RPGSessionId", c => c.Int());
            DropForeignKey("dbo.RPGModelUserModels", "UserModel_UserId", "dbo.UserModels");
            DropForeignKey("dbo.RPGModelUserModels", "RPGModel_RPGId", "dbo.RPGModels");
            DropForeignKey("dbo.RPGSessionModelUserModel2", "UserModel_UserId", "dbo.UserModels");
            DropForeignKey("dbo.RPGSessionModelUserModel2", "RPGSessionModel_RPGSessionId", "dbo.RPGSessionModels");
            DropForeignKey("dbo.RPGSessionModelUserModel1", "UserModel_UserId", "dbo.UserModels");
            DropForeignKey("dbo.RPGSessionModelUserModel1", "RPGSessionModel_RPGSessionId", "dbo.RPGSessionModels");
            DropForeignKey("dbo.RPGSessionModels", "RPG_RPGId", "dbo.RPGs");
            DropForeignKey("dbo.RPGSessionModelUserModels", "UserModel_UserId", "dbo.UserModels");
            DropForeignKey("dbo.RPGSessionModelUserModels", "RPGSessionModel_RPGSessionId", "dbo.RPGSessionModels");
            DropForeignKey("dbo.ChatRoomModels", "RPGSessionModel_RPGSessionId", "dbo.RPGSessionModels");
            DropIndex("dbo.RPGModelUserModels", new[] { "UserModel_UserId" });
            DropIndex("dbo.RPGModelUserModels", new[] { "RPGModel_RPGId" });
            DropIndex("dbo.RPGSessionModelUserModel2", new[] { "UserModel_UserId" });
            DropIndex("dbo.RPGSessionModelUserModel2", new[] { "RPGSessionModel_RPGSessionId" });
            DropIndex("dbo.RPGSessionModelUserModel1", new[] { "UserModel_UserId" });
            DropIndex("dbo.RPGSessionModelUserModel1", new[] { "RPGSessionModel_RPGSessionId" });
            DropIndex("dbo.RPGSessionModelUserModels", new[] { "UserModel_UserId" });
            DropIndex("dbo.RPGSessionModelUserModels", new[] { "RPGSessionModel_RPGSessionId" });
            DropIndex("dbo.RPGSessionModels", new[] { "RPG_RPGId" });
            DropIndex("dbo.ChatRoomModels", new[] { "RPGSessionModel_RPGSessionId" });
            DropColumn("dbo.RPGSessionModels", "RPG_RPGId");
            DropColumn("dbo.RPGSessionModels", "ApprovalNeeded");
            DropColumn("dbo.RPGSessionModels", "UserId");
            DropColumn("dbo.RPGSessionModels", "GM");
            DropColumn("dbo.RPGSessionModels", "Repeats");
            DropColumn("dbo.ChatRoomModels", "RPGSessionModel_RPGSessionId");
            DropTable("dbo.RPGModelUserModels");
            DropTable("dbo.RPGSessionModelUserModel2");
            DropTable("dbo.RPGSessionModelUserModel1");
            DropTable("dbo.RPGSessionModelUserModels");
            DropTable("dbo.RPGs");
            CreateIndex("dbo.RPGSessionModels", "GameId");
            CreateIndex("dbo.UserModels", "RPGSessionModel_RPGSessionId");
            AddForeignKey("dbo.UserModels", "RPGSessionModel_RPGSessionId", "dbo.RPGSessionModels", "RPGSessionId");
            AddForeignKey("dbo.RPGSessionModels", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }
    }
}
