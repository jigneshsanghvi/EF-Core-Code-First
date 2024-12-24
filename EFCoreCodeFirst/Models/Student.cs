using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirst.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column("StudentName", TypeName = "varchar(50)")]
        public string StudentName { get; set; }

        [Required]
        [Column("Gender", TypeName = "varchar(10)")]
        public string Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int StudentStandard { get; set; }

    }
    public enum Gender
    {
        Male, Female
    }
}
