namespace Messenger_King_Courier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MsengerKingCourier : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountCategories",
                c => new
                    {
                        AccountCat_ID = c.String(nullable: false, maxLength: 128),
                        Account_Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AccountCat_ID);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Bank_ID = c.Int(nullable: false, identity: true),
                        Bank_Account_Holder = c.String(nullable: false),
                        Debit_Date = c.DateTime(nullable: false),
                        Driver_IDNo = c.String(maxLength: 128),
                        CLient_IDNo = c.String(maxLength: 128),
                        BankCat_ID = c.String(maxLength: 128),
                        AccountCat_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Bank_ID)
                .ForeignKey("dbo.AccountCategories", t => t.AccountCat_ID)
                .ForeignKey("dbo.BankCategories", t => t.BankCat_ID)
                .ForeignKey("dbo.Clients", t => t.CLient_IDNo)
                .ForeignKey("dbo.Drivers", t => t.Driver_IDNo)
                .Index(t => t.Driver_IDNo)
                .Index(t => t.CLient_IDNo)
                .Index(t => t.BankCat_ID)
                .Index(t => t.AccountCat_ID);
            
            CreateTable(
                "dbo.BankCategories",
                c => new
                    {
                        BankCat_ID = c.String(nullable: false, maxLength: 128),
                        Bank_Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BankCat_ID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        CLient_IDNo = c.String(nullable: false, maxLength: 128),
                        Client_Name = c.String(nullable: false),
                        Client_Surname = c.String(nullable: false),
                        Client_Cellnumber = c.String(nullable: false),
                        Client_Address = c.String(nullable: false),
                        Client_Email = c.String(nullable: false),
                        Client_Tellnum = c.String(nullable: false),
                        ClientCat_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CLient_IDNo)
                .ForeignKey("dbo.ClientCategories", t => t.ClientCat_ID)
                .Index(t => t.ClientCat_ID);
            
            CreateTable(
                "dbo.ClientCategories",
                c => new
                    {
                        ClientCat_ID = c.String(nullable: false, maxLength: 128),
                        ClientCat_Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClientCat_ID);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Driver_IDNo = c.String(nullable: false, maxLength: 128),
                        Driver_Name = c.String(nullable: false),
                        Driver_Surname = c.String(nullable: false),
                        Driver_CellNo = c.String(nullable: false),
                        Driver_Address = c.String(nullable: false),
                        Driver_Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Driver_IDNo);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Documents_ID = c.Int(nullable: false, identity: true),
                        Document_ID = c.Binary(),
                        Document_Residence = c.Binary(),
                        Document_Statement = c.Binary(),
                        Client_ID = c.Int(nullable: false),
                        Driver_ID = c.Int(nullable: false),
                        Client_CLient_IDNo = c.String(maxLength: 128),
                        Driver_Driver_IDNo = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Documents_ID)
                .ForeignKey("dbo.Clients", t => t.Client_CLient_IDNo)
                .ForeignKey("dbo.Drivers", t => t.Driver_Driver_IDNo)
                .Index(t => t.Client_CLient_IDNo)
                .Index(t => t.Driver_Driver_IDNo);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Book_ID = c.Int(nullable: false, identity: true),
                        Book_PickupDate = c.DateTime(nullable: false),
                        Book_DeliveryDate = c.DateTime(nullable: false),
                        Book_RecipientName = c.String(nullable: false),
                        Book_RecipientSurname = c.String(nullable: false),
                        Book_RecipientNumber = c.String(nullable: false),
                        Book_DeliveryNote = c.String(maxLength: 250),
                        Book_TotalCost = c.Double(nullable: false),
                        Quote_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Book_ID)
                .ForeignKey("dbo.Quotes", t => t.Quote_ID, cascadeDelete: true)
                .Index(t => t.Quote_ID);
            
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        Quote_ID = c.Int(nullable: false, identity: true),
                        Quote_Date = c.DateTime(nullable: false),
                        Quote_PickupAddress = c.String(nullable: false),
                        Quote_DeliveryAddress = c.String(nullable: false),
                        Quote_Distance = c.Single(nullable: false),
                        Quote_Description = c.String(nullable: false),
                        Quote_Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Item_Quantity = c.Int(nullable: false),
                        Quote_length = c.Int(nullable: false),
                        Quote_Height = c.Int(nullable: false),
                        Quote_Width = c.Int(nullable: false),
                        Quote_Weight = c.Int(nullable: false),
                        Client_ID = c.Int(nullable: false),
                        Rate_ID = c.Int(nullable: false),
                        Client_CLient_IDNo = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Quote_ID)
                .ForeignKey("dbo.Clients", t => t.Client_CLient_IDNo)
                .ForeignKey("dbo.Rates", t => t.Rate_ID, cascadeDelete: true)
                .Index(t => t.Rate_ID)
                .Index(t => t.Client_CLient_IDNo);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Rate_ID = c.Int(nullable: false, identity: true),
                        Base_Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rate_PerCM = c.Int(nullable: false),
                        Rate_PerKG = c.Int(nullable: false),
                        Rate_PerKM = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Rate_ID);
            
            CreateTable(
                "dbo.InspectionCategories",
                c => new
                    {
                        InspectCat_ID = c.Int(nullable: false, identity: true),
                        InspectCat_Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.InspectCat_ID);
            
            CreateTable(
                "dbo.Inspections",
                c => new
                    {
                        Inspection_ID = c.Int(nullable: false, identity: true),
                        Condition = c.String(),
                        Inspection_Date = c.DateTime(nullable: false),
                        Vehicle_ID = c.Int(nullable: false),
                        InspectCat_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Inspection_ID)
                .ForeignKey("dbo.InspectionCategories", t => t.InspectCat_ID, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_ID, cascadeDelete: true)
                .Index(t => t.Vehicle_ID)
                .Index(t => t.InspectCat_ID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Vehicle_ID = c.Int(nullable: false),
                        Vehicle_Make = c.String(nullable: false),
                        Vehicle_Model = c.String(nullable: false),
                        Vehicle_Year = c.DateTime(nullable: false),
                        Vehicle_RegNo = c.String(nullable: false),
                        Vehicle_Colour = c.String(nullable: false),
                        Driver_ID = c.Int(nullable: false),
                        Driver_Driver_IDNo = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Vehicle_ID)
                .ForeignKey("dbo.Drivers", t => t.Driver_Driver_IDNo)
                .Index(t => t.Driver_Driver_IDNo);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Invoice_ID = c.Int(nullable: false, identity: true),
                        Invoice_Date = c.DateTime(nullable: false),
                        Invoice_Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Invoice_DueDate = c.DateTime(nullable: false),
                        Invoice_AmountDue = c.DateTime(nullable: false),
                        Invoice_VAT = c.DateTime(nullable: false),
                        Order_ID = c.Int(nullable: false),
                        Month_ID = c.Int(nullable: false),
                        Bank_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Invoice_ID)
                .ForeignKey("dbo.Banks", t => t.Bank_ID, cascadeDelete: true)
                .ForeignKey("dbo.Months", t => t.Month_ID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_ID, cascadeDelete: true)
                .Index(t => t.Order_ID)
                .Index(t => t.Month_ID)
                .Index(t => t.Bank_ID);
            
            CreateTable(
                "dbo.Months",
                c => new
                    {
                        Month_ID = c.Int(nullable: false, identity: true),
                        Book_RecipientName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Month_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Order_ID = c.Int(nullable: false, identity: true),
                        Order_DateTime = c.DateTime(nullable: false),
                        Order_DeliveryDate = c.DateTime(nullable: false),
                        Book_ID = c.Int(nullable: false),
                        Inspection_ID = c.Int(nullable: false),
                        OrderCat_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Order_ID)
                .ForeignKey("dbo.Bookings", t => t.Book_ID, cascadeDelete: true)
                .ForeignKey("dbo.Inspections", t => t.Inspection_ID, cascadeDelete: true)
                .ForeignKey("dbo.OrderCategories", t => t.OrderCat_ID, cascadeDelete: true)
                .Index(t => t.Book_ID)
                .Index(t => t.Inspection_ID)
                .Index(t => t.OrderCat_ID);
            
            CreateTable(
                "dbo.OrderCategories",
                c => new
                    {
                        OrderCat_ID = c.Int(nullable: false, identity: true),
                        OrderCat_Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrderCat_ID);
            
            CreateTable(
                "dbo.Trackings",
                c => new
                    {
                        Track_ID = c.Int(nullable: false),
                        Track_Message = c.Int(nullable: false),
                        TrackingCat_ID = c.Int(nullable: false),
                        Order_ID = c.Int(nullable: false),
                        TrackingStat_ID = c.Int(nullable: false),
                        TrackingCategory_TrackingCat_ID = c.Int(),
                        Tracking_Category_TrackingCat_ID = c.Int(),
                        TrackingCategory_TrackingCat_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.Track_ID)
                .ForeignKey("dbo.Orders", t => t.Order_ID, cascadeDelete: true)
                .ForeignKey("dbo.TrackingCategories", t => t.TrackingCategory_TrackingCat_ID)
                .ForeignKey("dbo.TrackingCategories", t => t.Tracking_Category_TrackingCat_ID)
                .ForeignKey("dbo.TrackingCategories", t => t.TrackingCategory_TrackingCat_ID1)
                .Index(t => t.Order_ID)
                .Index(t => t.TrackingCategory_TrackingCat_ID)
                .Index(t => t.Tracking_Category_TrackingCat_ID)
                .Index(t => t.TrackingCategory_TrackingCat_ID1);
            
            CreateTable(
                "dbo.TrackingCategories",
                c => new
                    {
                        TrackingCat_ID = c.Int(nullable: false, identity: true),
                        TrackingCat_Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TrackingCat_ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Trackings", "TrackingCategory_TrackingCat_ID1", "dbo.TrackingCategories");
            DropForeignKey("dbo.Trackings", "Tracking_Category_TrackingCat_ID", "dbo.TrackingCategories");
            DropForeignKey("dbo.Trackings", "TrackingCategory_TrackingCat_ID", "dbo.TrackingCategories");
            DropForeignKey("dbo.Trackings", "Order_ID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "OrderCat_ID", "dbo.OrderCategories");
            DropForeignKey("dbo.Invoices", "Order_ID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Inspection_ID", "dbo.Inspections");
            DropForeignKey("dbo.Orders", "Book_ID", "dbo.Bookings");
            DropForeignKey("dbo.Invoices", "Month_ID", "dbo.Months");
            DropForeignKey("dbo.Invoices", "Bank_ID", "dbo.Banks");
            DropForeignKey("dbo.Inspections", "Vehicle_ID", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "Driver_Driver_IDNo", "dbo.Drivers");
            DropForeignKey("dbo.Inspections", "InspectCat_ID", "dbo.InspectionCategories");
            DropForeignKey("dbo.Bookings", "Quote_ID", "dbo.Quotes");
            DropForeignKey("dbo.Quotes", "Rate_ID", "dbo.Rates");
            DropForeignKey("dbo.Quotes", "Client_CLient_IDNo", "dbo.Clients");
            DropForeignKey("dbo.Documents", "Driver_Driver_IDNo", "dbo.Drivers");
            DropForeignKey("dbo.Documents", "Client_CLient_IDNo", "dbo.Clients");
            DropForeignKey("dbo.Banks", "Driver_IDNo", "dbo.Drivers");
            DropForeignKey("dbo.Banks", "CLient_IDNo", "dbo.Clients");
            DropForeignKey("dbo.Clients", "ClientCat_ID", "dbo.ClientCategories");
            DropForeignKey("dbo.Banks", "BankCat_ID", "dbo.BankCategories");
            DropForeignKey("dbo.Banks", "AccountCat_ID", "dbo.AccountCategories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Trackings", new[] { "TrackingCategory_TrackingCat_ID1" });
            DropIndex("dbo.Trackings", new[] { "Tracking_Category_TrackingCat_ID" });
            DropIndex("dbo.Trackings", new[] { "TrackingCategory_TrackingCat_ID" });
            DropIndex("dbo.Trackings", new[] { "Order_ID" });
            DropIndex("dbo.Orders", new[] { "OrderCat_ID" });
            DropIndex("dbo.Orders", new[] { "Inspection_ID" });
            DropIndex("dbo.Orders", new[] { "Book_ID" });
            DropIndex("dbo.Invoices", new[] { "Bank_ID" });
            DropIndex("dbo.Invoices", new[] { "Month_ID" });
            DropIndex("dbo.Invoices", new[] { "Order_ID" });
            DropIndex("dbo.Vehicles", new[] { "Driver_Driver_IDNo" });
            DropIndex("dbo.Inspections", new[] { "InspectCat_ID" });
            DropIndex("dbo.Inspections", new[] { "Vehicle_ID" });
            DropIndex("dbo.Quotes", new[] { "Client_CLient_IDNo" });
            DropIndex("dbo.Quotes", new[] { "Rate_ID" });
            DropIndex("dbo.Bookings", new[] { "Quote_ID" });
            DropIndex("dbo.Documents", new[] { "Driver_Driver_IDNo" });
            DropIndex("dbo.Documents", new[] { "Client_CLient_IDNo" });
            DropIndex("dbo.Clients", new[] { "ClientCat_ID" });
            DropIndex("dbo.Banks", new[] { "AccountCat_ID" });
            DropIndex("dbo.Banks", new[] { "BankCat_ID" });
            DropIndex("dbo.Banks", new[] { "CLient_IDNo" });
            DropIndex("dbo.Banks", new[] { "Driver_IDNo" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TrackingCategories");
            DropTable("dbo.Trackings");
            DropTable("dbo.OrderCategories");
            DropTable("dbo.Orders");
            DropTable("dbo.Months");
            DropTable("dbo.Invoices");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Inspections");
            DropTable("dbo.InspectionCategories");
            DropTable("dbo.Rates");
            DropTable("dbo.Quotes");
            DropTable("dbo.Bookings");
            DropTable("dbo.Documents");
            DropTable("dbo.Drivers");
            DropTable("dbo.ClientCategories");
            DropTable("dbo.Clients");
            DropTable("dbo.BankCategories");
            DropTable("dbo.Banks");
            DropTable("dbo.AccountCategories");
        }
    }
}
