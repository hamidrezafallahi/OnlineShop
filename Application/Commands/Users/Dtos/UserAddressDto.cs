
namespace Application.Commands.Users.Dtos
{
    public class UserAddressDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string FullAddress { get; set; } = default!;
        public bool IsDefault { get; set; }
    }
}