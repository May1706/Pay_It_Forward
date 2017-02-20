namespace PayItForward.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CenterStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonationCenters", "LastUpdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonationCenters", "LastUpdate");
        }
    }
}
