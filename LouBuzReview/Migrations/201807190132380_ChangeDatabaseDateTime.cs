namespace WebReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDatabaseDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WebsiteReviews", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WebsiteReviews", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
