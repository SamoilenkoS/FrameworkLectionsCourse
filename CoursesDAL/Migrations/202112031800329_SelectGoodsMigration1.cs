namespace CoursesDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SelectGoodsMigration1 : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("GetAllGoodsAndCount", @"
                SELECT g.GoodId,
                g.Title,
                Sum(gw.[Count]) AS Amount
                FROM GoodsWarehouse gw
                INNER JOIN Good g

                ON g.GoodId = gw.GoodId
                INNER JOIN Warehouse w

                ON gw.WarehouseId = w.WarehouseId 
                GROUP BY g.[GoodId],
                g.[Title],
                gw.[GoodId]");
        }
        
        public override void Down()
        {
        }
    }
}
