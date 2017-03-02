namespace PayItForward.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListsAsStrings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "itemString", c => c.String());
            AddColumn("dbo.DonationCenters", "CategoryNamesAsString", c => c.String());
            AddColumn("dbo.Users", "centersAsString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "centersAsString");
            DropColumn("dbo.DonationCenters", "CategoryNamesAsString");
            DropColumn("dbo.Categories", "itemString");
        }
    }
}
