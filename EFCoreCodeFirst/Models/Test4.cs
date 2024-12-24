using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirst.Models
{
    public class Test4
    {
        [Key]
        public int Id { get; set; }
        public string Name2 { get; set; }

        public string Description { get; set; }
    }
}
