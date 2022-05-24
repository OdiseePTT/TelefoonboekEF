namespace Telefoonboek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAddressToPhoneBookItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhoneBookItems", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhoneBookItems", "Address");
        }
    }
}
