public record CreateUserAddressDto(
    string City,
    string State,
    string PostalCode,
    string FullAddress,
    bool IsDefault
);
