using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirst.Models
{
    public class Test3
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }

        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
