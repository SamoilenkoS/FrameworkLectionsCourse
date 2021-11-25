namespace CoursesDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Goods", newName: "Good");
            DropPrimaryKey("dbo.Good");
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Model = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.GoodsWarehouse",
                c => new
                    {
                        GoodId = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GoodId, t.WarehouseId })
                .ForeignKey("dbo.Good", t => t.GoodId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouse", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.GoodId)
                .Index(t => t.WarehouseId);
            
            CreateTable(
                "dbo.Warehouse",
                c => new
                    {
                        WarehouseId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.WarehouseId);
            
            AddColumn("dbo.Good", "GoodId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Good", "GoodId");
            DropColumn("dbo.Good", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Good", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.GoodsWarehouse", "WarehouseId", "dbo.Warehouse");
            DropForeignKey("dbo.GoodsWarehouse", "GoodId", "dbo.Good");
            DropForeignKey("dbo.Car", "UserId", "dbo.User");
            DropIndex("dbo.GoodsWarehouse", new[] { "WarehouseId" });
            DropIndex("dbo.GoodsWarehouse", new[] { "GoodId" });
            DropIndex("dbo.Car", new[] { "UserId" });
            DropPrimaryKey("dbo.Good");
            DropColumn("dbo.Good", "GoodId");
            DropTable("dbo.Warehouse");
            DropTable("dbo.GoodsWarehouse");
            DropTable("dbo.User");
            DropTable("dbo.Car");
            AddPrimaryKey("dbo.Good", "Id");
            RenameTable(name: "dbo.Good", newName: "Goods");
        }
    }
}
