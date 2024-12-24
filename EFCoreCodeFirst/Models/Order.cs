using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirst.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public string OrderNumber { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
