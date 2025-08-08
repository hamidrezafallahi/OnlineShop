
namespace OnlineShop.Domain.Entities
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Slug { get; set; } = default!; // 👈 این اضافه شد
        public string Content { get; set; } = default!;
        public string? ThumbnailUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public Guid AuthorId { get; set; }
        public User Author { get; set; } = default!;
    }

}
