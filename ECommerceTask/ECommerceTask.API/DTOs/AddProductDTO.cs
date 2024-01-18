namespace ECommerceTask.API.DTOs
{
    public class AddProductDTO
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public decimal Price { get; set; }
        public int MinQuantity { get; set; }
        public decimal DiscountRate { get; set; }
    }
}
