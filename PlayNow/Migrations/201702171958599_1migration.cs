namespace PlayNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameModels",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImageData = c.Binary(),
                        MinimumPlayers = c.Int(nullable: false),
                        MaximumPlayers = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                        AmazonLink = c.String(),
                    })
                .PrimaryKey(t => t.GameId);
            
            CreateTable(
                "dbo.GameRatingModels",
                c => new
                    {
                        GameRatingId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.GameRatingId);
            
            CreateTable(
                "dbo.GameSessionModels",
                c => new
                    {
                        GameSessionId = c.Int(nullable: false, identity: true),
                        Creator = c.String(),
                        Name = c.String(),
                        Time = c.String(),
                        Day = c.String(),
                        Month = c.String(),
                        Year = c.String(),
                        MinimumPlayers = c.Int(nullable: false),
                        MaximumPlayers = c.Int(nullable: false),
                        MinimumRating = c.Double(nullable: false),
                        GameId = c.Int(nullable: false),
                        GameName = c.String(),
                        UserId = c.Int(nullable: false),
                        ApprovalNeeded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GameSessionId)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GameId = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        MinimumPlayers = c.Int(nullable: false),
                        MaximumPlayers = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                        AmazonLink = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        Rating = c.Double(nullable: false),
                        ImageData = c.Binary(),
                        Email = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                        Login = c.String(),
                        GameSessionId = c.Int(nullable: false),
                        RPGSessionModel_RPGSessionId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.RPGSessionModels", t => t.RPGSessionModel_RPGSessionId)
                .Index(t => t.RPGSessionModel_RPGSessionId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.RPGModels",
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
                "dbo.RPGSessionModels",
                c => new
                    {
                        RPGSessionId = c.Int(nullable: false, identity: true),
                        Creator = c.String(),
                        Name = c.String(),
                        Time = c.String(),
                        Day = c.String(),
                        Month = c.String(),
                        Year = c.String(),
                        MinimumPlayers = c.Int(nullable: false),
                        MaximumPlayers = c.Int(nullable: false),
                        MinimumRating = c.Double(nullable: false),
                        GameId = c.Int(nullable: false),
                        GameName = c.String(),
                    })
                .PrimaryKey(t => t.RPGSessionId)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.UserRatingModels",
                c => new
                    {
                        UserRatingId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.UserRatingId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.GameSessionModelUserModels",
                c => new
                    {
                        GameSessionModel_GameSessionId = c.Int(nullable: false),
                        UserModel_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameSessionModel_GameSessionId, t.UserModel_UserId })
                .ForeignKey("dbo.GameSessionModels", t => t.GameSessionModel_GameSessionId, cascadeDelete: true)
                .ForeignKey("dbo.UserModels", t => t.UserModel_UserId, cascadeDelete: true)
                .Index(t => t.GameSessionModel_GameSessionId)
                .Index(t => t.UserModel_UserId);
            
            CreateTable(
                "dbo.GameSessionModelUserModel1",
                c => new
                    {
                        GameSessionModel_GameSessionId = c.Int(nullable: false),
                        UserModel_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameSessionModel_GameSessionId, t.UserModel_UserId })
                .ForeignKey("dbo.GameSessionModels", t => t.GameSessionModel_GameSessionId, cascadeDelete: true)
                .ForeignKey("dbo.UserModels", t => t.UserModel_UserId, cascadeDelete: true)
                .Index(t => t.GameSessionModel_GameSessionId)
                .Index(t => t.UserModel_UserId);
            
            CreateTable(
                "dbo.GameSessionModelUserModel2",
                c => new
                    {
                        GameSessionModel_GameSessionId = c.Int(nullable: false),
                        UserModel_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameSessionModel_GameSessionId, t.UserModel_UserId })
                .ForeignKey("dbo.GameSessionModels", t => t.GameSessionModel_GameSessionId, cascadeDelete: true)
                .ForeignKey("dbo.UserModels", t => t.UserModel_UserId, cascadeDelete: true)
                .Index(t => t.GameSessionModel_GameSessionId)
                .Index(t => t.UserModel_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserModels", "RPGSessionModel_RPGSessionId", "dbo.RPGSessionModels");
            DropForeignKey("dbo.RPGSessionModels", "GameId", "dbo.Games");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.GameSessionModelUserModel2", "UserModel_UserId", "dbo.UserModels");
            DropForeignKey("dbo.GameSessionModelUserModel2", "GameSessionModel_GameSessionId", "dbo.GameSessionModels");
            DropForeignKey("dbo.GameSessionModelUserModel1", "UserModel_UserId", "dbo.UserModels");
            DropForeignKey("dbo.GameSessionModelUserModel1", "GameSessionModel_GameSessionId", "dbo.GameSessionModels");
            DropForeignKey("dbo.GameSessionModelUserModels", "UserModel_UserId", "dbo.UserModels");
            DropForeignKey("dbo.GameSessionModelUserModels", "GameSessionModel_GameSessionId", "dbo.GameSessionModels");
            DropForeignKey("dbo.GameSessionModels", "GameId", "dbo.Games");
            DropIndex("dbo.GameSessionModelUserModel2", new[] { "UserModel_UserId" });
            DropIndex("dbo.GameSessionModelUserModel2", new[] { "GameSessionModel_GameSessionId" });
            DropIndex("dbo.GameSessionModelUserModel1", new[] { "UserModel_UserId" });
            DropIndex("dbo.GameSessionModelUserModel1", new[] { "GameSessionModel_GameSessionId" });
            DropIndex("dbo.GameSessionModelUserModels", new[] { "UserModel_UserId" });
            DropIndex("dbo.GameSessionModelUserModels", new[] { "GameSessionModel_GameSessionId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.RPGSessionModels", new[] { "GameId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UserModels", new[] { "RPGSessionModel_RPGSessionId" });
            DropIndex("dbo.GameSessionModels", new[] { "GameId" });
            DropTable("dbo.GameSessionModelUserModel2");
            DropTable("dbo.GameSessionModelUserModel1");
            DropTable("dbo.GameSessionModelUserModels");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserRatingModels");
            DropTable("dbo.RPGSessionModels");
            DropTable("dbo.RPGModels");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UserModels");
            DropTable("dbo.Games");
            DropTable("dbo.GameSessionModels");
            DropTable("dbo.GameRatingModels");
            DropTable("dbo.GameModels");
        }
    }
}
