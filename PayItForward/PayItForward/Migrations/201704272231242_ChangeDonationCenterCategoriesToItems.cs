namespace PayItForward.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDonationCenterCategoriesToItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonationCenters", "ItemNamesAsString", c => c.String());
            DropColumn("dbo.DonationCenters", "CategoryNamesAsString");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DonationCenters", "CategoryNamesAsString", c => c.String());
            DropColumn("dbo.DonationCenters", "ItemNamesAsString");
        }
    }
}
