namespace OnlineShop.Application.DTOs
{
    public class BrandDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string LogoUrl { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
