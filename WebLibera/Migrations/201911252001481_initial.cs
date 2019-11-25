namespace WebLibera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tittle = c.String(),
                        Content = c.String(),
                        ImagePath = c.String(),
                        imgData = c.Binary(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AnsweredQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entries", "UserId", "dbo.Users");
            DropIndex("dbo.Entries", new[] { "UserId" });
            DropTable("dbo.AnsweredQuestions");
            DropTable("dbo.Users");
            DropTable("dbo.Entries");
        }
    }
}
