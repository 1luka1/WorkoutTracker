using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Application.Constants;

namespace Application.DTOs.Auth
{
    public record RegisterDto(
        [Required(ErrorMessage = ErrorMessages.EmailRequired)]
        [EmailAddress(ErrorMessage = ErrorMessages.InvalidEmail)]
        string Email,
        [Required(ErrorMessage = ErrorMessages.PasswordRequired)]
        [MinLength(4, ErrorMessage = ErrorMessages.PasswordLength)]
        string Password,
        [Required(ErrorMessage = ErrorMessages.FirstNameRequired)]
        string FirstName,
        [Required(ErrorMessage = ErrorMessages.LastNameRequired)]
        string LastName
    );
}