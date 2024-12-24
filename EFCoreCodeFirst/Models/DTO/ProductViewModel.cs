using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirst.Models.DTO
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(40)")]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required(ErrorMessage = "Please select an Image !")]
        [Column(TypeName = "varchar(100)")]
        public IFormFile photo { get; set; }
    }
}
