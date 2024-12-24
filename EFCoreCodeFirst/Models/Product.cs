using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirst.Models
{
    public class Product
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
        public string ImagePath { get; set; }
    }
}
