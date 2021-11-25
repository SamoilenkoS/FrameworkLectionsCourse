using CoursesDAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesDAL.Models
{
    public class Good
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GoodId { get; set; }
        public string Title { get; set; }
        [Required]
        public Category Category { get; set; }
        public int? MinCount { get; set; }
    }
}