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
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        public string Content { get; set; }
    }
}
