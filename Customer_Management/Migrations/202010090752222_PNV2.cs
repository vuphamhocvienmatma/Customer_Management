namespace Customer_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PNV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeOfCustomer", "PictureId", c => c.String());
            AddColumn("dbo.TypeOfCustomer", "Details", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.TypeOfCustomer", "Details");
            DropColumn("dbo.TypeOfCustomer", "PictureId");
        }
    }
}