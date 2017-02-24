namespace PlayNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserModels", "AverageRating", c => c.Double(nullable: false));
            AddColumn("dbo.UserModels", "MyRating", c => c.Int(nullable: false));
            AddColumn("dbo.UserRatingModels", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.UserRatingModels", "RatingUser_UserId", c => c.Int());
            AddColumn("dbo.UserRatingModels", "User_UserId", c => c.Int());
            CreateIndex("dbo.UserRatingModels", "RatingUser_UserId");
            CreateIndex("dbo.UserRatingModels", "User_UserId");
            AddForeignKey("dbo.UserRatingModels", "RatingUser_UserId", "dbo.UserModels", "UserId");
            AddForeignKey("dbo.UserRatingModels", "User_UserId", "dbo.UserModels", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRatingModels", "User_UserId", "dbo.UserModels");
            DropForeignKey("dbo.UserRatingModels", "RatingUser_UserId", "dbo.UserModels");
            DropIndex("dbo.UserRatingModels", new[] { "User_UserId" });
            DropIndex("dbo.UserRatingModels", new[] { "RatingUser_UserId" });
            DropColumn("dbo.UserRatingModels", "User_UserId");
            DropColumn("dbo.UserRatingModels", "RatingUser_UserId");
            DropColumn("dbo.UserRatingModels", "Rating");
            DropColumn("dbo.UserModels", "MyRating");
            DropColumn("dbo.UserModels", "AverageRating");
        }
    }
}
