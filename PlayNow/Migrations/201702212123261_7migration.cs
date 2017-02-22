namespace PlayNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7migration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PublicPlaceRatingModels", new[] { "PublicPlace_PublicPlaceID" });
            DropIndex("dbo.GameModelPublicPlaceModels", new[] { "PublicPlaceModel_PublicPlaceID" });
            CreateIndex("dbo.PublicPlaceRatingModels", "PublicPlace_PublicPlaceId");
            CreateIndex("dbo.GameModelPublicPlaceModels", "PublicPlaceModel_PublicPlaceId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.GameModelPublicPlaceModels", new[] { "PublicPlaceModel_PublicPlaceId" });
            DropIndex("dbo.PublicPlaceRatingModels", new[] { "PublicPlace_PublicPlaceId" });
            CreateIndex("dbo.GameModelPublicPlaceModels", "PublicPlaceModel_PublicPlaceID");
            CreateIndex("dbo.PublicPlaceRatingModels", "PublicPlace_PublicPlaceID");
        }
    }
}
