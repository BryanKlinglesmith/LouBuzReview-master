namespace WebReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WebsiteReviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        WebsiteID = c.Int(nullable: false),
                        Ratings = c.Int(),
                        UserReview = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Websites", t => t.WebsiteID, cascadeDelete: true)
                .ForeignKey("dbo.WebUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.WebsiteID);
            
            CreateTable(
                "dbo.Websites",
                c => new
                    {
                        WebsiteID = c.Int(nullable: false, identity: true),
                        Category = c.Int(),
                        WebsiteUrl = c.String(),
                        WebsiteName = c.String(),
                    })
                .PrimaryKey(t => t.WebsiteID);
            
            CreateTable(
                "dbo.WebUsers",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        City = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WebsiteReviews", "UserID", "dbo.WebUsers");
            DropForeignKey("dbo.WebsiteReviews", "WebsiteID", "dbo.Websites");
            DropIndex("dbo.WebsiteReviews", new[] { "WebsiteID" });
            DropIndex("dbo.WebsiteReviews", new[] { "UserID" });
            DropTable("dbo.WebUsers");
            DropTable("dbo.Websites");
            DropTable("dbo.WebsiteReviews");
        }
    }
}
