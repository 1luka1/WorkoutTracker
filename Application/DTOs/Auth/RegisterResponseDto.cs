using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Auth
{
    public record RegisterResponseDto (
        int UserId,
        string Email,
        string FirstName,
        string LastName
    );
}
