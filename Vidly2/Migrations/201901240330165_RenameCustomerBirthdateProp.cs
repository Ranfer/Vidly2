namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameCustomerBirthdateProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime());
            DropColumn("dbo.Customers", "Birthday");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Birthday", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}
