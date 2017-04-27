namespace PayItForward.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalDonationCenterFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "StringCategory", c => c.String());
            AddColumn("dbo.DonationCenters", "PhoneNumber", c => c.String());
            AddColumn("dbo.DonationCenters", "Description", c => c.String());
            AddColumn("dbo.DonationCenters", "Website", c => c.String());
            AddColumn("dbo.DonationCenters", "ImageURL", c => c.String());
            AddColumn("dbo.DonationCenters", "ContactEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonationCenters", "ContactEmail");
            DropColumn("dbo.DonationCenters", "ImageURL");
            DropColumn("dbo.DonationCenters", "Website");
            DropColumn("dbo.DonationCenters", "Description");
            DropColumn("dbo.DonationCenters", "PhoneNumber");
            DropColumn("dbo.Items", "StringCategory");
        }
    }
}
