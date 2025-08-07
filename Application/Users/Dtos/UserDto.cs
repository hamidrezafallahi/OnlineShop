using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Application.Blogs.Dtos;
using OnlineShop.Application.DTOs;

namespace OnlineShop.Application.Users.Dtos
{
    public record UserDto(
      Guid Id,
      string FullName,
      string Email,
      string PhoneNumber,
      ICollection<OrderDto> Orders,
      ICollection<UserAddressDto> Addresses,
      ICollection<BlogDto> Blogs,
      CartDto? Cart
  );


}
