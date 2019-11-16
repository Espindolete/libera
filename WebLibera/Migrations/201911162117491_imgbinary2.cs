namespace WebLibera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgbinary2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Entries", "imgData", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Entries", "imgData", c => c.Byte(nullable: false));
        }
    }
}
