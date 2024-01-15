using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorWeb.Models
{
    public class Article
    {
        [Key]
        public int  Id { get; set; }

        [Required]
        [StringLength(255)]
        [Column(TypeName = "nvarchar")]
        [Display(Name ="Tiêu đề")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Thời gian tạo")]
        public DateTime Created { get; set; }

        [Display(Name = "Nội dung")]
        public string Content { get; set; }
    }
}
