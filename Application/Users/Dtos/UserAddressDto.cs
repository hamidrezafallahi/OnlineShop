public record UserAddressDto(
    Guid Id,
    string City,
    string State,
    string PostalCode,
    string FullAddress,
    bool IsDefault
);
