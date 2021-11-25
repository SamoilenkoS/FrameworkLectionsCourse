using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesDAL.Models
{
    public class Car
    {
        [Key]
        [ForeignKey(nameof(User))]
        public int UserId{ get; set; }

        public string Model { get; set; }

        public virtual User User { get; set; }
    }
}
