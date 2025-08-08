

namespace Application.Commands.Users.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;

        // معمولا سفارش‌ها در یک DTO جداگانه مدیریت می‌شوند و فقط شناسه‌ها می‌آیند:
        public List<Guid>? OrderIds { get; set; }

        // آدرس‌ها هم می‌توانند به صورت یک لیست DTO جداگانه تعریف شوند:
        public List<UserAddressDto>? Addresses { get; set; }

        // اگر بخواهی می‌توانی اطلاعات مربوط به سبد خرید را هم اضافه کنی
        // ولی معمولاً یک DTO جداگانه برای Cart می‌سازند.
    }
}
