namespace VehicleLevel3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleMakeEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abrv = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VehicleModelEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abrv = c.String(),
                        Color = c.String(),
                        VehicleMakeID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.VehicleMakeEntities", t => t.VehicleMakeID)
                .Index(t => t.VehicleMakeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleModelEntities", "VehicleMakeID", "dbo.VehicleMakeEntities");
            DropIndex("dbo.VehicleModelEntities", new[] { "VehicleMakeID" });
            DropTable("dbo.VehicleModelEntities");
            DropTable("dbo.VehicleMakeEntities");
        }
    }
}
