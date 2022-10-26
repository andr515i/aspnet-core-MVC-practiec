using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC_test.Models
{
    public class Mice
    {
        public int Id { get; set; }

        [StringLength(32, MinimumLength = 2)]
        [Required]
        public string? Name { get; set; }

        public int? Rating { get; set; } 

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(maximumLength:32, MinimumLength = 6)]
        [Required]
        public string? Company { get; set; }


    }
}
