namespace Practice5.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Color = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlantationFlowers",
                c => new
                    {
                        FlowerId = c.Int(nullable: false),
                        PlantationId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FlowerId, t.PlantationId })
                .ForeignKey("dbo.Flowers", t => t.FlowerId, cascadeDelete: true)
                .ForeignKey("dbo.Plantations", t => t.PlantationId, cascadeDelete: true)
                .Index(t => t.FlowerId)
                .Index(t => t.PlantationId);
            
            CreateTable(
                "dbo.Plantations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Adress = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Supplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlantationId = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        ScheduledDate = c.DateTime(nullable: false),
                        ClosedDate = c.DateTime(),
                        Status = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plantations", t => t.PlantationId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.PlantationId)
                .Index(t => t.WarehouseId);
            
            CreateTable(
                "dbo.SupplyFlowers",
                c => new
                    {
                        FlowerId = c.Int(nullable: false),
                        SupplyId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FlowerId, t.SupplyId })
                .ForeignKey("dbo.Flowers", t => t.FlowerId, cascadeDelete: true)
                .ForeignKey("dbo.Supplies", t => t.SupplyId, cascadeDelete: true)
                .Index(t => t.FlowerId)
                .Index(t => t.SupplyId);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Adress = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WarehouseFlowers",
                c => new
                    {
                        FlowerId = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FlowerId, t.WarehouseId })
                .ForeignKey("dbo.Flowers", t => t.FlowerId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.FlowerId)
                .Index(t => t.WarehouseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlantationFlowers", "PlantationId", "dbo.Plantations");
            DropForeignKey("dbo.Supplies", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.WarehouseFlowers", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.WarehouseFlowers", "FlowerId", "dbo.Flowers");
            DropForeignKey("dbo.SupplyFlowers", "SupplyId", "dbo.Supplies");
            DropForeignKey("dbo.SupplyFlowers", "FlowerId", "dbo.Flowers");
            DropForeignKey("dbo.Supplies", "PlantationId", "dbo.Plantations");
            DropForeignKey("dbo.PlantationFlowers", "FlowerId", "dbo.Flowers");
            DropIndex("dbo.WarehouseFlowers", new[] { "WarehouseId" });
            DropIndex("dbo.WarehouseFlowers", new[] { "FlowerId" });
            DropIndex("dbo.SupplyFlowers", new[] { "SupplyId" });
            DropIndex("dbo.SupplyFlowers", new[] { "FlowerId" });
            DropIndex("dbo.Supplies", new[] { "WarehouseId" });
            DropIndex("dbo.Supplies", new[] { "PlantationId" });
            DropIndex("dbo.PlantationFlowers", new[] { "PlantationId" });
            DropIndex("dbo.PlantationFlowers", new[] { "FlowerId" });
            DropTable("dbo.WarehouseFlowers");
            DropTable("dbo.Warehouses");
            DropTable("dbo.SupplyFlowers");
            DropTable("dbo.Supplies");
            DropTable("dbo.Plantations");
            DropTable("dbo.PlantationFlowers");
            DropTable("dbo.Flowers");
        }
    }
}
