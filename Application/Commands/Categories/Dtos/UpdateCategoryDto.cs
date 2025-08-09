namespace Application.Commands.Categories.Dtos
{
    public class UpdateCategoryDto
    {
        public string Name { get; set; } = null!;
        public Guid? ParentCategoryId { get; set; }
    }
}
