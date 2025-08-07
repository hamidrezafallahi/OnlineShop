using System;
using System.Collections.Generic;

namespace OnlineShop.Application.DTOs
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }

        // برای جلوگیری از پیچیدگی، معمولاً فقط شناسه‌ی والد را می‌گذاریم، 
        // ولی اگر بخواهی می‌توانی زیرشاخه‌ها را به صورت ساده بیاوری:

        public List<CategoryDto>? SubCategories { get; set; }
    }
}
