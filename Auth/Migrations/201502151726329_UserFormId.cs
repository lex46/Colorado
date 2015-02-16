namespace Auth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFormId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserForms");
            AddColumn("dbo.UserForms", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.UserForms", "Name", c => c.String());
            AddPrimaryKey("dbo.UserForms", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserForms");
            AlterColumn("dbo.UserForms", "Name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.UserForms", "Id");
            AddPrimaryKey("dbo.UserForms", "Name");
        }
    }
}
