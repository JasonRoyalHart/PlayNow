namespace PlayNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RPGSessionModels", "GMName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RPGSessionModels", "GMName");
        }
    }
}
