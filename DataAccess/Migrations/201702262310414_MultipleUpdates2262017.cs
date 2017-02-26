namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class MultipleUpdates2262017 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ResidenceComment", "UserID", "dbo.User");
            DropForeignKey("dbo.BuildingComment", "UserID", "dbo.User");
            RenameColumn(table: "dbo.ResidenceComment", name: "UserID", newName: "CreatedByID");
            RenameColumn(table: "dbo.BuildingComment", name: "UserID", newName: "CreatedByID");
            RenameIndex(table: "dbo.BuildingComment", name: "IX_UserID", newName: "IX_CreatedByID");
            RenameIndex(table: "dbo.ResidenceComment", name: "IX_UserID", newName: "IX_CreatedByID");
            CreateTable(
                "dbo.PropertyManagementCompany",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 100),
                        ZIP = c.String(maxLength: 5),
                        StateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.State", t => t.StateID)
                .Index(t => t.StateID);
            
            CreateTable(
                "dbo.PropertyManagementCompanyComment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PropertyManagementCompanyID = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        Value = c.String(nullable: false, maxLength: 500),
                        CreatedByID = c.Int(nullable: false),
                        LastUpdatedByID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.CreatedByID)
                .ForeignKey("dbo.User", t => t.LastUpdatedByID)
                .ForeignKey("dbo.PropertyManagementCompany", t => t.PropertyManagementCompanyID, cascadeDelete: true)
                .Index(t => t.PropertyManagementCompanyID)
                .Index(t => t.CreatedByID)
                .Index(t => t.LastUpdatedByID);
            
            CreateTable(
                "dbo.NeighborhoodAssociation",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ContactFirstName = c.String(maxLength: 100),
                        ContactLastName = c.String(maxLength: 100),
                        ContactTitle = c.String(maxLength: 100),
                        ContactPhoneNumber = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.BuildingComment", "LastUpdatedByID", c => c.Int(nullable: false));
            AddColumn("dbo.Landlord", "Address", c => c.String(maxLength: 100));
            AddColumn("dbo.Landlord", "City", c => c.String(maxLength: 100));
            AddColumn("dbo.Landlord", "ZIP", c => c.String(maxLength: 5));
            AddColumn("dbo.Landlord", "StateID", c => c.Int());
            AddColumn("dbo.Landlord", "PropertyManagementCompanyID", c => c.Int());
            AddColumn("dbo.Renter", "PhoneNumber", c => c.String(maxLength: 10));
            AddColumn("dbo.ResidenceComment", "LastUpdatedByID", c => c.Int(nullable: false));
            Sql(@"
            UPDATE [ResidenceComment] SET [LastUpdatedByID] = [CreatedByID]
            UPDATE [BuildingComment] SET [LastUpdatedByID] = [CreatedByID]
            ");
            AlterColumn("dbo.Building", "Address", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Building", "City", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Building", "ZIP", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Landlord", "FirstName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Landlord", "LastName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Neighborhood", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Residence", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Renter", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Renter", "LastName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.State", "Abbreviation", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.State", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.FileType", "Name", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.BuildingComment", "LastUpdatedByID");
            CreateIndex("dbo.Landlord", "StateID");
            CreateIndex("dbo.Landlord", "PropertyManagementCompanyID");
            CreateIndex("dbo.ResidenceComment", "LastUpdatedByID");
            AddForeignKey("dbo.Landlord", "PropertyManagementCompanyID", "dbo.PropertyManagementCompany", "ID");
            AddForeignKey("dbo.Landlord", "StateID", "dbo.State", "ID");
            AddForeignKey("dbo.ResidenceComment", "LastUpdatedByID", "dbo.User", "ID");
            AddForeignKey("dbo.BuildingComment", "LastUpdatedByID", "dbo.User", "ID");
            AddForeignKey("dbo.ResidenceComment", "CreatedByID", "dbo.User", "ID");
            AddForeignKey("dbo.BuildingComment", "CreatedByID", "dbo.User", "ID");
            RenameColumn("dbo.ResidenceComment", "Comment", "Value");
            AlterColumn("dbo.ResidenceComment", "Value", c => c.String(nullable: false, maxLength: 500));
            RenameColumn("dbo.BuildingComment", "Comment", "Value");
            AlterColumn("dbo.BuildingComment", "Value", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuildingComment", "CreatedByID", "dbo.User");
            DropForeignKey("dbo.ResidenceComment", "CreatedByID", "dbo.User");
            DropForeignKey("dbo.BuildingComment", "LastUpdatedByID", "dbo.User");
            DropForeignKey("dbo.ResidenceComment", "LastUpdatedByID", "dbo.User");
            DropForeignKey("dbo.Landlord", "StateID", "dbo.State");
            DropForeignKey("dbo.PropertyManagementCompany", "StateID", "dbo.State");
            DropForeignKey("dbo.Landlord", "PropertyManagementCompanyID", "dbo.PropertyManagementCompany");
            DropForeignKey("dbo.PropertyManagementCompanyComment", "PropertyManagementCompanyID", "dbo.PropertyManagementCompany");
            DropForeignKey("dbo.PropertyManagementCompanyComment", "LastUpdatedByID", "dbo.User");
            DropForeignKey("dbo.PropertyManagementCompanyComment", "CreatedByID", "dbo.User");
            DropIndex("dbo.ResidenceComment", new[] { "LastUpdatedByID" });
            DropIndex("dbo.PropertyManagementCompanyComment", new[] { "LastUpdatedByID" });
            DropIndex("dbo.PropertyManagementCompanyComment", new[] { "CreatedByID" });
            DropIndex("dbo.PropertyManagementCompanyComment", new[] { "PropertyManagementCompanyID" });
            DropIndex("dbo.PropertyManagementCompany", new[] { "StateID" });
            DropIndex("dbo.Landlord", new[] { "PropertyManagementCompanyID" });
            DropIndex("dbo.Landlord", new[] { "StateID" });
            DropIndex("dbo.BuildingComment", new[] { "LastUpdatedByID" });
            AlterColumn("dbo.FileType", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.State", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.State", "Abbreviation", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Renter", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Renter", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Residence", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Neighborhood", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Landlord", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Landlord", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Building", "ZIP", c => c.String(maxLength: 5));
            AlterColumn("dbo.Building", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Building", "Address", c => c.String(nullable: false));
            DropColumn("dbo.ResidenceComment", "LastUpdatedByID");
            DropColumn("dbo.Renter", "PhoneNumber");
            DropColumn("dbo.Landlord", "PropertyManagementCompanyID");
            DropColumn("dbo.Landlord", "StateID");
            DropColumn("dbo.Landlord", "ZIP");
            DropColumn("dbo.Landlord", "City");
            DropColumn("dbo.Landlord", "Address");
            DropColumn("dbo.BuildingComment", "LastUpdatedByID");
            DropTable("dbo.NeighborhoodAssociation");
            DropTable("dbo.PropertyManagementCompanyComment");
            DropTable("dbo.PropertyManagementCompany");
            RenameColumn("dbo.ResidenceComment", "Value", "Comment");
            AlterColumn("dbo.ResidenceComment", "Comment", c => c.String(nullable: false));
            RenameColumn("dbo.BuildingComment", "Value", "Comment");
            AlterColumn("dbo.BuildingComment", "Comment", c => c.String(nullable: false));
            RenameIndex(table: "dbo.ResidenceComment", name: "IX_CreatedByID", newName: "IX_UserID");
            RenameIndex(table: "dbo.BuildingComment", name: "IX_CreatedByID", newName: "IX_UserID");
            RenameColumn(table: "dbo.BuildingComment", name: "CreatedByID", newName: "UserID");
            RenameColumn(table: "dbo.ResidenceComment", name: "CreatedByID", newName: "UserID");
            AddForeignKey("dbo.BuildingComment", "UserID", "dbo.User", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ResidenceComment", "UserID", "dbo.User", "ID", cascadeDelete: true);
        }
    }
}