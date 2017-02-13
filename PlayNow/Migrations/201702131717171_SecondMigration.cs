namespace PlayNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImageData = c.Binary(),
                        MinimumPlayers = c.Int(nullable: false),
                        MaximumPlayers = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                        AmazonLink = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GameSessionModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Creator = c.String(),
                        Game = c.String(),
                        GameId = c.Int(nullable: false),
                        Time = c.String(),
                        Day = c.String(),
                        Month = c.String(),
                        Year = c.String(),
                        MinimumPlayers = c.Int(nullable: false),
                        MaximumPlayers = c.Int(nullable: false),
                        MinimumRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        Rating = c.Double(nullable: false),
                        ImageData = c.Binary(),
                        Email = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Zipcode = c.String(),
                        GameSessionModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameSessionModels", t => t.GameSessionModel_Id)
                .Index(t => t.GameSessionModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserModels", "GameSessionModel_Id", "dbo.GameSessionModels");
            DropIndex("dbo.UserModels", new[] { "GameSessionModel_Id" });
            DropTable("dbo.UserModels");
            DropTable("dbo.GameSessionModels");
            DropTable("dbo.GameModels");
        }
    }
}
