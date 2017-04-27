namespace PayItForward.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusToDonationCenter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonationCenters", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonationCenters", "Status");
        }
    }
}
