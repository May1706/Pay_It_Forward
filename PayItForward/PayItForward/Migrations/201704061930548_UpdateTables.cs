namespace PayItForward.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTables : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Items", new[] { "Category_Id" });
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        LastUpdateTime = c.DateTime(nullable: false),
                        MessageInfo = c.String(),
                        Status = c.Int(nullable: false),
                        CallingId = c.Int(nullable: false),
                        Request_RequestId = c.Int(),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Requests", t => t.Request_RequestId)
                .Index(t => t.Request_RequestId);
            
            CreateIndex("dbo.Items", "Category_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "Request_RequestId", "dbo.Requests");
            DropIndex("dbo.Requests", new[] { "Request_RequestId" });
            DropIndex("dbo.Items", new[] { "Category_ID" });
            DropTable("dbo.Requests");
            CreateIndex("dbo.Items", "Category_Id");
        }
    }
}
