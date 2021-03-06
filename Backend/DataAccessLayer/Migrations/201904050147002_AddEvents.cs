namespace Gucci.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEvents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EventName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "UserId", "dbo.User");
            DropIndex("dbo.Event", new[] { "UserId" });
            DropTable("dbo.Event");
        }
    }
}
