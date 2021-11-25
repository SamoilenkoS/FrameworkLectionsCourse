using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesDAL.Models
{
    public class GoodsWarehouse
    {
        [Key]
        [ForeignKey(nameof(Good))]
        public int GoodId { get; set; }
        [Key]
        [ForeignKey(nameof(Warehouse))]
        public int WarehouseId { get; set; }
        public int Count { get; set; }
        public virtual Good Good { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
