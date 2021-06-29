namespace APIFactura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerFirstName = c.String(),
                        CustomerLastName = c.String(),
                        Dni = c.String(),
                        Phone = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        InvoiceAddress = c.String(),
                        RucIssuer = c.Int(nullable: false),
                        RucReceiver = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        State = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Igv = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdCustomer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Customers", t => t.IdCustomer, cascadeDelete: true)
                .Index(t => t.IdCustomer);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        InvoiceDetailId = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                        IdProduct = c.Int(nullable: false),
                        IdInvoice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceDetailId)
                .ForeignKey("dbo.Invoices", t => t.IdInvoice, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.IdProduct, cascadeDelete: true)
                .Index(t => t.IdProduct)
                .Index(t => t.IdInvoice);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Int(nullable: false),
                        Brand = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceDetails", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.InvoiceDetails", "IdInvoice", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "IdCustomer", "dbo.Customers");
            DropIndex("dbo.InvoiceDetails", new[] { "IdInvoice" });
            DropIndex("dbo.InvoiceDetails", new[] { "IdProduct" });
            DropIndex("dbo.Invoices", new[] { "IdCustomer" });
            DropTable("dbo.Products");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.Invoices");
            DropTable("dbo.Customers");
        }
    }
}
