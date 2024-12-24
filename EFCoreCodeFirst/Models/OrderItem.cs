using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirst.Models
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("OrderId")]
        public Guid OrderId { get; set; }
        public int ItemId { get; set; }

        public int Qty {  get; set; }

        public virtual Order Order { get; set; }
    }
}
