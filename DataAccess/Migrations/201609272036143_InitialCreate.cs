namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingComment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        Comment = c.String(nullable: false),
                        BuildingID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Building", t => t.BuildingID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.BuildingID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Building",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        ZIP = c.String(maxLength: 5),
                        StateID = c.Int(nullable: false),
                        LandlordID = c.Int(nullable: false),
                        NeighborhoodID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Landlord", t => t.LandlordID, cascadeDelete: true)
                .ForeignKey("dbo.Neighborhood", t => t.NeighborhoodID, cascadeDelete: true)
                .ForeignKey("dbo.State", t => t.StateID, cascadeDelete: true)
                .Index(t => t.StateID)
                .Index(t => t.LandlordID)
                .Index(t => t.NeighborhoodID);
            
            CreateTable(
                "dbo.Landlord",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Neighborhood",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Residence",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BuildingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Building", t => t.BuildingID, cascadeDelete: true)
                .Index(t => t.BuildingID);
            
            CreateTable(
                "dbo.Renter",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        ResidenceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Residence", t => t.ResidenceID, cascadeDelete: true)
                .Index(t => t.ResidenceID);
            
            CreateTable(
                "dbo.ResidenceComment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        Comment = c.String(nullable: false),
                        ResidenceID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Residence", t => t.ResidenceID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.ResidenceID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 40),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Abbreviation = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.File",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        URL = c.String(nullable: false, maxLength: 1000),
                        FileTypeID = c.Int(nullable: false),
                        BuildingID = c.Int(),
                        ResidenceID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Building", t => t.BuildingID)
                .ForeignKey("dbo.FileType", t => t.FileTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Residence", t => t.ResidenceID)
                .Index(t => t.URL, unique: true)
                .Index(t => t.FileTypeID)
                .Index(t => t.BuildingID)
                .Index(t => t.ResidenceID);
            
            CreateTable(
                "dbo.FileType",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);           
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.File", "ResidenceID", "dbo.Residence");
            DropForeignKey("dbo.File", "FileTypeID", "dbo.FileType");
            DropForeignKey("dbo.File", "BuildingID", "dbo.Building");
            DropForeignKey("dbo.BuildingComment", "UserID", "dbo.User");
            DropForeignKey("dbo.Building", "StateID", "dbo.State");
            DropForeignKey("dbo.ResidenceComment", "UserID", "dbo.User");
            DropForeignKey("dbo.ResidenceComment", "ResidenceID", "dbo.Residence");
            DropForeignKey("dbo.Renter", "ResidenceID", "dbo.Residence");
            DropForeignKey("dbo.Residence", "BuildingID", "dbo.Building");
            DropForeignKey("dbo.Building", "NeighborhoodID", "dbo.Neighborhood");
            DropForeignKey("dbo.Building", "LandlordID", "dbo.Landlord");
            DropForeignKey("dbo.BuildingComment", "BuildingID", "dbo.Building");
            DropIndex("dbo.File", new[] { "ResidenceID" });
            DropIndex("dbo.File", new[] { "BuildingID" });
            DropIndex("dbo.File", new[] { "FileTypeID" });
            DropIndex("dbo.File", new[] { "URL" });
            DropIndex("dbo.User", new[] { "Username" });
            DropIndex("dbo.ResidenceComment", new[] { "UserID" });
            DropIndex("dbo.ResidenceComment", new[] { "ResidenceID" });
            DropIndex("dbo.Renter", new[] { "ResidenceID" });
            DropIndex("dbo.Residence", new[] { "BuildingID" });
            DropIndex("dbo.Building", new[] { "NeighborhoodID" });
            DropIndex("dbo.Building", new[] { "LandlordID" });
            DropIndex("dbo.Building", new[] { "StateID" });
            DropIndex("dbo.BuildingComment", new[] { "UserID" });
            DropIndex("dbo.BuildingComment", new[] { "BuildingID" });
            DropTable("dbo.FileType");
            DropTable("dbo.File");
            DropTable("dbo.State");
            DropTable("dbo.User");
            DropTable("dbo.ResidenceComment");
            DropTable("dbo.Renter");
            DropTable("dbo.Residence");
            DropTable("dbo.Neighborhood");
            DropTable("dbo.Landlord");
            DropTable("dbo.Building");
            DropTable("dbo.BuildingComment");
        }
    }
}