namespace Practice5.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlantationFlowers", "FlowerId", "dbo.Flowers");
            DropForeignKey("dbo.SupplyFlowers", "FlowerId", "dbo.Flowers");
            DropForeignKey("dbo.WarehouseFlowers", "FlowerId", "dbo.Flowers");
            DropForeignKey("dbo.PlantationFlowers", "PlantationId", "dbo.Plantations");
            DropForeignKey("dbo.Supplies", "PlantationId", "dbo.Plantations");
            DropForeignKey("dbo.Supplies", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.WarehouseFlowers", "WarehouseId", "dbo.Warehouses");
            DropIndex("dbo.PlantationFlowers", new[] { "FlowerId" });
            DropIndex("dbo.PlantationFlowers", new[] { "PlantationId" });
            DropIndex("dbo.Supplies", new[] { "PlantationId" });
            DropIndex("dbo.Supplies", new[] { "WarehouseId" });
            DropIndex("dbo.SupplyFlowers", new[] { "FlowerId" });
            DropIndex("dbo.WarehouseFlowers", new[] { "FlowerId" });
            DropIndex("dbo.WarehouseFlowers", new[] { "WarehouseId" });
            DropPrimaryKey("dbo.PlantationFlowers");
            DropPrimaryKey("dbo.SupplyFlowers");
            DropPrimaryKey("dbo.WarehouseFlowers");
            AddColumn("dbo.PlantationFlowers", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.SupplyFlowers", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.WarehouseFlowers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PlantationFlowers", "FlowerId", c => c.Int());
            AlterColumn("dbo.PlantationFlowers", "PlantationId", c => c.Int());
            AlterColumn("dbo.Supplies", "PlantationId", c => c.Int());
            AlterColumn("dbo.Supplies", "WarehouseId", c => c.Int());
            AlterColumn("dbo.Supplies", "Status", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.SupplyFlowers", "FlowerId", c => c.Int());
            AlterColumn("dbo.WarehouseFlowers", "FlowerId", c => c.Int());
            AlterColumn("dbo.WarehouseFlowers", "WarehouseId", c => c.Int());
            AddPrimaryKey("dbo.PlantationFlowers", "Id");
            AddPrimaryKey("dbo.SupplyFlowers", "Id");
            AddPrimaryKey("dbo.WarehouseFlowers", "Id");
            CreateIndex("dbo.PlantationFlowers", "PlantationId");
            CreateIndex("dbo.PlantationFlowers", "FlowerId");
            CreateIndex("dbo.Supplies", "PlantationId");
            CreateIndex("dbo.Supplies", "WarehouseId");
            CreateIndex("dbo.SupplyFlowers", "FlowerId");
            CreateIndex("dbo.WarehouseFlowers", "WarehouseId");
            CreateIndex("dbo.WarehouseFlowers", "FlowerId");
            AddForeignKey("dbo.PlantationFlowers", "FlowerId", "dbo.Flowers", "Id");
            AddForeignKey("dbo.SupplyFlowers", "FlowerId", "dbo.Flowers", "Id");
            AddForeignKey("dbo.WarehouseFlowers", "FlowerId", "dbo.Flowers", "Id");
            AddForeignKey("dbo.PlantationFlowers", "PlantationId", "dbo.Plantations", "Id");
            AddForeignKey("dbo.Supplies", "PlantationId", "dbo.Plantations", "Id");
            AddForeignKey("dbo.Supplies", "WarehouseId", "dbo.Warehouses", "Id");
            AddForeignKey("dbo.WarehouseFlowers", "WarehouseId", "dbo.Warehouses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WarehouseFlowers", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Supplies", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Supplies", "PlantationId", "dbo.Plantations");
            DropForeignKey("dbo.PlantationFlowers", "PlantationId", "dbo.Plantations");
            DropForeignKey("dbo.WarehouseFlowers", "FlowerId", "dbo.Flowers");
            DropForeignKey("dbo.SupplyFlowers", "FlowerId", "dbo.Flowers");
            DropForeignKey("dbo.PlantationFlowers", "FlowerId", "dbo.Flowers");
            DropIndex("dbo.WarehouseFlowers", new[] { "FlowerId" });
            DropIndex("dbo.WarehouseFlowers", new[] { "WarehouseId" });
            DropIndex("dbo.SupplyFlowers", new[] { "FlowerId" });
            DropIndex("dbo.Supplies", new[] { "WarehouseId" });
            DropIndex("dbo.Supplies", new[] { "PlantationId" });
            DropIndex("dbo.PlantationFlowers", new[] { "FlowerId" });
            DropIndex("dbo.PlantationFlowers", new[] { "PlantationId" });
            DropPrimaryKey("dbo.WarehouseFlowers");
            DropPrimaryKey("dbo.SupplyFlowers");
            DropPrimaryKey("dbo.PlantationFlowers");
            AlterColumn("dbo.WarehouseFlowers", "WarehouseId", c => c.Int(nullable: false));
            AlterColumn("dbo.WarehouseFlowers", "FlowerId", c => c.Int(nullable: false));
            AlterColumn("dbo.SupplyFlowers", "FlowerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Supplies", "Status", c => c.String(maxLength: 10));
            AlterColumn("dbo.Supplies", "WarehouseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Supplies", "PlantationId", c => c.Int(nullable: false));
            AlterColumn("dbo.PlantationFlowers", "PlantationId", c => c.Int(nullable: false));
            AlterColumn("dbo.PlantationFlowers", "FlowerId", c => c.Int(nullable: false));
            DropColumn("dbo.WarehouseFlowers", "Id");
            DropColumn("dbo.SupplyFlowers", "Id");
            DropColumn("dbo.PlantationFlowers", "Id");
            AddPrimaryKey("dbo.WarehouseFlowers", new[] { "FlowerId", "WarehouseId" });
            AddPrimaryKey("dbo.SupplyFlowers", new[] { "FlowerId", "SupplyId" });
            AddPrimaryKey("dbo.PlantationFlowers", new[] { "FlowerId", "PlantationId" });
            CreateIndex("dbo.WarehouseFlowers", "WarehouseId");
            CreateIndex("dbo.WarehouseFlowers", "FlowerId");
            CreateIndex("dbo.SupplyFlowers", "FlowerId");
            CreateIndex("dbo.Supplies", "WarehouseId");
            CreateIndex("dbo.Supplies", "PlantationId");
            CreateIndex("dbo.PlantationFlowers", "PlantationId");
            CreateIndex("dbo.PlantationFlowers", "FlowerId");
            AddForeignKey("dbo.WarehouseFlowers", "WarehouseId", "dbo.Warehouses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Supplies", "WarehouseId", "dbo.Warehouses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Supplies", "PlantationId", "dbo.Plantations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PlantationFlowers", "PlantationId", "dbo.Plantations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WarehouseFlowers", "FlowerId", "dbo.Flowers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SupplyFlowers", "FlowerId", "dbo.Flowers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PlantationFlowers", "FlowerId", "dbo.Flowers", "Id", cascadeDelete: true);
        }
    }
}
