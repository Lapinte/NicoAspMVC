namespace Roomax.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropComfirmedPassword : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "ComfirmedPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ComfirmedPassword", c => c.String(nullable: false));
        }
    }
}
