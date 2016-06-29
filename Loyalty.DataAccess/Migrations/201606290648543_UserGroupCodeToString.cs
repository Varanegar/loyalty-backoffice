namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserGroupCodeToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserGroups", "UserGroupCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserGroups", "UserGroupCode", c => c.Int(nullable: false));
        }
    }
}
