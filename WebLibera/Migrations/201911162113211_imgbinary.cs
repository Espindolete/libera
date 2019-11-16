namespace WebLibera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgbinary : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Entries", "imgData", c => c.Byte(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Entries", "imgData", c => c.Binary());
        }
    }
}
