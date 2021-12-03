using CoursesDAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CoursesDAL.Models
{
    public class Good
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GoodId { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        //[Remote("ValidateTitle", "Goods")]
        public string Title { get; set; }
        [Required]
        public Category Category { get; set; }
        public int? MinCount { get; set; }
        public bool IsDeleted { get; set; }
    }
}