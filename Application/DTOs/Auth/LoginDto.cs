using Application.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Auth
{
    public record LoginDto(
       [Required(ErrorMessage = ErrorMessages.EmailRequired)]
       [EmailAddress(ErrorMessage = ErrorMessages.InvalidEmail)]
       string Email,

       [Required(ErrorMessage = ErrorMessages.PasswordRequired)]
       string Password

    );
}
