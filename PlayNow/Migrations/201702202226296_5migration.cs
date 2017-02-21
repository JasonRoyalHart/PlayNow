namespace PlayNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PublicPlaceModels", "Website", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PublicPlaceModels", "Website");
        }
    }
}
