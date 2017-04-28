namespace PayItForward.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValuesAsDecimals : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.Items DROP CONSTRAINT DF__tmp_ms_xx__LowPr__681373AD");
            Sql("ALTER TABLE dbo.Items DROP CONSTRAINT DF__tmp_ms_xx__HighP__690797E6");
            AlterColumn("dbo.Items", "LowPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Items", "HighPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "HighPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Items", "LowPrice", c => c.Double(nullable: false));
        }
    }
}
