namespace PayItForward.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Valuation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemsAsString = c.String(),
                        DonationDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Items", "LowPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Items", "HighPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Users", "DonationsString", c => c.String());
            DropColumn("dbo.Items", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Users", "DonationsString");
            DropColumn("dbo.Items", "HighPrice");
            DropColumn("dbo.Items", "LowPrice");
            DropTable("dbo.Donations");
        }
    }
}
