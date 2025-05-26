namespace ResturantDelivery.Dtos
{
    public class OrderDto
    {
        public List<OrderItemDto> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
