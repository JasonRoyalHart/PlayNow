namespace PlayNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PublicPlaceModels",
                c => new
                    {
                        PublicPlaceID = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                        Phone = c.String(),
                        AverageRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PublicPlaceID);
            
            CreateTable(
                "dbo.PublicPlaceRatingModels",
                c => new
                    {
                        PublicPlaceRatingID = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        PublicPlace_PublicPlaceID = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PublicPlaceRatingID)
                .ForeignKey("dbo.PublicPlaceModels", t => t.PublicPlace_PublicPlaceID)
                .ForeignKey("dbo.UserModels", t => t.User_UserId)
                .Index(t => t.PublicPlace_PublicPlaceID)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.GameModelPublicPlaceModels",
                c => new
                    {
                        GameModel_GameId = c.Int(nullable: false),
                        PublicPlaceModel_PublicPlaceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameModel_GameId, t.PublicPlaceModel_PublicPlaceID })
                .ForeignKey("dbo.GameModels", t => t.GameModel_GameId, cascadeDelete: true)
                .ForeignKey("dbo.PublicPlaceModels", t => t.PublicPlaceModel_PublicPlaceID, cascadeDelete: true)
                .Index(t => t.GameModel_GameId)
                .Index(t => t.PublicPlaceModel_PublicPlaceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameModelPublicPlaceModels", "PublicPlaceModel_PublicPlaceID", "dbo.PublicPlaceModels");
            DropForeignKey("dbo.GameModelPublicPlaceModels", "GameModel_GameId", "dbo.GameModels");
            DropForeignKey("dbo.PublicPlaceRatingModels", "User_UserId", "dbo.UserModels");
            DropForeignKey("dbo.PublicPlaceRatingModels", "PublicPlace_PublicPlaceID", "dbo.PublicPlaceModels");
            DropIndex("dbo.GameModelPublicPlaceModels", new[] { "PublicPlaceModel_PublicPlaceID" });
            DropIndex("dbo.GameModelPublicPlaceModels", new[] { "GameModel_GameId" });
            DropIndex("dbo.PublicPlaceRatingModels", new[] { "User_UserId" });
            DropIndex("dbo.PublicPlaceRatingModels", new[] { "PublicPlace_PublicPlaceID" });
            DropTable("dbo.GameModelPublicPlaceModels");
            DropTable("dbo.PublicPlaceRatingModels");
            DropTable("dbo.PublicPlaceModels");
        }
    }
}
