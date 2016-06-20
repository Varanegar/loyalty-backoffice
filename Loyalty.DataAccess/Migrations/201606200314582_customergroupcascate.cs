namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customergroupcascate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerGroups", "CustomerGroup2Id", "dbo.CustomerGroups");
            DropIndex("dbo.CustomerGroups", new[] { "CustomerGroup2Id" });
            DropColumn("dbo.CustomerGroups", "CustomerGroup2Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerGroups", "CustomerGroup2Id", c => c.Guid());
            CreateIndex("dbo.CustomerGroups", "CustomerGroup2Id");
            AddForeignKey("dbo.CustomerGroups", "CustomerGroup2Id", "dbo.CustomerGroups", "Id");
        }
    }
}
