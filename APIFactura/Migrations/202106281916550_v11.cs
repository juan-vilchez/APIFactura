namespace APIFactura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceDetails", "Description", c => c.String());
            DropColumn("dbo.InvoiceDetails", "OrderDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvoiceDetails", "OrderDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.InvoiceDetails", "Description");
        }
    }
}
