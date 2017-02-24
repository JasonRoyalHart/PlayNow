namespace PlayNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRatingModels", "UserModel_UserId", c => c.Int());
            CreateIndex("dbo.UserRatingModels", "UserModel_UserId");
            AddForeignKey("dbo.UserRatingModels", "UserModel_UserId", "dbo.UserModels", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRatingModels", "UserModel_UserId", "dbo.UserModels");
            DropIndex("dbo.UserRatingModels", new[] { "UserModel_UserId" });
            DropColumn("dbo.UserRatingModels", "UserModel_UserId");
        }
    }
}
