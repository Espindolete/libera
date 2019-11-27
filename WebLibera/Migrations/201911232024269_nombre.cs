namespace WebLibera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nombre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnsweredQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Entries", "ImagePath", c => c.String());
            AddColumn("dbo.Entries", "imgData", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entries", "imgData");
            DropColumn("dbo.Entries", "ImagePath");
            DropTable("dbo.AnsweredQuestions");
        }
    }
}
