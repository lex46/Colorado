namespace Auth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoleUsers",
                c => new
                    {
                        UserRole_Id = c.Long(nullable: false),
                        User_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserRole_Id, t.User_Id })
                .ForeignKey("dbo.UserRoles", t => t.UserRole_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.UserRole_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoleUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoleUsers", "UserRole_Id", "dbo.UserRoles");
            DropIndex("dbo.UserRoleUsers", new[] { "User_Id" });
            DropIndex("dbo.UserRoleUsers", new[] { "UserRole_Id" });
            DropTable("dbo.UserRoleUsers");
            DropTable("dbo.UserRoles");
        }
    }
}
