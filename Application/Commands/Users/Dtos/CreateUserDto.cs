using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.Commands.Users.Dtos
{
    public record CreateUserDto(
      string FullName,
      string Email,
      string PhoneNumber,
      string Password
  );
}

