namespace Auth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserForm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserForms",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        UserId = c.Long(nullable: false),
                        Values = c.String(),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserForms", "UserId", "dbo.Users");
            DropIndex("dbo.UserForms", new[] { "UserId" });
            DropTable("dbo.UserForms");
        }
    }
}
