using ResturantDelivery.Models;

namespace ResturantDelivery.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } 
        public decimal TotalAmount { get; set; }
    }
   

}
