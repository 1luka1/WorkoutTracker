using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Constants
{
    public static class ErrorMessages
    {
        public const string InvalidEmailOrPassword = "Wrong email or password.";
        public const string InvalidEmail= "Wrong email.";
        public const string UserAlreadyExists = "User with this email already exists.";
        public const string EmailRequired = "Email is required.";
        public const string PasswordRequired = "Password is required.";
        public const string PasswordLength = "Password must be at least 4 characters long.";
        public const string FirstNameRequired = "First name is required.";
        public const string LastNameRequired = "Last name is required.";

    }
}
