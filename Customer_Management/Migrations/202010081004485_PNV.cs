namespace Customer_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PNV : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        DOB = c.DateTime(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        GioiTinh = c.String(maxLength: 4000),
                        PictureId = c.String(maxLength: 500),
                        TypeofCustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeOfCustomer", t => t.TypeofCustomerId, cascadeDelete: true)
                .Index(t => t.TypeofCustomerId);
            
            CreateTable(
                "dbo.TypeOfCustomer",
                c => new
                    {
                        IdOftype = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.IdOftype);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "TypeofCustomerId", "dbo.TypeOfCustomer");
            DropIndex("dbo.Customer", new[] { "TypeofCustomerId" });
            DropTable("dbo.TypeOfCustomer");
            DropTable("dbo.Customer");
        }
    }
}
