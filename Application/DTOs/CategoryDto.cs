namespace OnlineShop.Application.DTOs
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public List<CategoryDto>? SubCategories { get; set; }
    }
}
