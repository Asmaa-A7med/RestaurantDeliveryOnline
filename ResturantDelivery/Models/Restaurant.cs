namespace ResturantDelivery.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
